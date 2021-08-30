using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsolaScripting
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            Dictionary<string, Node> _block = new Dictionary<string, Node>();                           // For storing all the nodes with Node.cs
                                                                                                        //private Vector2Int[] _directions = { new Vector2Int(0,1), new Vector2Int(1, 0), new Vector2Int(, 1), new Vector2Int(0, 1) };    // Directions to search in BFS

            List<Node> _path = new List<Node>();            // For storing the path traversed


            Node _startingPoint = new Node(0, 0);
            Node _endingPoint = new Node(3, -1);

            Node[] nodes = new Node[22];
            nodes[0] = _startingPoint;                      //Start

            nodes[1] = new Node(0, -1);
            nodes[2] = new Node(0, -2);
            nodes[3] = new Node(0, -3);
            nodes[4] = new Node(0, -4);
            nodes[5] = new Node(1, -1);
            nodes[6] = new Node(1, -2);
            nodes[7] = new Node(1, -3);
            nodes[8] = new Node(1, -4);
            nodes[9] = new Node(2, 0);
            nodes[10] = new Node(2, -1);
            nodes[11] = new Node(2, -3);
            nodes[12] = new Node(2, -4);
            nodes[13] = new Node(3, 0);
            nodes[14] = _endingPoint;
            nodes[15] = new Node(3, -2);
            nodes[16] = new Node(3, -3);
            nodes[17] = new Node(3, -4);
            nodes[18] = new Node(4, 0);
            nodes[19] = new Node(4, -1);
            nodes[20] = new Node(4, -2);
            nodes[21] = new Node(4, -4);                   //Fin



            SearchPath.LoadAllBlocks(_block, nodes);
            stopwatch.Start();
            SearchPath.GetPath(_startingPoint, _endingPoint, _block, _path);
            stopwatch.Stop();
            Console.WriteLine("Punto de Inicio: " + _startingPoint);
            Console.WriteLine("Punto Final: " + _endingPoint);
            foreach (var item in _path)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Breadth-first search took " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine("Breadth-first search path contains " + _path.Count + " states");
            Console.WriteLine();
        }
    }
}
