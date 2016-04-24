using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Rasterizer : MonoBehaviour
{

    public GameObject Tile;
    public GameObject[,] grid = new GameObject[10, 10];  

	// Use this for initialization
	void Start ()
    {
	    PopulateGrid();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    private void PopulateGrid()
    {

        GameObject temp;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                temp = (GameObject) Instantiate(Tile, new Vector3((float) -i, 0f, (float) -j), Quaternion.identity);
                temp.transform.SetParent(this.transform);
                grid[i, j] = temp;
            }
        }

    }
}
