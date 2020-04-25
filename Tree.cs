using System.Linq;

namespace FinalLFA
{
    public struct Elements
    {
        public string Character;
        public string First;
        public string Last;
        public bool Null;
    }
    
    public class Node
    {
        public Elements element;
        public Node LeftNode;
        public Node RightNode;
        
        public Node(Elements elementos)
        {
            element = elementos;
            LeftNode = null;
            RightNode = null;
        }
    }
    
    public class Tree
    {
        public Node Root;
        
        public void RoadSets(Node ActualNode, Node Root, Node AuxParent, bool Find, ref string Text, ref string Continue, string A, char B, string C, string D, string E, string F, string G, string H, string J, string L, string M, string N, string Ñ, string O, string Q, string R, string S, string T, string P, ref int Quantity)
        {
            if (ActualNode == null) return;
            RoadSets(ActualNode.LeftNode, Root, AuxParent, Find, ref Text, ref Continue, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref Quantity);
            var X = false;
            FindParent(ActualNode, Root, ref AuxParent, ref X);
            var Counter = 0;
            
            if (Text.Length != 0)
            {
                switch (AuxParent.element.Character)
                {
                    case "+":
                        if (Text.Length != 0)
                        {
                            if (AuxParent.LeftNode.element.Character == "." && Continue == "PCSP")
                            {
                            }
                            else
                            {
                                if (ActualNode.LeftNode == null && ActualNode.RightNode == null)
                                {
                                    do
                                    {
                                        Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                                        
                                        if (Find == true)
                                        {
                                            Text = Text.Substring(1);
                                            Counter++;
                                        }

                                        if (Text.Length == 0) break;
                                    }
                                    while (Find == true);

                                    Continue = (Counter >= 1) ? "PC" : "NPC";
                                }
                            }
                        }
                        break;
                    case "*":
                        do
                        {
                            Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 0) ? "PC" : "NPC";
                        break;
                    case ".":
                        if (ActualNode.element.Character == "=")
                        {
                            Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }

                            Continue = (Counter == 1) ? "PC" : "NPC";
                        }
                        break;
                    case "|":
                        if (Continue != "PCSP" && ActualNode.element.Character != "|")
                        {
                            var Aux = string.Empty;

                            do
                            {
                                if (C.Length != 0 && D.Length != 0 && F.Length != 0 && G.Length != 0 && H.Length != 0 && J.Length != 0 && L.Length != 0 && M.Length != 0 && Ñ.Length != 0 && O.Length != 0 && Q.Length != 0 && R.Length != 0 && R.Length != 0 && S.Length != 0 && T.Length != 0) Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                                else break;
                                
                                if (Find)
                                {
                                    Aux += Text[0];
                                    Text = Text.Substring(1);
                                }

                                if (Text.Length == 0) break;
                            }

                            while (Find == true && (C.Length != 0 && D.Length != 0 && F.Length != 0 && G.Length != 0 && H.Length != 0 && J.Length != 0 && L.Length != 0 && M.Length != 0 && Ñ.Length != 0 && O.Length != 0 && Q.Length != 0 && R.Length != 0 && R.Length != 0 && S.Length != 0 && T.Length != 0));
                            Continue = ((C.Length == 0 || D.Length == 0 || F.Length == 0 || G.Length == 0 || H.Length == 0 || J.Length == 0 || L.Length == 0 || M.Length == 0 || Ñ.Length == 0 || O.Length == 0 || Q.Length == 0 || R.Length == 0 || R.Length == 0 || S.Length == 0 || T.Length == 0)) ? "PCSP" : "NPC";
                            Quantity = Continue == "PCSP" ? Quantity + 1 : Quantity;
                            
                            if (Continue == "NPC" && ActualNode.element.Character != "G")
                            {
                                Text = Aux + Text;
                                Continue = "PC";
                            }
                        }
                        break;
                    case "?":
                        Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                        
                        if (Find)
                        {
                            Text = Text.Substring(1);
                            Counter++;
                        }

                        if (Text.Length > 1) Continue = (Counter == 1) ? "PC" : "NPC";
                        else Continue = (Counter == 1) ? "NPC" : "PC";
                        break;
                }
            }
            else return;

            if (Continue == "PC" || Continue == "PCSP")
            {
                RoadSets(ActualNode.RightNode, Root, AuxParent, Find, ref Text, ref Continue, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref Quantity);
                
                if (ActualNode.element.Character == "+" && Text.Length != 0 && ActualNode.LeftNode.element.Character == ".")
                {
                    while (Text.Length != 0 && (Continue == "PC" || Continue == "PCSP"))
                    {
                        RoadSets(ActualNode.LeftNode, Root, AuxParent, Find, ref Text, ref Continue, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref Quantity);
                    }
                }
            }
            else return;
        }
        
