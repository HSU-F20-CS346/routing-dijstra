using NUnit.Framework;
using RoutingDijkstra;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Ensures that Dijkstra's algorithm is working correctly 
        /// </summary>
        [Test]
        public void ShortestPathTest()
        {
            Graph graph = new Graph();

            //using same seed should always generate the same random results
            graph.GenerateGraph(1000, 0);

            //returns 16
            //graph.CalculateShortestPath(graph["A"], graph["B"]);

            //what we want is the full path so that our routing protocol knows where to send the packet next
            //desired (not true, just example): 
            //A -> P -> D -> B

            Assert.AreEqual(graph.CalculateShortestPath(graph["A"], graph["B"]), 16);
            Assert.AreEqual(graph.CalculateShortestPath(graph["A"], graph["Z"]), 13);
            Assert.AreEqual(graph.CalculateShortestPath(graph["A"], graph["X"]), 12);
        }
    }
}