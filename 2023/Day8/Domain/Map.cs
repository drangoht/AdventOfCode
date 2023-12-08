using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Domain
{
    public class Map
    {
        public int PartNumber { get; set; } = 1;
        private List<Node> nodes = new();
        private string path = string.Empty;
        public void ParseLinesToMap(List<string> lines)
        {
            path = lines[0];
            for (int i = 2; i < lines.Count();i++)
            {
                nodes.Add(ConvertLineToNode(lines[i]));
            }
        }
        private Node ConvertLineToNode(string line) 
        {
            
            var arrNode = line.Split(" = ");

            Node node = new Node();
            if (nodes.Any(n => n.Id == arrNode[0]))
                node = nodes.FirstOrDefault(n => n.Id == arrNode[0]);
            else
            {
                node.Id = arrNode[0];
            }
            var arrDirection = arrNode[1].Split(", ");
            node.LeftNodeId = arrDirection[0].Replace("(", "");
            node.RightNodeId = arrDirection[1].Replace(")", "");
            return node;
        }
        public Int64 GetStepsNumberPart1( )
        {
            Int64 cptTotalSteps = 0;
            Node currentNode = new();
            if (nodes.Any(n => n.Id.EndsWith("AAA")))
            {
                currentNode = nodes.First(n => n.Id.EndsWith("AAA"));
                cptTotalSteps = GetTotalStepsByNode(currentNode, "ZZZ");
            }
            return cptTotalSteps;
            
        }
        private Int64 GetTotalStepsByNode(Node currentNode,string end)
        {
            Int64 cptTotalSteps = 0;
            while (!currentNode.Id.EndsWith(end))
            {
                int cptStep = 0;
                while (cptStep < path.Length && !currentNode.Id.EndsWith(end))
                {
                    if (path[cptStep] == 'L')
                        currentNode = nodes.FirstOrDefault(n => n.Id == currentNode.LeftNodeId);
                    if (path[cptStep] == 'R')
                        currentNode = nodes.FirstOrDefault(n => n.Id == currentNode.RightNodeId);
                    cptTotalSteps++;
                    cptStep++;
                }
            }
            return cptTotalSteps;
        }
        public Int64 GetStepsNumberPart2()
        {
            Int64 cptTotalSteps = 0;
            List<Int64> stepsByNode = new List<Int64>();
            List<Task> tasks = new List<Task>();
            List<Node> currentNodes = new();
            if (nodes.Any(n => n.Id.EndsWith("A")))
            {
                currentNodes = nodes.Where(n => n.Id.EndsWith("A")).ToList();

                foreach (var node in currentNodes) 
                {
                    stepsByNode.Add(GetTotalStepsByNode(node, "Z"));
                }
            }

            return stepsByNode.Aggregate((a, b) => Tools.LowestCommonMultiplier(a, b));

        }
        public void Display()
        {
            Console.WriteLine($"Path:{path}");
            foreach (Node node in nodes)
            {
                Console.WriteLine(node.ToString());
            }
        }



    }
}