        public void RoadTokens(Node ActualNode, Node AuxParent, bool Find, ref string Text, ref string Continue, string K, char B, string N, string U, string A, string W, string I, string V, ref int Quantity, ref int contp, ref int contll)
        {
            if (ActualNode == null) return;
            RoadTokens(ActualNode.LeftNode, AuxParent, Find, ref Text, ref Continue, K, B, N, U, A, W, I, V, ref Quantity, ref contp, ref contll);
            var R = false;
            FindParent(ActualNode, Root, ref AuxParent, ref R);
            var Counter = 0;

            if (Text.Length != 0)
            {
                switch (AuxParent.element.Character)
                {
                    case ".":
                        if (ActualNode.element.Character == "K")
                        {
                            do
                            {
                                if (K != string.Empty) Find = FindCharacterAuxTokens(ActualNode.element.Character, Text[0], K, B, N, ref U, A, W, I, V);
                                else break;
                                
                                if (Find)
                                {
                                    Text = Text.Substring(1);
                                    K = K.Substring(1);
                                    Counter++;
                                }
                            }
                            while (Find == true);
                            
                            Continue = (Counter == 5) ? "PC" : "NPC";
                        }
                        else
                        {
                            if (ActualNode.element.Character == "=")
                            {
                                Find = FindCharacterAuxTokens(ActualNode.element.Character, Text[0], K, B, N, ref U, A, W, I, V/*,ref Z, ref Y*/);
                                
                                if (Find)
                                {
                                    Text = Text.Substring(1);
                                    Counter++;
                                }

                                Continue = (Counter == 1) ? "PC" : "NPC";
                            }
                        }
                        break;
                    case "+":
                        if (ActualNode.element.Character != "|")
                        {
                            do
                            {
                                Find = FindCharacterAuxTokens(ActualNode.element.Character, Text[0], K, B, N, ref U, A, W, I, V/*, ref Z , ref Y*/);
                                
                                if (Find)
                                {
                                    Text = Text.Substring(1);
                                    Counter++;
                                }
                            }
                            while (Find == true);
                            
                            Continue = (Counter >= 1) ? "PC" : "NPC";
                        }
                        break;
                    case "*":
                        do
                        {
                            Find = FindCharacterAuxTokens(ActualNode.element.Character, Text[0], K, B, N, ref U, A, W, I, V/*, ref Z, ref Y*/);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 0) ? "PC" : "NPC";
                        break;
                    case "|":
                        if (ActualNode.element.Character != "|")
                        {
                            var Aux = string.Empty;
                            
                            if (ActualNode.element.Character == "U")
                            {
                                do
                                {
                                    if (U.Length != 0) Find = FindCharacterAuxTokens(ActualNode.element.Character, Text[0], K, B, N, ref U, A, W, I, V);
                                    else break;

                                    if (Find)
                                    {
                                        Aux += Text[0];
                                        Text = Text.Substring(1);
                                        Counter++;
                                    }

                                    if (Text.Length == 0) break;
                                }
                                while (Find == true && U.Length != 0);
                                
                                Continue = ((U.Length == 0)) ? "PCSP" : "NPC";
                                Quantity = Continue == "PCSP" ? Quantity + 1 : Quantity;
                            }
                            else
                            {
                                if (Continue != "PCSP")
                                {
                                    do
                                    {
                                        Find = FindCharacterAuxTokens(ActualNode.element.Character, Text[0], K, B, N, ref U, A, W, I, V);
                                        
                                        if (Find)
                                        {
                                            contp = (Text[0] == '(' || Text[0] == ')') ? contp + 1 : contp;
                                            contll = (Text[0] == '{' || Text[0] == '}') ? contll + 1 : contll;
                                            Aux += Text[0];
                                            Text = Text.Substring(1);
                                            Counter++;
                                        }
                                        
                                        if (Text.Length == 0) break;
                                    }
                                    while (Find == true);
                                    
                                    Continue = ((Counter >= 1)) ? "PCSP" : "NPC";
                                    Quantity = Continue == "PCSP" ? Quantity + 1 : Quantity;
                                }
                            }
                            
                            if (Continue == "NPC" && ActualNode.element.Character != "W")
                            {
                                Text = Aux + Text;
                                Continue = "PC";
                            }
                        }
                        break;
                }
            }
            
            if (Continue == "PC" || Continue == "PCSP")
            {
                RoadTokens(ActualNode.RightNode, AuxParent, Find, ref Text, ref Continue, K, B, N, U, A, W, I, V, ref Quantity, ref contp, ref contll);
                
                if (ActualNode.element.Character == "+" && Text.Length != 0 && ActualNode.LeftNode.element.Character == "|")
                {
                    while (Text.Length != 0 && (Continue == "PC" || Continue == "PCSP"))
                    {
                        RoadTokens(ActualNode.LeftNode, AuxParent, Find, ref Text, ref Continue, K, B, N, U, A, W, I, V, ref Quantity, ref contp, ref contll);
                    }
                }
            }
            else return;
        }
        
