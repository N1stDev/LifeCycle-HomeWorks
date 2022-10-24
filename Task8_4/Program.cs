global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;

class Node
{
    public List<Node> greaterNodes;
    public List<Node> lesserNodes;
    public Node()
    {
        greaterNodes = new();
        lesserNodes = new();
    }
}

class NodeList
{
    public bool isDataCorrect = true;

    public Node[] nodes;

    public NodeList(int quantity)
    {
        nodes = new Node[quantity];

        for (int i = 0; i < quantity; i++)
        {
            nodes[i] = new Node();
        }
    }

    public void AddAssumption(int index1, int index2)
    {
        Node greaterNode, lesserNode;
        
        greaterNode = nodes[index1 - 1];
        lesserNode = nodes[index2 - 1];

        greaterNode.lesserNodes.Add(lesserNode);

        if (greaterNode.greaterNodes.Contains(lesserNode) || lesserNode.lesserNodes.Contains(greaterNode))
        {
            isDataCorrect = false;
            return;
        }

        lesserNode.greaterNodes.Add(greaterNode);

        recurse(greaterNode);

        void recurse(Node currentNode)
        {
            List<Node> traverseList;

            foreach (Node n in currentNode.lesserNodes)
            {
                recurse(n);
            }

            if (!isDataCorrect || currentNode.lesserNodes.Contains(greaterNode))
            {
                isDataCorrect = false;
                return;
            }
            currentNode.greaterNodes.Add(greaterNode);
        }
    }
}

class Program
{
    static void Main()
    {
        string[] text = System.IO.File.ReadAllLines("INPUT.TXT");
        
        string[] entries = text[0].Split(' ', StringSplitOptions.None);

        int nodesCount = Convert.ToInt32(entries[0]);
        int assumptionsCount = Convert.ToInt32(entries[1]);

        NodeList nl = new(nodesCount);

        for (int i = 0; i < assumptionsCount; i++)
        {
            entries = text[i + 1].Split(' ', StringSplitOptions.None);

            int index1 = Convert.ToInt32(entries[0]);
            int index2 = Convert.ToInt32(entries[1]);

            nl.AddAssumption(index1, index2);
        }

        if (nl.isDataCorrect)
            Console.WriteLine("Yes");
        else 
            Console.WriteLine("No");
    }
}