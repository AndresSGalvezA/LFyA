using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinalLFA
{
    public class AuxClass
    {
        public void ReadingFile(string File, List<string> StringList, ref List<NodeList> SetsList, ref List<NodeList> TokenList, ref List<NodeList> ActionsList, ref List<NodeList> ErrorList, ref bool sets, ref List<string> TAux, ref List<string> SAux)
        {
            var IsSets = false;
            var IsToken = false;
            var IsActions = false;
            var IsError = false;
            var Counter = 1;
            using (StreamReader Reader = new StreamReader(File))
            {
                var Line = string.Empty;
                
                while ((Line = Reader.ReadLine()) != null)
                {
                    Line = Line.Trim(' ', '\t');
                    if (Line != "") StringList.Add(Line);
                    Line = string.Empty;
                }

                //Separación de caracteres por lista.
                foreach (string chain in StringList)
                {
                    var NodeList = new NodeList();
                    if (Counter == 1 && chain != "SETS" && chain != "TOKENS") sets = true;
                    if (chain == "SETS") IsSets = true;
                    else
                    {
                        if (chain == "TOKENS")
                        {
                            IsToken = true;
                            IsSets = false;
                        }
                        else
                        {
                            if (chain == "ACTIONS")
                            {
                                IsActions = true;
                                IsToken = false;
                            }
                            else
                                if (chain.Contains("ERROR"))
                                {
                                    IsError = true;
                                    IsActions = false;
                                }       
                        }
                    }

                    NodeList.Text = chain;
                    NodeList.NLine = Counter;

                    if (IsSets)
                    {
                        SetsList.Add(NodeList);
                        SAux.Add(NodeList.Text);
                    }
                    else
                    {
                        if (IsToken)
                        {
                            TokenList.Add(NodeList);
                            TAux.Add(NodeList.Text);
                        }
                        else
                        {
                            if (IsActions) ActionsList.Add(NodeList);
                            else if (IsError) ErrorList.Add(NodeList);
                        }
                    }

                    Counter++;
                }
            }
        }

        Node CreateNode(string chain)
        {
            var element = new Elements();
            element.Character = chain;
            var TreeNode = new Node(element);
            return TreeNode;
        }

        Stack<Node> LinkNodes(Node Aux, Stack<Node> PS)
        {
            Node AuxN = PS.Pop();
            Aux.LeftNode = AuxN;
            PS.Push(Aux);
            return PS;
        }

        void PopPilaT(ref Stack<Node> PS, ref Stack<char> PT)
        {
            var characterAux = ' ';
            while (characterAux != '(' && PT.Count() != 0)
            {
                characterAux = PT.Pop();

                if (characterAux != '(')
                {
                    Node Right = PS.Pop();
                    Node Left = PS.Pop();
                    var Ref = string.Empty;
                    Ref += characterAux;
                    var TreeSETSNode = CreateNode(Ref);
                    TreeSETSNode.RightNode = Right;
                    TreeSETSNode.LeftNode = Left;
                    PS.Push(TreeSETSNode);
                }
            }
        }

        void PoPPilaT(ref Stack<Node> PS, ref Stack<char> PT, char Aux)
        {
            string Auxiliar = string.Empty;
            Auxiliar += PT.Pop();
            var TreeSETSNode = CreateNode(Auxiliar);
            Node Right = PS.Pop();
            Node Left = PS.Pop();
            TreeSETSNode.RightNode = Right;
            TreeSETSNode.LeftNode = Left;
            PS.Push(TreeSETSNode);
            PT.Push(Aux);
        }

        public Node CreateTree(string ExpSets)
        {
            var T = "(.|+?*)";
            var PT = new Stack<char>();
            var PS = new Stack<Node>();

            foreach (char caracter in ExpSets)
            {
                if (!T.Contains(caracter))
                {
                    string carct = string.Empty;
                    carct += caracter;
                    var TreeSETSNode = CreateNode(carct);
                    PS.Push(TreeSETSNode);
                }
                else
                {
                    if (caracter == '(') PT.Push(caracter);
                    else
                    {
                        if (caracter == ')') PopPilaT(ref PS, ref PT);
                        else
                        {
                            if (caracter == '*' || caracter == '+' || caracter == '?')
                            {
                                var carct = string.Empty;
                                carct += caracter;
                                var TreeSETSNode = CreateNode(carct);
                                PS = LinkNodes(TreeSETSNode, PS);
                            }
                            else
                            {
                                if (PT.Count() > 0)
                                {
                                    if ((PT.First() == '.' && caracter == '.') || (PT.First() == '|' && caracter == '|'))
                                    {
                                        var carct = ' ';
                                        carct = caracter;
                                        PoPPilaT(ref PS, ref PT, carct);
                                    }
                                    else PT.Push(caracter);
                                }
                                else PT.Push(caracter);
                            }
                        }
                    }
                }
            }
            if (PT.Count != 0) PopPilaT(ref PS, ref PT);
            
            return PS.Pop();
        }

        public Node CreateTreeP2(string Exp)
        {
            var T = "(.|+?*)";
            var PT = new Stack<char>();
            var PS = new Stack<Node>();
            var X = string.Empty;
            var Counter = 0;
            var New = "'";

            for (int i = 0; i < Exp.Length; i++)
            {
                if (Exp[i] == New[0]) Counter++;
                if (T.Contains(Exp[i]) && (Counter % 2 == 0 || Counter == 3))
                {
                    Counter = 0;
                    if (X != string.Empty)
                    {
                        var carct = string.Empty;
                        carct += Exp[i];
                        var TreeSETSNode = CreateNode(X);
                        PS.Push(TreeSETSNode);
                        X = string.Empty;
                    }
                    if (Exp[i] == '(') PT.Push(Exp[i]);
                    else
                    {
                        if (Exp[i] == ')') PopPilaT(ref PS, ref PT);
                        else
                        {
                            if (Exp[i] == '*' || Exp[i] == '+' || Exp[i] == '?')
                            {
                                var carct = string.Empty;
                                carct += Exp[i];
                                var TreeSETSNode = CreateNode(carct);
                                PS = LinkNodes(TreeSETSNode, PS);
                            }
                            else
                            {
                                if (PT.Count() > 0)
                                {
                                    while (PT.Count() > 0)
                                    {
                                        if ((PT.First() == '.' && Exp[i] == '.') || (PT.First() == '|' && Exp[i] == '|') || (PT.First() == '.' && Exp[i] == '|'))
                                        {
                                            var carcter = ' ';
                                            carcter = Exp[i];
                                            PoPPilaTP2(ref PS, ref PT);
                                        }
                                        else
                                        {
                                            PT.Push(Exp[i]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else X += Exp[i];
            }

            return PS.Pop();
        }

        void PoPPilaTP2(ref Stack<Node> PS, ref Stack<char> PT)
        {
            string Auxiliar = string.Empty;
            Auxiliar += PT.Pop();
            var TreeSETSNode = CreateNode(Auxiliar);
            Node Right = PS.Pop();
            Node Left = PS.Pop();
            TreeSETSNode.RightNode = Right;
            TreeSETSNode.LeftNode = Left;
            PS.Push(TreeSETSNode);
        }
    }
}