        public void RoadActions(Node ActualNode, Node AuxParent, bool Find, ref string Text, ref string Continue, string N, char B, string A, ref int Quantity)
        {
            if (ActualNode == null) return;
            RoadActions(ActualNode.LeftNode, AuxParent, Find, ref Text, ref Continue, N, B, A, ref Quantity);
            var R = false;
            FindParent(ActualNode, Root, ref AuxParent, ref R);
            var Counter = 0;
            
            if (Text != string.Empty)
            {
                switch (AuxParent.element.Character)
                {
                    case ".":
                        if (ActualNode.element.Character == "=")
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }

                            Continue = (Counter == 1) ? "PC" : "NPC";
                        }
                        else
                        {
                            if (ActualNode.element.Character == "'")
                            {
                                Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                                
                                if (Find)
                                {
                                    Text = Text.Substring(1);
                                    Counter++;
                                }

                                Continue = (Counter == 1) ? "PC" : "NPC";
                                Quantity = Continue == "PC" ? Quantity + 1 : Quantity;
                            }
                        }
                        break;
                    case "+":
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                            if (Text.Length == 0) break;
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 1) ? "PC" : "NPC";
                        break;
                    case "*":
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 0) ? "PC" : "NPC";
                        break;
                }
            }

            if (Continue == "PC") RoadActions(ActualNode.RightNode, AuxParent, Find, ref Text, ref Continue, N, B, A, ref Quantity);
            else return;
        }
        
        public void RoadError(Node ActualNode, Node AuxParent, bool Find, ref string Text, ref string Continue, string A, char B, string N, ref int Quantity)
        {
            if (ActualNode == null) return;
            RoadError(ActualNode.LeftNode, AuxParent, Find, ref Text, ref Continue, A, B, N, ref Quantity);
            var R = false;
            FindParent(ActualNode, Root, ref AuxParent, ref R);
            var Counter = 0;
            
            if (Text != string.Empty)
            {
                switch (AuxParent.element.Character)
                {
                    case ".":
                        if (ActualNode.element.Character == "=")
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }

                            Continue = (Counter == 1) ? "PC" : "NPC";
                        }
                        break;
                    case "+":
                        var Aux = string.Empty;
                        
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Aux += Text[0];
                                Text = Text.Substring(1);
                                Counter++;
                            }

                            if (Text.Length == 0) break;
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 1) ? "PC" : "NPC";
                        Quantity = (Continue == "PC" && Text.Length == 0) ? Quantity + 1 : Quantity;
                        if (ActualNode.element.Character == "A") Continue = (Aux[Aux.Length - 1] == 'R' && Aux[Aux.Length - 2] == 'O' && Aux[Aux.Length - 3] == 'R' && Aux[Aux.Length - 4] == 'R' && Aux[Aux.Length - 5] == 'E') ? "PC" : "NPC";
                        break;
                    case "*":
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }

                            if (Text.Length == 0) break;
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 0) ? "PC" : "NPC";
                        break;
                }
            }

            if (Continue == "PC") RoadError(ActualNode.RightNode, AuxParent, Find, ref Text, ref Continue, A, B, N, ref Quantity);
            else return;
        }
        
        private void FindParent(Node ActualNode, Node Parent, ref Node AuxParent, ref bool P)
        {
            if (Parent == null) return;
            FindParent(ActualNode, Parent.LeftNode, ref AuxParent, ref P);
            
            if (Parent.LeftNode == ActualNode || Parent.RightNode == ActualNode)
            {
                AuxParent = Parent;
                P = true;
            }

            if (!P) FindParent(ActualNode, Parent.RightNode, ref AuxParent, ref P);
            else return;
        }
        
        public void RoadS(Node ActualNode, Node Root, Node AuxParent, bool Find, ref string Text, ref string Continue, string A, char B, string C, string D, string E, string F, string G, string H, string J, string L, string M, string N, string Ñ, string O, string Q, string R, string S, string T, string P, ref int Quantity)
        {
            if (ActualNode == null) return;
            RoadS(ActualNode.LeftNode, Root, AuxParent, Find, ref Text, ref Continue, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref Quantity);
            var X = false;
            FindParent(ActualNode, Root, ref AuxParent, ref X);
            var Counter = 0;
            
            if (ActualNode.RightNode == null && ActualNode.LeftNode == null && Text.Length != 0)
            {
                switch (AuxParent.element.Character)
                {
                    case "+":
                        do
                        {
                            Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                            
                            if (Find == true)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }

                            if (Text.Length == 0) break;
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 1) ? "PC" : "NPC";
                        break;
                    case "*":
                        do
                        {
                            Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 0) ? "PC" : "NPC";
                        break;
                    case ".":
                        Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                        
                        if (Find)
                        {
                            Text = Text.Substring(1);
                            Counter++;
                        }
                        
                        Continue = (Counter == 1) ? "PC" : "NPC";
                        break;
                    case "|":
                        if (Continue != "PCSP" && ActualNode.element.Character != "|")
                        {
                            var Aux = string.Empty;
                            
                            do
                            {
                                if (C.Length != 0 && D.Length != 0 && F.Length != 0 && G.Length != 0 && H.Length != 0 && J.Length != 0 && L.Length != 0 && M.Length != 0 && Ñ.Length != 0 && O.Length != 0 && Q.Length != 0 && R.Length != 0 && R.Length != 0 && S.Length != 0 && T.Length != 0) Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                                else break;
                                
                                if (Find)
                                {
                                    Aux += Text[0];
                                    Text = Text.Substring(1);
                                }
                                
                                if (Text.Length == 0) break;
                            }
                            while (Find == true && (C.Length != 0 && D.Length != 0 && F.Length != 0 && G.Length != 0 && H.Length != 0 && J.Length != 0 && L.Length != 0 && M.Length != 0 && Ñ.Length != 0 && O.Length != 0 && Q.Length != 0 && R.Length != 0 && R.Length != 0 && S.Length != 0 && T.Length != 0));
                            
                            Continue = ((C.Length == 0 || D.Length == 0 || F.Length == 0 || G.Length == 0 || H.Length == 0 || J.Length == 0 || L.Length == 0 || M.Length == 0 || Ñ.Length == 0 || O.Length == 0 || Q.Length == 0 || R.Length == 0 || R.Length == 0 || S.Length == 0 || T.Length == 0)) ? "PCSP" : "NPC";
                            Quantity = Continue == "PCSP" ? Quantity + 1 : Quantity;
                            
                            if (Continue == "NPC" && ActualNode.element.Character != "G")
                            {
                                Text = Aux + Text;
                                Continue = "PC";
                            }
                        }
                        break;
                    case "?":
                        Find = FindCharacterAux(ActualNode.element.Character, Text[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                        
                        if (Find)
                        {
                            Text = Text.Substring(1);
                            Counter++;
                        }
                        
                        if (Text.Length > 1) Continue = (Counter == 1) ? "PC" : "NPC";
                        else Continue = (Counter == 1) ? "NPC" : "PC";
                        break;
                }
            }
            
            if (Continue == "PC" || Continue == "PCSP")
            {
                RoadS(ActualNode.RightNode, Root, AuxParent, Find, ref Text, ref Continue, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref Quantity);
                
                if (ActualNode.element.Character == "+" && Text.Length != 0 && ActualNode.LeftNode.element.Character == "." && Continue != "NPC")
                {
                    while (Text.Length != 0 && (Continue == "PC" || Continue == "PCSP"))
                    {
                        RoadS(ActualNode.LeftNode, Root, AuxParent, Find, ref Text, ref Continue, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref Quantity);
                    }
                }
            }
            else return;
        }
        
        public void RoadA(Node ActualNode, Node AuxParent, bool Find, ref string Text, ref string Continue, string N, char B, string A, ref int Quantity)
        {
            if (ActualNode == null) return;
            RoadA(ActualNode.LeftNode, AuxParent, Find, ref Text, ref Continue, N, B, A, ref Quantity);
            var R = false;
            FindParent(ActualNode, Root, ref AuxParent, ref R);
            var Counter = 0;
            
            if (Text != string.Empty && ActualNode.RightNode == null && ActualNode.LeftNode == null)
            {
                switch (AuxParent.element.Character)
                {
                    case ".":
                        Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                        
                        if (Find)
                        {
                            Text = Text.Substring(1);
                            Counter++;
                        }

                        Continue = (Counter == 1) ? "PC" : "NPC";
                        if (ActualNode.element.Character == "'") Quantity = Continue == "PC" ? Quantity + 1 : Quantity;
                        break;
                    case "+":
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                            if (Text.Length == 0) break;
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 1) ? "PC" : "NPC";
                        break;
                    case "*":
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 0) ? "PC" : "NPC";
                        break;
                }
            }
            
            if (Continue == "PC") RoadA(ActualNode.RightNode, AuxParent, Find, ref Text, ref Continue, N, B, A, ref Quantity);
            else return;
        }
        
        public void RoadE(Node ActualNode, Node AuxParent, bool Find, ref string Text, ref string Continue, string A, char B, string N, ref int Quantity)
        {
            if (ActualNode == null) return;
            RoadE(ActualNode.LeftNode, AuxParent, Find, ref Text, ref Continue, A, B, N, ref Quantity);
            var R = false;
            FindParent(ActualNode, Root, ref AuxParent, ref R);
            var Counter = 0;
            
            if (Text != string.Empty && ActualNode.RightNode == null && ActualNode.LeftNode == null)
            {
                switch (AuxParent.element.Character)
                {
                    case ".":
                        Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                        
                        if (Find)
                        {
                            Text = Text.Substring(1);
                            Counter++;
                        }

                        Continue = (Counter == 1) ? "PC" : "NPC";
                        break;
                    case "+":
                        var Aux = string.Empty;
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Aux += Text[0];
                                Text = Text.Substring(1);
                                Counter++;
                            }

                            if (Text.Length == 0) break;
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 1) ? "PC" : "NPC";
                        Quantity = (Continue == "PC" && Text.Length == 0) ? Quantity + 1 : Quantity;
                        if (ActualNode.element.Character == "A") Continue = (Aux[Aux.Length - 1] == 'R' && Aux[Aux.Length - 2] == 'O' && Aux[Aux.Length - 3] == 'R' && Aux[Aux.Length - 4] == 'R' && Aux[Aux.Length - 5] == 'E') ? "PC" : "NPC";
                        break;
                    case "*":
                        do
                        {
                            Find = FindCharacterAuxG(ActualNode.element.Character, Text[0], N, B, A);
                            
                            if (Find)
                            {
                                Text = Text.Substring(1);
                                Counter++;
                            }
                            
                            if (Text.Length == 0) break;
                        }
                        while (Find == true);
                        
                        Continue = (Counter >= 0) ? "PC" : "NPC";
                        break;
                }
            }
            
            if (Continue == "PC") RoadE(ActualNode.RightNode, AuxParent, Find, ref Text, ref Continue, A, B, N, ref Quantity);
            else return;
        }
        
        private bool FindCharacterAux(string Chain, char Character, string A, char B, ref string C, ref string D, string E, ref string F, ref string G, ref string H, ref string J, ref string L, ref string M, string N, ref string Ñ, ref string O, ref string Q, ref string R, ref string S, ref string T, string P)
        {
            var Found = false;
            
            switch (Chain)
            {
                case "A":
                    Found = A.Contains(Character) ? true : false;
                    break;
                case "B":
                    Found = B.Equals(Character) ? true : false;
                    
                    if (!Found) Found = ("    \t".Contains(Character)) ? true : false;
                    break;
                case "=":
                    Found = ('=' == Character) ? true : false;
                    break;
                case "C":
                    Found = C[0] == Character ? true : false;
                    
                    if (Found) C = C.Substring(1);
                    else
                    {
                        if (C[0] == 'E')
                        {
                            Found = E.Contains(Character) ? true : false;
                            C = C.Substring(1);
                        }
                    }
                    break;
                case "D":
                    Found = D[0] == Character ? true : false;
                    
                    if (Found) D = D.Substring(1);
                    else
                    {
                        if (D[0] == 'E')
                        {
                            Found = E.Contains(Character) ? true : false;
                            D = D.Substring(1);
                        }
                    }
                    break;
                case "F":
                    Found = F[0] == Character ? true : false;
                    
                    if (Found) F = F.Substring(1);
                    else
                    {
                        if (F[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            F = F.Substring(1);
                        }
                    }
                    break;
                case "G":
                    Found = G[0] == Character ? true : false;
                    
                    if (Found) G = G.Substring(1);
                    else
                    {
                        if (G[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            G = G.Substring(1);
                        }
                    }
                    break;
                case "H":
                    Found = H[0] == Character ? true : false;
                    
                    if (Found) H = H.Substring(1);
                    else
                    {
                        if (H[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            H = H.Substring(1);
                        }
                    }
                    break;
                case "J":
                    Found = J[0] == Character ? true : false;
                    
                    if (Found) J = J.Substring(1);
                    else
                    {
                        if (J[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            J = J.Substring(1);
                        }
                    }
                    break;
                case "L":
                    Found = L[0] == Character ? true : false;
                    
                    if (Found) L = L.Substring(1);
                    else
                    {
                        if (L[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            L = L.Substring(1);
                        }
                    }
                    break;
                case "M":
                    Found = M[0] == Character ? true : false;
                    
                    if (Found) M = M.Substring(1);
                    else
                    {
                        if (M[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            M = M.Substring(1);
                        }
                    }
                    break;

                case "Ñ":
                    Found = Ñ[0] == Character ? true : false;
                    
                    if (Found) Ñ = Ñ.Substring(1);
                    else
                    {
                        if (Ñ[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            Ñ = Ñ.Substring(1);
                        }
                    }
                    break;
                case "O":
                    Found = O[0] == Character ? true : false;
                    
                    if (Found) O = O.Substring(1);
                    else
                    {
                        if (O[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            O = O.Substring(1);
                        }
                    }
                    break;
                case "Q":
                    Found = Q[0] == Character ? true : false;
                    
                    if (Found) Q = Q.Substring(1);
                    else
                    {
                        if (Q[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            Q = Q.Substring(1);
                        }
                    }
                    break;
                case "R":
                    Found = R[0] == Character ? true : false;
                    
                    if (Found) R = R.Substring(1);
                    else
                    {
                        if (R[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            R = R.Substring(1);
                        }
                    }
                    break;
                case "S":
                    Found = S[0] == Character ? true : false;
                    
                    if (Found) S = S.Substring(1);
                    else
                    {
                        if (S[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            S = S.Substring(1);
                        }
                    }
                    break;
                case "T":
                    Found = T[0] == Character ? true : false;
                    
                    if (Found) T = T.Substring(1);
                    else
                    {
                        if (T[0] == 'N')
                        {
                            Found = N.Contains(Character) ? true : false;
                            T = T.Substring(1);
                        }
                    }
                    break;
                case "P":
                    Found = P.Contains(Character) ? true : false;
                    break;
            }
            
            return Found;
        }
        
        private bool FindCharacterAuxTokens(string Chain, char Character, string K, char B, string N, ref string U, string A, string W, string I, string V)
        {
            var Found = false;
            
            switch (Chain)
            {
                case "K":
                    Found = (K[0] == Character) ? true : false;
                    break;
                case "B":
                    Found = B.Equals(Character) ? true : false;
                    if (!Found) Found = ("    \t".Contains(Character)) ? true : false;
                    break;
                case "N":
                    Found = N.Contains(Character) ? true : false;
                    break;
                case "V":
                    Found = V.Contains(Character) ? true : false;
                    break;
                case "=":
                    Found = ('=' == Character) ? true : false;
                    break;
                case "U":
                    Found = U.Contains(Character) ? true : false;
                    
                    if (Found) U = U.Substring(1);
                    else
                    {
                        if (U[0] == 'I')
                        {
                            Found = I.Contains(Character) ? true : false;
                            U = U.Substring(1);
                        }
                    }
                    break;
                case "W":
                    Found = W.Contains(Character) ? true : false;
                    break;
                case "A":
                    Found = A.Contains(Character) ? true : false;
                    break;
            }

            return Found;
        }

        private bool FindCharacterAuxG(string Chain, char Character, string N, char B, string A)
        {
            var Found = false;
            
            switch (Chain)
            {
                case "N":
                    Found = (N.Contains(Character)) ? true : false;
                    break;
                case "B":
                    Found = (B.Equals(Character)) ? true : false;
                    if (!Found) Found = ("    \t".Contains(Character)) ? true : false;
                    break;
                case "=":
                    Found = ('=' == Character) ? true : false;
                    break;
                case "'":
                    Found = ("'".Contains(Character)) ? true : false;
                    break;
                case "A":
                    Found = (A.Contains(Character)) ? true : false;
                    break;
            }

            return Found;
        }
    }
}