using System;
using System.Collections.Generic;

namespace RoutingDijkstra
{
    class Program
    {


        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.GenerateGraph(1000);
            int distance = graph.CalculateShortestPath(graph["A"], graph["Z"]);
        }
    }
}
