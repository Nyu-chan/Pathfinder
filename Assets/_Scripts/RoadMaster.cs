using UnityEngine;
using System.Collections.Generic;

public class RoadMaster : MonoBehaviour
{
    public List<RoadNode> Nodes;

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
        return new List<RoadNode>();
    }

    public bool IsInNetwork(RoadNode node)
    {
        return false;
    }
}
