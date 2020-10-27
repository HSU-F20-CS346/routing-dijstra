using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingDijkstra
{
    public class NetworkPath
    {
        public int Weight { get; set; }

        public List<NetworkNode> Path { get; set; }
    }

    public class NetworkPathComparer : IComparer<NetworkPath>
    {
        public int Compare(NetworkPath x, NetworkPath y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }
}
