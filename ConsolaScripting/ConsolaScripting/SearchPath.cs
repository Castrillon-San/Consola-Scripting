using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaScripting
{
    public class Node
    {
        public bool isExplored = false;
        public Node isExploredFrom = null;
        public int X { get; set; }
        public int Y { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string GetPos()
        {
            string pos = X + "," + Y;
            return pos;
        }
        public override string ToString()
        {
            return X + "," + Y;
        }
    }


    class SearchPath
    {

        // For getting all nodes with Node.cs and storing them in the dictionary
        public static void LoadAllBlocks(Dictionary<string, Node> _block, Node[] nodes)
        {

            foreach (Node node in nodes)
            {

                string gridPos = node.ToString();

                // For checking if 2 nodes are in same position; i.e overlapping nodes
                if (_block.ContainsKey(gridPos))
                {
                    Console.WriteLine("2 Nodes present in same position. i.e nodes overlapped.");
                }
                else
                {
                    _block.Add(gridPos, node);        // Add the position of each node as key and the Node as the value
                }
            }


        }

        public static void GetPath(Node _startingPoint, Node _endingPoint, Dictionary<string, Node> _block, List<Node> _path)
        {
            BFS(_startingPoint, _endingPoint, _block);
            CreatePath(_startingPoint, _endingPoint, _path, _block);

        }

        // BFS; For finding the shortest path
        private static void BFS(Node _startingPoint, Node _endingPoint, Dictionary<string, Node> _block)
        {

            Node _searchingPoint = null;                           // Current node we are searching
            bool _isExploring = true;                       // If we are end then it is set to false

            Queue<Node> _queue = new Queue<Node>();         // Queue for enqueueing nodes and traversing through them
            string neighbourPos = "";

            _queue.Enqueue(_startingPoint);
            while (_queue.Count > 0 && _isExploring)
            {
                _searchingPoint = _queue.Dequeue();
                OnReachingEnd(_searchingPoint, _isExploring, _endingPoint);
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        int sum = _searchingPoint.Y + 1;
                        neighbourPos = _searchingPoint.X + "," + sum;
                    }
                    else if (i == 1)
                    {
                        int sum = _searchingPoint.X + 1;
                        neighbourPos = sum + "," + _searchingPoint.Y;

                    }
                    else if (i == 2)
                    {
                        int sum = _searchingPoint.Y - 1;
                        neighbourPos = _searchingPoint.X + "," + sum;

                    }
                    else if (i == 3)
                    {
                        int sum = _searchingPoint.X - 1;
                        neighbourPos = sum + "," + _searchingPoint.Y;

                    }
                    if (_block.ContainsKey(neighbourPos))               // If the explore neighbour is present in the dictionary _block, which contians all the blocks with Node.cs attached
                    {

                        Node node = _block[neighbourPos];

                        if (!node.isExplored)
                        {
                            _queue.Enqueue(node);                       // Enqueueing the node at this position
                            node.isExplored = true;
                            node.isExploredFrom = _searchingPoint;      // Set how we reached the neighbouring node i.e the previous node; for getting the path
                        }
                    }
                }


            }
            if (!_isExploring) { return; }


        }


        // To check if we've reached the Ending point
        private static void OnReachingEnd(Node _searchingPoint, bool _isExploring, Node _endingPoint)
        {
            if (_searchingPoint == _endingPoint)
            {
                _isExploring = false;
            }
            else
            {
                _isExploring = true;
            }
        }

        // Creating path using the isExploredFrom var of each node to get the previous node from where we got to this node
        private static void CreatePath(Node _startingPoint, Node _endingPoint, List<Node> _path, Dictionary<string, Node> _block)
        {


            _path.Add(_endingPoint);

            Node previousNode = _endingPoint.isExploredFrom;
            while (previousNode != _startingPoint)
            {
                _path.Add(previousNode);
                previousNode = previousNode.isExploredFrom;
            }

            _path.Add(_startingPoint);
            _path.Reverse();
        }

        // For adding nodes to the path
        private static void SetPath(Node node, List<Node> _path)
        {
            _path.Add(node);
        }
    }
}

