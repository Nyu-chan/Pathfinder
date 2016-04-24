using UnityEngine;
using System.Collections.Generic;

public class RoadNode : MonoBehaviour
{
    public List<RoadConnection> Connections;
    public Vector2 Pos2D;
    public string ID;
    public RoadMaster Master;

    // Use this for initialization
    private void Start () {
	
	}

    // Update is called once per frame
    private void Update () {
	
	}

    public void Init()
    {
        ID = GetInstanceID() + "@" + Time.frameCount;
    }
}
