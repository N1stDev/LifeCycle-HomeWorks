
namespace Task2_3
{
    class Node
    {
        public Node[] children;
        public string text;
        public Node(string t)
        {
            children = new Node[100];
            text = t;
        }
    }

    class NodeList
    {
        int rootCounter = 0;
        int count = 0;
        Node[] nodelist;
        string[] resArr;

        public NodeList(int arrSize)
        {
            if (arrSize <= 0)
            {
                throw new Exception("Wrong arr size!");
            }
            nodelist = new Node[arrSize];
        }

        public void AddNode(string newText, string? parentText=null)
        {
            if (parentText == null && rootCounter == 0)
            {
                ArrAppend(nodelist, newText);
                count++;
                rootCounter++;
                return;
            }
            else if (parentText == null && rootCounter != 0)
            {
                throw new Exception("Can't add second root!");
            }

            for (int i = 0; i < count; i++)
            {
                if (nodelist[i].text == parentText)
                {
                    ArrAppend(nodelist[i].children, newText);
                    ArrAppend(nodelist, newText);
                    count++;
                    return;
                }
            }
        }

        void ArrAppend(Node[] arr, string text)
        {
            int i = 0;
            while (arr[i] != null)
            {
                i++;
                if (i == arr.Length)
                {
                    throw new Exception("Max limit of children is achieved!");
                }
            }
            arr[i] = new Node(text);
        }

        int index = 0;
        void BuildTree(Node node, int level = 0, int lastChild=0)
        {
            if (node == null)
            {
                return;
            }

            Node[] children = GetChildren(node.text);
            int childrenLen = GetChildrenLen(children);
            int lc;
            for (int i = childrenLen - 1; i>=0; i--)
            {
                if (i == childrenLen - 1)
                {
                    lc = 1;
                }
                else
                {
                    lc = 0;  
                }
                BuildTree(children[i], level+1, lc);  
            }
            if (index == count - 1)
            {
                resArr[index] = node.text;
            }
            else
            {
                string tabs = "";
                for (int i = 0; i <= level - 2; i++)
                {
                    tabs += "    |";
                }
                tabs += "    ";
                if (lastChild == 1)
                {
                    tabs += "└---";
                }
                else
                {
                    tabs += "├---";
                }
                resArr[index] = tabs + node.text;
                index++;
            }
        }

        int GetChildrenLen(Node[] children)
        {
            int i = 0;
            while (children[i] != null)
            {
                i++;
            }
            return i;
        }

        public void Print()
        {
            resArr = new string[count];
            BuildTree(nodelist[0]);
            PolishTree();

            for (int i=count-1; i>=0; i--)
            {
                Console.WriteLine(resArr[i]);
            }
        }

        void PolishTree()
        {
            for (int i = count-2; i  >= 0; i--)
            {
                for (int j = 0; j < resArr[i].Length; j++)
                {
                    if (resArr[i][j] == '|' && (resArr[i + 1][j] == '└' || resArr[i + 1][j] == ' '))
                    {
                        resArr[i] = resArr[i].Remove(j, 1).Insert(j, " ");
                    }
                }
            }
        }

        Node[] GetChildren(string parentText)
        {
            for (int i = 0; i < count; i++)
            {
                if (parentText == nodelist[i].text)
                {
                    return nodelist[i].children;
                }
            }
            return new Node[0];
        }
    }
}
