using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;

class Node
{
    public List<Node> greaterNodes;
    public List<Node> lesserNodes;
    public Node()
    {
        greaterNodes = new List<Node>();
        lesserNodes = new List<Node>();
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

        recurse(greaterNode, greaterNode);
    }

    void recurse(Node currentNode, Node greaterNode)
    {
        List<Node> traverseList;

        foreach (Node n in currentNode.lesserNodes)
        {
            recurse(n, greaterNode);
        }

        if (!isDataCorrect || currentNode.lesserNodes.Contains(greaterNode))
        {
            isDataCorrect = false;
            return;
        }
        currentNode.greaterNodes.Add(greaterNode);
    }
}

class Program
{
    static void Main()
    {
        NodeList nl;
        int nodeCount;
        int assumptionsCount;

        using (var reader = System.IO.File.OpenText("INPUT.TXT"))
        {
            int counter = 0;
            string line = reader.ReadLine();

            string[] entries = line.Split(' ');

            nodeCount = Convert.ToInt32(entries[0]);
            assumptionsCount = Convert.ToInt32(entries[1]);

            nl = new NodeList(nodeCount);

            while ((line = reader.ReadLine()) != null)
            {
                entries = line.Split(' ');

                int index1 = Convert.ToInt32(entries[0]);
                int index2 = Convert.ToInt32(entries[1]);

                nl.AddAssumption(index1, index2);
            }
        }

        if (nl.isDataCorrect)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
}