
namespace Task2_3
{
    class Node
    {
        public List<Node> children = new();
        public string? text;
        public Node(string? t = null)
        {
            text = t;
        }
    }

    class NodeList
    {
        private Node root = new();
        private List<string>? resArr;

        public void Append(string newText, string? parentText = null)
        {
            if (parentText == null)
            {
                root.text = newText;
                return;
            }
            AddNode(root, newText, parentText);
        }

        private void AddNode(Node node, string newText, string? parentText = null)
        {
            if (node.text == parentText)
            {
                node.children.Add(new Node(newText));
                return;
            }

            for (int i = 0; i < node.children.Count; i++)
            {
                AddNode(node.children[i], newText, parentText);
            }
        }

        private void BuildTree(Node node, int level = 0, int lastChild = 0)
        {
            if (node == null)
            {
                return;
            }

            int lc;
            for (int i = node.children.Count - 1; i >= 0; i--)
            {
                if (i == node.children.Count - 1)
                {
                    lc = 1;
                }
                else
                {
                    lc = 0;
                }
                BuildTree(node.children[i], level + 1, lc);
            }
            if (node == root)
            {
                resArr.Add(node.text);
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
                resArr.Add(tabs + node.text);
            }
        }

        public void Print()
        {
            resArr = new();
            BuildTree(root);
            PolishTree();

            for (int i = resArr.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(resArr[i]);
            }
        }

        private void PolishTree()
        {
            for (int i = resArr.Count - 2; i >= 0; i--)
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
    }
}
