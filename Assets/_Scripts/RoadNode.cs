using System;
using UnityEngine;
using System.Collections.Generic;

public class RoadNode : MonoBehaviour, IEquatable<RoadNode>
{
    public List<RoadConnection> Connections;
    public Vector2 Pos2D;
    public string ID;
    public RoadMaster Master;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void Init()
    {
        ID = GetInstanceID() + "@" + Time.frameCount;
    }

    public bool Equals(RoadNode other)
    {
        return other != null && other.ID == ID;
    }

    public override bool Equals(object obj)
    {
        var other = obj as RoadNode;
        return Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (base.GetHashCode() * 397) ^ (ID != null ? ID.GetHashCode() : 0);
        }
    }
}
