using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalLFA
{
    public class TreeElements
    {
        public List<string> GenerarListaSETS(List<string> ListaSETS)
        {
            var List = new List<string>();
            var contador = 0;
            foreach (string nodo in ListaSETS)
            {
                var auxiliar = string.Empty;
                foreach (char caracter in nodo)
                {
                    if (caracter == '=')
                    {
                        auxiliar = nodo.Substring(0, contador);
                        contador = 0;
                        auxiliar = auxiliar.Trim(' ');
                        List.Add(auxiliar);
                        break;
                    }
                    else
                    {
                        contador++;
                    }
                }
            }
            return List;
        }

        public string ObtenerExpR(List<string> ListaTokens, List<string> SAux)
        {
            byte Y = 65;
            var Expression = string.Empty;
            var Final = new List<string>();
            var Aux = new List<string>();
            var List = new List<string>();
            var dic = new Dictionary<string, char>();
            var error = false;
            var final = "((";
            var A = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var cont = 0;
            if (SAux.Count() != 0)
            {
                SAux.Remove(SAux[0]);
                List = GenerarListaSETS(SAux);
            }
            else
            {
                foreach (string cadena in ListaTokens)
                {
                    var igual = false;
                    if (cadena.Contains("DIGITO") || cadena.Contains("LETRA") || cadena.Contains("CHARSET"))
                    {
                        error = true;
                        break;
                    }
                    foreach (char caracter in cadena)
                    {
                        if (caracter == '=')
                        {
                            igual = true;
                        }
                        if (igual)
                        {
                            if (A.Contains(caracter))
                            {
                                cont++;
                            }
                            else
                            {
                                cont = 0;
                            }
                            if (cont > 1)
                            {
                                error = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (!error)
            {
                foreach (string cadena in ListaTokens)
                {
                    var CAux = encontrarIgual(cadena);
                    Aux.Add(CAux);
                }
                //Reemplazar los valores según la tabla SETS
                var nuevo = "'";
                if (List.Count() != 0)
                {
                    foreach (string cadena in Aux)
                    {
                        Expression = Ajustar(cadena, List, ref dic, ref Y);
                        Final.Add(Expression);
                    }
                }
                else
                {
                    foreach (string cadena in Aux)
                    {
                        Final.Add(cadena);
                    }
                }
                foreach (string cadena in Final)
                {
                    var aux = string.Empty;
                    if (cadena.Contains("RESERVADAS"))
                    {
                        aux = cadena.Replace("{ RESERVADAS() }", " ");
                    }
                    cont = 0;
                    if (aux != string.Empty)
                    {
                        foreach (char caracter in aux)
                        {
                            if (A.Contains(caracter))
                            {
                                cont++;
                            }
                            else
                            {
                                cont = 0;
                            }
                            if (cont > 1)
                            {
                                error = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (char caracter in cadena)
                        {
                            if (A.Contains(caracter))
                            {
                                cont++;
                            }
                            else
                            {
                                cont = 0;
                            }
                            if (cont > 1)
                            {
                                error = true;
                                break;
                            }
                        }
                    }
                }
                if (!error)
                {
                    //concatenar todo en una frase
                    Expression = string.Empty;
                    foreach (string frase in Final)
                    {
                        Expression += Concatenar(frase);
                        Expression += '|';
                    }
                    Expression = Expression.Trim('|');
                    for (int i = 0; i < Expression.Length; i++)
                    {
                        var aux = dic.FirstOrDefault(x => x.Value == Expression[i]).Value;
                        var aus = dic.FirstOrDefault(x => x.Value == Expression[i]).Key;
                        if (i < Expression.Length - 1)
                        {
                            if (Expression[i] == aux && Expression[i + 1] != nuevo[0])
                            {
                                var reserva = dic.FirstOrDefault(x => x.Value == Expression[i]).Key;
                                final += reserva;
                            }
                            else
                            {
                                final += Expression[i];
                            }
                        }
                        else
                        {
                            final += Expression[i];
                        }
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
            final += ").#)";
            return final;
        }

        private string encontrarIgual(string cadena)
        {
            var numero = 0;
            var CAux = string.Empty;
            for (int i = 0; i < cadena.Length; i++)
            {
                if ((cadena[i] == '='))
                {
                    numero = i;
                    break;
                }
            }
            CAux = cadena.Substring(numero + 1);
            CAux = CAux.Trim(' ');
            return CAux;
        }

        private string Concatenar(string aux)
        {
            if (aux.Contains("RESERVADAS"))
            {
                aux = aux.Replace("{ RESERVADAS() }", " ");
            }
            var caracter = "'";
            string Exp = string.Empty;
            for (int i = 0; i < aux.Length; i++)
            {
                if ((aux[i] != ' ') && (!"    \t".Contains(aux[i])))
                {
                    if (aux[i] != '*' && aux[i] != '+' && aux[i] != '|' && aux[i] != ')' && aux[i] != '(' && aux[i] != caracter[0] && aux[i] != '?')
                    {
                        if (i > 0)
                        {
                            if (Exp[Exp.Length - 1] != '*' && Exp[Exp.Length - 1] != '+' && Exp[Exp.Length - 1] != caracter[0] && Exp[Exp.Length - 1] != ')')
                            {
                                Exp += aux[i] + ".";
                            }
                            else
                            {
                                if (Exp[Exp.Length - 1] != '|')
                                {
                                    Exp += "." + aux[i] + ".";
                                }
                                else
                                {
                                    Exp += aux[i] + ".";
                                }
                            }
                        }
                        else
                        {
                            Exp += aux[i] + ".";
                        }
                    }
                    else
                    {
                        if (aux[i] == '(')
                        {
                            if (i == 0)
                            {
                                Exp += aux[i];
                            }
                            else
                            {
                                if (Exp[Exp.Length - 1] != '.' && Exp[Exp.Length - 1] != '|')
                                {
                                    Exp += "." + aux[i];
                                }
                                else
                                {
                                    Exp += aux[i];
                                }
                            }
                        }
                        else
                        {
                            if (aux[i] == caracter[0] && i != aux.Length - 1)
                            {
                                if (Exp.Length != 0)
                                {
                                    if (Exp[Exp.Length - 1] == '*' || Exp[Exp.Length - 1] == '+' || Exp[Exp.Length - 1] == '?')
                                    {
                                        Exp += ".";
                                        Exp += aux[i];
                                        i++;
                                        Exp += aux[i];
                                        i++;
                                        Exp += aux[i];
                                        Exp += '.';
                                    }
                                    else
                                    {
                                        Exp += aux[i];
                                        i++;
                                        Exp += aux[i];
                                        i++;
                                        Exp += aux[i];
                                        Exp += '.';
                                    }
                                }
                                else
                                {
                                    Exp += aux[i];
                                    i++;
                                    Exp += aux[i];
                                    i++;
                                    Exp += aux[i];
                                    Exp += '.';
                                }
                            }
                            else
                            {
                                if (Exp.Length != 0)
                                {
                                    if (Exp[Exp.Length - 1] == '.')
                                    {
                                        Exp = Exp.Trim('.');
                                    }
                                }
                                Exp += aux[i];
                            }
                        }
                    }
                }
            }
            Exp = Exp.Trim('.');
            return Exp;
        }

        private string Ajustar(string cadena, List<string> ListaSETS, ref Dictionary<string, char> dic, ref byte Y)
        {
            var Aux = string.Empty;
            foreach (string frase in ListaSETS)
            {
                var aus = string.Empty;
                if (cadena.Contains(frase) && (!dic.ContainsKey(frase)))
                {
                    aus += (Convert.ToChar(Y));
                    cadena = cadena.Replace(frase, aus);
                    dic.Add(frase, Convert.ToChar(Y));
                    Y++;
                }
                else
                {
                    if (cadena.Contains(frase) && (dic.ContainsKey(frase)))
                    {
                        aus += dic.FirstOrDefault(x => x.Key == frase).Value;
                        cadena = cadena.Replace(frase, aus);
                    }
                }
            }
            return cadena;
        }

        public void IngresarFLH(Node Actual, ref int contador)
        {
            if (Actual == null)
            {
                return;
            }
            IngresarFLH(Actual.LeftNode, ref contador);
            if (Actual.LeftNode == null && Actual.RightNode == null)
            {
                Actual.element.First = Convert.ToString(contador);
                Actual.element.Last = Convert.ToString(contador);
                contador++;
            }
            IngresarFLH(Actual.RightNode, ref contador);
        }

        public void RecorrerFLN(Node Actual)
        {
            if (Actual == null)
            {
                return;
            }
            RecorrerFLN(Actual.LeftNode);
            RecorrerFLN(Actual.RightNode);
            if (Actual.RightNode == null && Actual.LeftNode == null)
            {

            }
            else
            {
                Actual.element.First = (Actual.element.Character == "*" || Actual.element.Character == "+" || Actual.element.Character == "?") ? Actual.LeftNode.element.First : (Actual.element.Character == "|") ? Actual.LeftNode.element.First + "," + Actual.RightNode.element.First : (Actual.element.Character == "." && Actual.LeftNode.element.Null) ? Actual.LeftNode.element.First + "," + Actual.RightNode.element.First : (Actual.element.Character == "." && !Actual.LeftNode.element.Null) ? Actual.LeftNode.element.First : string.Empty;
                Actual.element.Last = (Actual.element.Character == "*" || Actual.element.Character == "+" || Actual.element.Character == "?") ? Actual.LeftNode.element.Last : (Actual.element.Character == "|") ? Actual.LeftNode.element.Last + "," + Actual.RightNode.element.Last : (Actual.element.Character == "." && Actual.RightNode.element.Null) ? Actual.LeftNode.element.Last + "," + Actual.RightNode.element.Last : (Actual.element.Character == "." && !Actual.RightNode.element.Null) ? Actual.RightNode.element.Last : string.Empty;
                Actual.element.Null = (Actual.element.Character == "*" || Actual.element.Character == "?") ? true : (Actual.element.Character == "|" && (Actual.LeftNode.element.Null || Actual.RightNode.element.Null)) ? true : (Actual.element.Character == "." && Actual.RightNode.element.Null && Actual.LeftNode.element.Null) ? true : (Actual.element.Character == "+" && Actual.element.Null) ? true : false;
            }
        }

        public Dictionary<int, string> TablaFollow(Node Actual, Dictionary<int, string> diccionario, ref int contador)
        {
            if (Actual == null)
            {
                return diccionario;
            }
            diccionario = TablaFollow(Actual.LeftNode, diccionario, ref contador);
            diccionario = TablaFollow(Actual.RightNode, diccionario, ref contador);
            if (Actual.RightNode == null && Actual.LeftNode == null)
            {

            }
            else
            {
                var vector = Actual.LeftNode.element.Last.Split(',');
                if (vector.Length != 0)
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        if (vector[i] != "")
                        {
                            var x = Convert.ToInt32(vector[i]);
                            if (Actual.element.Character == ".")
                            {
                                diccionario[x] = (!diccionario[x].Contains(Actual.RightNode.element.First)) ? diccionario[x] + Actual.RightNode.element.First + "," : diccionario[x];
                            }
                            else
                            {
                                if (Actual.element.Character == "*" || Actual.element.Character == "+")
                                {
                                    diccionario[x] = (!diccionario[x].Contains(Actual.LeftNode.element.First)) ? diccionario[x] + Actual.LeftNode.element.First + "," : diccionario[x];
                                }
                            }
                        }
                    }
                }
            }
            return diccionario;
        }

        public void MostrarFLN(Node Actual, ref List<string[]> matrix)
        {
            if (Actual == null)
            {
                return;
            }
            MostrarFLN(Actual.LeftNode, ref matrix);
            MostrarFLN(Actual.RightNode, ref matrix);
            var aux = new string[4];
            aux[0] = Actual.element.Character;
            aux[1] = Actual.element.First;
            aux[2] = Actual.element.Last;
            aux[3] = Actual.element.Null.ToString();
            matrix.Add(aux);
        }

        public List<string> ObtenerSímbolos(Node Actual, List<string> Lista)
        {
            if (Actual == null)
            {
                return Lista;
            }
            Lista = ObtenerSímbolos(Actual.LeftNode, Lista);
            Lista = ObtenerSímbolos(Actual.RightNode, Lista);
            if (Actual.LeftNode == null && Actual.RightNode == null)
            {
                var Aux = Actual.element.Character;
                if (!Lista.Contains(Aux))
                {
                    Lista.Add(Aux);
                }
            }
            return Lista;
        }

        public Dictionary<string, string[]> Transición(Node Actual, Dictionary<string, string[]> dic, List<string> lista, Dictionary<int, string> follow)
        {
            //revisar los caracteres de la raíz
            var c = new List<string>();
            c = dic.Keys.ToList();
            for (int w = 0; w < c.Count(); w++)
            {
                var contador = 0;
                var matrix = new string[lista.Count()];
                var nuevo = c[w].Split(',');
                foreach (string simbolo in lista)
                {
                    var Aux = string.Empty;
                    var cadena = string.Empty;
                    for (int i = 0; i < nuevo.Length; i++)
                    {
                        cadena = CT(Actual, cadena, simbolo, nuevo[i], follow);
                        Aux = (!Aux.Contains(cadena)) ? Aux + cadena : Aux;
                        cadena = string.Empty;
                    }
                    matrix[contador] = Aux;
                    contador++;
                }
                dic[c[w]] = matrix;
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i] != "")
                    {
                        var ordenar = matrix[i].Split(',');
                        if (ordenar.Length > 1)
                        {
                            var OAux = new int[ordenar.Length];
                            int r = 0;
                            foreach (string cadena in ordenar)
                            {
                                if (cadena != string.Empty)
                                {
                                    OAux[r] = Convert.ToInt32(cadena);
                                    r++;
                                }
                            }
                            for (int o = 1; o < OAux.Length; o++)
                            {
                                for (int t = 0; t < OAux.Length - 1; t++)
                                {
                                    if (OAux[o] < OAux[t])
                                    {
                                        var m = OAux[o];
                                        OAux[o] = OAux[t];
                                        OAux[t] = m;
                                    }
                                }
                            }
                            //eliminar repetidos
                            for (int o = 1; o < OAux.Length; o++)
                            {
                                if (OAux[o - 1] == OAux[o])
                                {
                                    OAux[o - 1] = 0;
                                }
                            }
                            matrix[i] = string.Empty;
                            for (int s = 0; s < OAux.Length; s++)
                            {
                                if (OAux[s] != 0 && !matrix.Contains(Convert.ToString(OAux[s])))
                                {
                                    matrix[i] += OAux[s] + ",";
                                }
                            }
                        }
                        if (!c.Contains(matrix[i]))
                        {
                            c.Add(matrix[i]);
                            dic.Add(matrix[i], null);
                        }
                    }
                }
            }
            return dic;
        }

        public string CT(Node Actual, string cadena, string símbolo, string valor, Dictionary<int, string> follow)
        {
            if (Actual == null)
            {
                return cadena;
            }
            cadena = CT(Actual.LeftNode, cadena, símbolo, valor, follow);
            cadena = CT(Actual.RightNode, cadena, símbolo, valor, follow);
            if (Actual.LeftNode == null && Actual.RightNode == null)
            {
                if (Actual.element.Character == símbolo && Actual.element.First == valor)
                {
                    var Aux = follow[Convert.ToInt32(Actual.element.First)];
                    cadena = (!cadena.Contains(Aux)) ? cadena + Aux : cadena;
                }
            }
            return cadena;
        }
    }
}