using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingDijkstra
{
    public class NetworkNode
    {
        public string Name { get; set; }
        public Dictionary<string, int> Connections { get; set; }
        public NetworkNode()
        {
            Connections = new Dictionary<string, int>();
        }
        public void Connect(string nodeName, int weight)
        {
            if (Connections.ContainsKey(nodeName) == false)
            {
                Connections.Add(nodeName, weight);
            }
            else
            {
                Connections[nodeName] = weight;
            }
        }
    }
}
