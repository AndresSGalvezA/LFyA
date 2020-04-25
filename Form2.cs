using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FinalLFA
{
    public partial class Form2 : Form
    {
        string File = string.Empty;
        Node Ex = default;
        List<NodeList> ValidateSets = new List<NodeList>();
        List<NodeList> ValidateTokens = new List<NodeList>();
        List<NodeList> ValidateActions = new List<NodeList>();
        List<NodeList> ValidateError = new List<NodeList>();

        public Form2(string file)
        {
            InitializeComponent();
            File = file;

            //Ingreso de datos.
            var A = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var B = ' ';
            var C = "'E'..'E'";
            var D = "'E'";
            var E = string.Empty;
            
            for (int pos = 0; pos < 256; pos++)
            {
                E += Convert.ToChar(Convert.ToByte(pos));
            }

            var F = "CHR(N)";
            var G = "CHR(NN)";
            var H = "CHR(NNN)";
            var J = "CHR(N)..CHR(N)";
            var L = "CHR(N)..CHR(NN)";
            var M = "CHR(N)..CHR(NNN)";
            var N = "0123456789";
            var Ñ = "CHR(NN)..CHR(N)";
            var O = "CHR(NN)..CHR(NN)";
            var Q = "CHR(NN)..CHR(NNN)";
            var R = "CHR(NNN)..CHR(N)";
            var S = "CHR(NNN)..CHR(NN)";
            var T = "CHR(NNN)..CHR(NNN)";
            var P = "+";

            //Tokens.
            var X = '"';
            var I = E + X;
            var U = "'I'";
            var K = "TOKEN";
            var V = " ";
            var W = "+*/()[]{}|?";

            //Expresiones.
            var ExpSets = "((A+.B*.=.B*).((C|D|J|L|M|Ñ|O|Q|R|S|T|H|F|G).B*.P?.B*)+).#";
            var ExpTokens = "((K.B+.N+.B*.=.B*).(U|A|B|W)+).#";
            var ExpActions = "(N+.B*.=.B*.'.A+.').#";
            var ExpError = "(A+.B*.=.B*.N+).#";

            // Expresión árbol.
            var StringList = new List<string>();
            var SetsList = new List<NodeList>();
            var TokenList = new List<NodeList>();
            var ActionsList = new List<NodeList>();
            var ErrorList = new List<NodeList>();
            var TAux = new List<string>();
            var SAux = new List<string>();
            var sets = false;
            var _new = new AuxClass();
            var flfn = new TreeElements();
            _new.ReadingFile(File, StringList, ref SetsList, ref TokenList, ref ActionsList, ref ErrorList, ref sets, ref TAux, ref SAux);
            ValidateSets = SetsList;
            ValidateTokens = TokenList;
            ValidateActions = ActionsList;
            var error = false;
            var Quantity = 0;

            if (!sets)
            {
                if (SetsList.Count() != 0)
                {
                    SetsList.Remove(SetsList[0]);

                    foreach (NodeList NodeList in SetsList)
                    {
                        Quantity = 0;
                        var Continue = string.Empty;
                        var TreeSETS = new Tree();
                        var Find = false;
                        TreeSETS.Root = _new.CreateTree(ExpSets);
                        TreeSETS.RoadS(TreeSETS.Root, TreeSETS.Root, TreeSETS.Root, Find, ref NodeList.Text, ref Continue, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref Quantity);
                        
                        if (Continue == "NPC" || Quantity == 0)
                        {
                            MessageBox.Show("Error en la línea " + NodeList.NLine + ".");
                            error = true;
                            break;
                        }
                    }
                }
                else MessageBox.Show("Error en la línea 1.");
                
                if (!error)
                {
                    if (TokenList.Count() != 0)
                    {
                        if (ActionsList.Count() != 0)
                        {
                            if (TokenList[0].NLine < ActionsList[0].NLine)
                            {
                                TokenList.Remove(TokenList[0]);

                                foreach (NodeList NodeList in TokenList)
                                {
                                    Quantity = 0;
                                    var TreeTokens = new Tree();
                                    TreeTokens.Root = _new.CreateTree(ExpTokens);
                                    var Find = false;
                                    var Continue = string.Empty;
                                    var contp = 0;
                                    var contll = 0;
                                    TreeTokens.RoadTokens(TreeTokens.Root, TreeTokens.Root, Find, ref NodeList.Text, ref Continue, K, B, N, U, A, W, I, V, ref Quantity, ref contp, ref contll);
                                    
                                    if (Continue == "NPC" || Quantity == 0 || contp % 2 != 0 || contll % 2 != 0)
                                    {
                                        MessageBox.Show("Error en la línea " + NodeList.NLine + ".");
                                        error = true;
                                        break;
                                    }
                                }
                                
                                if (!error)
                                {
                                    ActionsList.Remove(ActionsList[0]);
                                    var Reservadas = false;
                                    
                                    foreach (NodeList NodeList in ActionsList)
                                    {
                                        if (!Reservadas) Reservadas = (NodeList.Text.Contains("RESERVADAS()")) ? true : false;
                                    }
                                    
                                    if (Reservadas)
                                    {
                                        if (ActionsList[ActionsList.Count() - 1].Text == "}")
                                        {
                                            while (ActionsList.Count() != 0)
                                            {
                                                if (ActionsList[0].Text.Contains("()") && ActionsList[1].Text.Contains("{"))
                                                {
                                                    ActionsList.Remove(ActionsList[0]);
                                                    ActionsList.Remove(ActionsList[0]);
                                                    
                                                    foreach (NodeList NodeList in ActionsList)
                                                    {
                                                        if (NodeList.Text == "}")
                                                        {
                                                            var net = new NodeList();
                                                            net = NodeList;
                                                            ActionsList.Remove(net);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Quantity = 0;
                                                            var TreeActions = new Tree();
                                                            TreeActions.Root = _new.CreateTree(ExpActions);
                                                            var Find = false;
                                                            var Continue = string.Empty;
                                                            TreeActions.RoadA(TreeActions.Root, TreeActions.Root, Find, ref NodeList.Text, ref Continue, N, B, A, ref Quantity);
                                                            
                                                            if (Continue == "NPC" || Quantity < 2)
                                                            {
                                                                MessageBox.Show("Error en la línea " + NodeList.NLine + ".");
                                                                error = true;
                                                                break;
                                                            }
                                                        }
                                                    }

                                                    if (error) break;
                                                    else
                                                    {
                                                        var limit = ActionsList.Count();

                                                        for (int i = 0; i < limit; i++)
                                                        {
                                                            if (ActionsList[0].Text == "") ActionsList.Remove(ActionsList[0]);
                                                            else break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("El archivo no posee la llave de inicio o no está bien escrita la función");
                                                    error = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El archivo no posee la llave de final o su método Error está mal");
                                            error = true;
                                        }
                                        
                                        if (!error)
                                        {
                                            if (ErrorList.Count() != 0)
                                            {
                                                foreach (NodeList NodeList in ErrorList)
                                                {
                                                    Quantity = 0;
                                                    var TreeErrors = new Tree();
                                                    TreeErrors.Root = _new.CreateTree(ExpError);
                                                    var Find = false;
                                                    var Continue = string.Empty;
                                                    TreeErrors.RoadError(TreeErrors.Root, TreeErrors.Root, Find, ref NodeList.Text, ref Continue, A, B, N, ref Quantity);

                                                    if (Continue == "NPC" || Quantity < 1)
                                                    {
                                                        MessageBox.Show("Error en la línea " + NodeList.NLine + ".");
                                                        error = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            else MessageBox.Show("Error: No existe implementación de ERROR.");
                                        }
                                    }
                                    else MessageBox.Show("Error en Reservadas().");
                                }
                            }
                            else MessageBox.Show("Orden de escritura incorrecto.");
                        }
                        else MessageBox.Show("La palabra Actions no está escrita correctamente o el archivo no posee el apartado Actions");
                    }
                    else MessageBox.Show("La palabra Tokens no está escrita correctamente o el archivo no posee el apartado.");
                }
            }
            else MessageBox.Show("Error en Sets o Tokens.");
            
            if (!error)
            {
                TAux.Remove(TAux[0]);
                var Exp = flfn.ObtenerExpR(TAux, SAux);

                if (Exp != string.Empty)
                {
                    Expr.Text = (Exp);
                    var Tree = new Tree();
                    Tree.Root = _new.CreateTreeP2(Exp);
                    Ex = Tree.Root;
                    var Counter = 1;
                    flfn.IngresarFLH(Tree.Root, ref Counter);
                    flfn.RecorrerFLN(Tree.Root);
                    var diccionario = new Dictionary<int, string>();
                    
                    for (int x = 1; x < Counter; x++)
                    {
                        diccionario.Add(x, string.Empty);
                    
                    }
                    
                    //Generar follows.
                    diccionario = flfn.TablaFollow(Tree.Root, diccionario, ref Counter);
                    
                    //Generar transiciones.
                    var ListaSimbolos = new List<string>();
                    ListaSimbolos = flfn.ObtenerSímbolos(Tree.Root, ListaSimbolos);
                    ListaSimbolos.Remove(ListaSimbolos.Last());
                    var dic = new Dictionary<string, string[]>();
                    dic.Add(Tree.Root.element.First, null);
                    dic = flfn.Transición(Tree.Root, dic, ListaSimbolos, diccionario);
                    
                    //Generar tabla de first, last, nulabilidad.
                    var matrix = new List<string[]>();
                    flfn.MostrarFLN(Tree.Root, ref matrix);
                    DataGridViewRow Matrix = new DataGridViewRow();
                    Matrix.CreateCells(dataGridView1);
                    Matrix.Cells[0].Value = "Símbolo";
                    Matrix.Cells[1].Value = "First";
                    Matrix.Cells[2].Value = "Last";
                    Matrix.Cells[3].Value = "Nullable";
                    
                    for (int i = 0; i < matrix.Count(); i++)
                    {
                        dataGridView1.Rows.Add();
                        var aux = matrix[i];
                        dataGridView1.Rows[i].Cells[0].Value = aux[0];
                        dataGridView1.Rows[i].Cells[1].Value = aux[1];
                        dataGridView1.Rows[i].Cells[2].Value = aux[2];
                        dataGridView1.Rows[i].Cells[3].Value = aux[3];
                    }
                    
                    //Mostrar Tabla Follow.
                    Counter = 1;
                    
                    while (Counter < diccionario.Count())
                    {
                        diccionario[Counter] = diccionario[Counter].Trim(',');
                        Counter++;
                    }
                    
                    var z = 0;
                    
                    foreach (int clave in diccionario.Keys)
                    {
                        dataGridView2.Rows.Add();
                        var valor = diccionario.FirstOrDefault(x => x.Key == clave).Value;
                        dataGridView2.Rows[z].Cells[0].Value = clave;
                        dataGridView2.Rows[z].Cells[1].Value = valor;
                        z++;
                    }

                    //Mostrar tabla de transiciones.
                    DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
                    Col.HeaderText = "ESTADOS";
                    Col.Width = 200;
                    dataGridView3.Columns.Add(Col);

                    foreach (string simbol in ListaSimbolos)
                    {
                        DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                        columna.HeaderText = simbol;
                        columna.Width = 200;
                        dataGridView3.Columns.Add(columna);
                    }

                    z = 0;

                    foreach (string clave in dic.Keys)
                    {
                        dataGridView3.Rows.Add();
                        var valor = dic.FirstOrDefault(x => x.Key == clave).Value;
                        dataGridView3.Rows[z].Cells[0].Value = clave;
                        var cont = 1;
                        for (int x = 0; x < valor.Length; x++)
                        {
                            dataGridView3.Rows[z].Cells[cont].Value = valor[x];
                            cont++;
                        }
                        z++;
                    }
                }
                else
                {
                    MessageBox.Show("El archivo contiene valores en TOKENS que no están escritos en SETS");
                }
            }

            CodeBox.Items.Add("using System;");
            CodeBox.Items.Add("using System.IO;");
            CodeBox.Items.Add("using System.Collections.Generic;");
            CodeBox.Items.Add("using System.Threading;");
            CodeBox.Items.Add("public class Program");
            CodeBox.Items.Add("{");
            CodeBox.Items.Add(" static void Main()");
            CodeBox.Items.Add(" {");
            CodeBox.Items.Add("     var TokenList = new List<string>();");
            CodeBox.Items.Add("     var ActionsList = new List<string[]>();");
            CodeBox.Items.Add("     string originalfile, newfile, ThisReading = string.Empty, ErrorNumber, Expression;");
            CodeBox.Items.Add("     Console.Title = \"Validador de tokens\";");
            CodeBox.Items.Add("     Console.BackgroundColor = ConsoleColor.White;");
            CodeBox.Items.Add("     Console.ForegroundColor = ConsoleColor.Black;");
            CodeBox.Items.Add("     Console.Clear();");
            CodeBox.Items.Add("     Console.WriteLine(\"Validador de tokens. Arrastre el archivo de tokens:\");");
            CodeBox.Items.Add("     originalfile = Console.ReadLine();");
            CodeBox.Items.Add("     Console.WriteLine(\"Arrastre el archivo a evaluar:\");");
            CodeBox.Items.Add("     newfile = Console.ReadLine();");
            CodeBox.Items.Add("     var OriginalReader = new StreamReader(originalfile);");
            CodeBox.Items.Add("     while (ThisReading != \"TOKENS\")");
            CodeBox.Items.Add("     {");
            CodeBox.Items.Add("         ThisReading = OriginalReader.ReadLine();");
            CodeBox.Items.Add("     }");
            CodeBox.Items.Add("     while (ThisReading != \"ACTIONS\")");
            CodeBox.Items.Add("     {");
            CodeBox.Items.Add("         ThisReading = OriginalReader.ReadLine();");
            CodeBox.Items.Add("         if (ThisReading != \"ACTIONS\") TokenList.Add(ThisReading.Replace(\"TOKEN\", \"\").Trim('\''));");
            CodeBox.Items.Add("     }");
            CodeBox.Items.Add("     while (ThisReading != \"{\")");
            CodeBox.Items.Add("     {");
            CodeBox.Items.Add("         ThisReading = OriginalReader.ReadLine().Trim();");
            CodeBox.Items.Add("     }");
            CodeBox.Items.Add("     while (ThisReading != \"}\")");
            CodeBox.Items.Add("     {");
            CodeBox.Items.Add("         ThisReading = OriginalReader.ReadLine().Trim();");
            CodeBox.Items.Add("         if (ThisReading != \"}\") ActionsList.Add(ThisReading.Replace(\"'\", \"\").Split('='));");
            CodeBox.Items.Add("     }");
            CodeBox.Items.Add("     ErrorNumber = OriginalReader.ReadLine().Replace(\"ERROR = \", \"\").Trim();");
            CodeBox.Items.Add("     OriginalReader.Close();");
            CodeBox.Items.Add("     var NewReader = new StreamReader(newfile);");
            CodeBox.Items.Add("     Expression = NewReader.ReadLine().Trim();");
            CodeBox.Items.Add("     NewReader.Close();");
            CodeBox.Items.Add("     Console.WriteLine();");
            CodeBox.Items.Add("     Console.WriteLine(\"Expresión a evaluar: \" + Expression);");
            CodeBox.Items.Add("     foreach (var item in ActionsList)");
            CodeBox.Items.Add("     {");
            CodeBox.Items.Add("         if (Expression.ToUpper().Contains(item[1].ToUpper().Trim()))");
            CodeBox.Items.Add("         {");
            CodeBox.Items.Add("             Console.WriteLine(item[1].Trim() + \" = \" + item[0].Trim());");
            CodeBox.Items.Add("             Expression = Expression.ToUpper().Replace(item[1].ToUpper().Trim(), \"\").Trim();");
            CodeBox.Items.Add("         }");
            CodeBox.Items.Add("     }");
            CodeBox.Items.Add("     Console.WriteLine(\"Presione una tecla para salir.\");");
            CodeBox.Items.Add("     Console.ReadKey();");
            CodeBox.Items.Add(" }");
            CodeBox.Items.Add("}");
        }
        
        private void BtnViewTree_Click(object sender, EventArgs e)
        {
            var F3 = new Form3(Ex);
            F3.Show();
            Visible = false;
        }

        private void BtnCompile_Click(object sender, EventArgs e)
        {
            var File = new FileStream(Path.GetFullPath("File.cs"), FileMode.Create);
            var Writer = new StreamWriter(File);
            Writer.WriteLine("using System;");
            Writer.WriteLine("using System.IO;");
            Writer.WriteLine("using System.Collections.Generic;");
            Writer.WriteLine("using System.Threading;");
            Writer.WriteLine("public class Program");
            Writer.WriteLine("{");
            Writer.WriteLine(" static void Main()");
            Writer.WriteLine(" {");
            Writer.WriteLine("     var TokenList = new List<string>();");
            Writer.WriteLine("     var ActionsList = new List<string[]>();");
            Writer.WriteLine("     string originalfile, newfile, ThisReading = string.Empty, ErrorNumber, Expression;");
            Writer.WriteLine("     Console.Title = \"Validador de tokens\";");
            Writer.WriteLine("     Console.BackgroundColor = ConsoleColor.White;");
            Writer.WriteLine("     Console.ForegroundColor = ConsoleColor.Black;");
            Writer.WriteLine("     Console.Clear();");
            Writer.WriteLine("     Console.WriteLine(\"Validador de tokens. Arrastre el archivo de tokens:\");");
            Writer.WriteLine("     originalfile = Console.ReadLine();");
            Writer.WriteLine("     Console.WriteLine(\"Arrastre el archivo a evaluar:\");");
            Writer.WriteLine("     newfile = Console.ReadLine();");
            Writer.WriteLine("     var OriginalReader = new StreamReader(originalfile);");
            Writer.WriteLine("     while (ThisReading != \"TOKENS\")");
            Writer.WriteLine("     {");
            Writer.WriteLine("         ThisReading = OriginalReader.ReadLine();");
            Writer.WriteLine("     }");
            Writer.WriteLine("     while (ThisReading != \"ACTIONS\")");
            Writer.WriteLine("     {");
            Writer.WriteLine("         ThisReading = OriginalReader.ReadLine();");
            Writer.WriteLine("         if (ThisReading != \"ACTIONS\") TokenList.Add(ThisReading.Replace(\"TOKEN\", \" \").Trim('\\''));");
            Writer.WriteLine("     }");
            Writer.WriteLine("     while (ThisReading != \"{\")");
            Writer.WriteLine("     {");
            Writer.WriteLine("         ThisReading = OriginalReader.ReadLine().Trim();");
            Writer.WriteLine("     }");
            Writer.WriteLine("     while (ThisReading != \"}\")");
            Writer.WriteLine("     {");
            Writer.WriteLine("         ThisReading = OriginalReader.ReadLine().Trim();");
            Writer.WriteLine("         if (ThisReading != \"}\") ActionsList.Add(ThisReading.Replace(\"'\", \"\").Split('='));");
            Writer.WriteLine("     }");
            Writer.WriteLine("     ErrorNumber = OriginalReader.ReadLine().Replace(\"ERROR = \", \"\").Trim();");
            Writer.WriteLine("     OriginalReader.Close();");
            Writer.WriteLine("     var NewReader = new StreamReader(newfile);");
            Writer.WriteLine("     Expression = NewReader.ReadLine().Trim();");
            Writer.WriteLine("     NewReader.Close();");
            Writer.WriteLine("     Console.WriteLine();");
            Writer.WriteLine("     Console.WriteLine(\"Expresión a evaluar: \" + Expression);");
            Writer.WriteLine("     foreach (var item in ActionsList)");
            Writer.WriteLine("     {");
            Writer.WriteLine("         if (Expression.ToUpper().Contains(item[1].ToUpper().Trim()))");
            Writer.WriteLine("         {");
            Writer.WriteLine("             Console.WriteLine(item[1].Trim() + \" = \" + item[0].Trim());");
            Writer.WriteLine("             Expression = Expression.ToUpper().Replace(item[1].ToUpper().Trim(), \"\").Trim();");
            Writer.WriteLine("         }");
            Writer.WriteLine("     }");
            Writer.WriteLine("     Console.WriteLine(\"Presione una tecla para salir.\");");
            Writer.WriteLine("     Console.ReadKey();");
            Writer.WriteLine(" }");
            Writer.WriteLine("}");
            Writer.Close();
            File.Close();
            string errors = "";
            var codeProvider = CodeDomProvider.CreateProvider("CSharp");
            var parameters = new CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = "File.exe"
            };
            var results = codeProvider.CompileAssemblyFromFile(parameters, "File.cs");

            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    errors = errors + "Error en la compilación. Línea: " + CompErr.Line + ", código: " + CompErr.ErrorNumber + ". " + CompErr.ErrorText;
                }

                MessageBox.Show(errors);
            }
            else Process.Start("File.exe");
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            var F1 = new Form1();
            F1.Show();
            Visible = false;
        }
    }
}