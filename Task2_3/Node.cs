﻿
namespace Task2_3
{
    class Node
    {
        public List<Node> children = new();
        public string text;

        public Node(string t = "none")
        {
            text = t;
        }

        public override string ToString()
        {
            return text;
        }
    }

    class NodeList
    {
        private Node root = new();
        private List<string> resArr = new();

        public void Append(string newText, string parentText = "none")
        {
            if (parentText == "none")
            {
                root.text = newText;
                return;
            }
            AddNode(root, newText, parentText);
        }

        private void AddNode(Node node, string newText, string parentText)
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

        public Node GetNode(string text)
        {
            Node bufferNode = root;
            bool nodeFound = false;

            recurse(bufferNode);

            if (nodeFound)
                return bufferNode;
            return null;

            void recurse(Node foundNode)
            {
                if (foundNode.text == text)
                {
                    bufferNode = foundNode;
                    nodeFound = true;
                    return;
                }

                foreach (Node n in foundNode.children)
                {
                    recurse(n);

                    if (nodeFound) return;
                }
            }
        }

        public bool GetNodeFromArg(string text, out Node node)
        {
            node = GetNode(text);
            if (node == null)
                return false;
            return true;
        }

        public override string ToString()
        {
            string s = "";

            resArr.Clear();
            BuildTree(root);
            PolishTree();

            foreach (string line in resArr)
            {
                s = line + '\n' + s;
            }

            return s;

            void PolishTree()
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
}
