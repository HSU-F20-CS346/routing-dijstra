using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingDijkstra
{
    public class Graph
    {
        Dictionary<string, NetworkNode> _graph = new Dictionary<string, NetworkNode>();

        public NetworkNode this[string node]
        {
            get
            {
                return _graph[node];
            }
        }

        public void GenerateGraph(int maxConnections, int seed = 0)
        {
            _graph.Clear();

            Random rng = new Random(seed);
            for (int i = 0; i < maxConnections / 2; i++)
            {
                //generate random upper case char
                char nodeNameAsChar = (char)(65 + rng.Next() % 26);
                string firstNode = nodeNameAsChar.ToString();
                nodeNameAsChar = (char)(65 + rng.Next() % 26);
                string secondNode = nodeNameAsChar.ToString();

                //generate some random weight between 0 and 100
                int weight = rng.Next() % 101;

                //make an association
                if (_graph.ContainsKey(firstNode) == false)
                {
                    _graph.Add(firstNode, new NetworkNode() { Name = firstNode });
                }
                _graph[firstNode].Connect(secondNode, weight);
            }
        }

        /// <summary>
        /// calculates the shortest path between start and end
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public int CalculateShortestPath(NetworkNode start, NetworkNode end)
        {
            //ugly
            PriortyQueue<KeyValuePair<int, NetworkNode>> toVisit = new PriortyQueue<KeyValuePair<int, NetworkNode>>(new KvpComparer());
            Dictionary<string, int> knownPaths = new Dictionary<string, int>();

            toVisit.Enqueue(new KeyValuePair<int, NetworkNode>(0, start));
            while (knownPaths.ContainsKey(end.Name) == false)
            {
                var top = toVisit.Dequeue();
                knownPaths.Add(top.Value.Name, top.Key);
                foreach (var adjacentNode in top.Value.Connections)
                {
                    if (knownPaths.ContainsKey(adjacentNode.Key) == false)
                    {
                        KeyValuePair<int, NetworkNode> next = new KeyValuePair<int, NetworkNode>(
                        top.Key + adjacentNode.Value,
                        _graph[adjacentNode.Key]
                        );
                        toVisit.Enqueue(next);
                    }
                }
            }
            return knownPaths[end.Name];
        }

        /// <summary>
        /// generates a list of the shortest path between start and end
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public List<string> ListShortestPath(NetworkNode start, NetworkNode end)
        {
            //ugly
            PriortyQueue<NetworkPath> toVisit = new PriortyQueue<NetworkPath>(new NetworkPathComparer());
            Dictionary<string, int> knownPaths = new Dictionary<string, int>();


            //TODO: rework previous algorithm
            return new List<string>();
        }


        private class KvpComparer : IComparer<KeyValuePair<int, NetworkNode>>
        {
            public int Compare(KeyValuePair<int, NetworkNode> x, KeyValuePair<int, NetworkNode> y)
            {
                return x.Key.CompareTo(y.Key);
            }
        }
    }
}
