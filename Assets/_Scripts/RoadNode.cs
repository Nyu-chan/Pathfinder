using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadNode : MonoBehaviour
{


    public List<RoadConnection> Connections;
    public Vector2 Pos2D;
    public string ID;
    public RoadMaster Master;  


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Init()
    {
        this.ID = GetInstanceID().ToString() + "@" + Time.frameCount.ToString();
    }
}
