using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RoadMaster : MonoBehaviour
{
    public List<RoadNode> Nodes;

    private RoadNode target;
    private SortedList<float, RoadNode> openNodes;
    private HashSet<RoadNode> closedNodes;
    private Dictionary<RoadNode, float> distanceFromStart;
    private Dictionary<RoadNode, RoadNode> predecessors;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public List<RoadNode> GetPath(RoadNode nodeFrom, RoadNode nodeTo)
    {
        target = nodeTo;
        openNodes = new SortedList<float, RoadNode>();
        closedNodes = new HashSet<RoadNode>();
        distanceFromStart = new Dictionary<RoadNode, float>();
        predecessors = new Dictionary<RoadNode, RoadNode>();

        openNodes.Add(0, nodeFrom);

        while (openNodes.Count != 0)
        {
            var currentNode = openNodes[0];
            openNodes.RemoveAt(0);

            if (currentNode == nodeTo)
                return ReconstructPath();

            closedNodes.Add(currentNode);

            ExpandNode(currentNode);
        }

        throw new Exception("No path found");
    }

    private void ExpandNode(RoadNode node)
    {
        foreach (var successor in GetSuccessors(node))
        {
            if (closedNodes.Contains(successor))
                continue;

            float oldDistance;
            distanceFromStart.TryGetValue(node, out oldDistance);

            float newDistance;
            distanceFromStart.TryGetValue(successor, out newDistance);

            newDistance += 1;

            if (openNodes.ContainsValue(successor) && newDistance >= oldDistance)
                continue;

            predecessors[successor] = node;
            distanceFromStart[successor] = newDistance;

            if (openNodes.ContainsValue(successor))
                openNodes.RemoveAt(openNodes.IndexOfValue(successor));

            var cost = newDistance + CalculateLinearDistance(successor, target);
            openNodes.Add(cost, successor);
        }
    }

    private static float CalculateLinearDistance(RoadNode a, RoadNode b)
    {
        return (float)Math.Sqrt(Math.Pow(b.Pos2D.x - a.Pos2D.x, 2) + Math.Pow(b.Pos2D.y - a.Pos2D.y, 2));
    }

    private List<RoadNode> ReconstructPath()
    {
        var path = new List<RoadNode> { target };
        var current = target;
        RoadNode predecessor;

        while (predecessors.TryGetValue(current, out predecessor))
        {
            path.Add(predecessor);
            current = predecessor;
        }

        path.Reverse();
        return path;
    }

    private static IEnumerable<RoadNode> GetSuccessors(RoadNode node)
    {
        return node.Connections.Select(c =>
            c.NodeA = node
                ? c.NodeB
                : c.NodeA)
                    .ToList();
    }

    public bool IsInNetwork(RoadNode node)
    {
        return false;
    }
}
