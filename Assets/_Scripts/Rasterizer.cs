using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Rasterizer : MonoBehaviour
{
    public GameObject Tile;
    public GameObject[,] Grid = new GameObject[10, 10];

    // Use this for initialization
    private void Start()
    {
        PopulateGrid();
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            int gridCoordX = -1;
            int gridCoordY = -1;
            if (GetGridCoordFromScreenCoord(Input.mousePosition.x, Input.mousePosition.y, out gridCoordX, out gridCoordY))
            {
                Debug.Log(gridCoordX.ToString() + " " + gridCoordY.ToString());
                Grid[gridCoordX, gridCoordY].GetComponent<TileInfo>().SwitchColor();
            }
        }

    }

    private void PopulateGrid()
    {
        for (var i = 0; i < Grid.GetLength(0); i++)
        {
            for (var j = 0; j < Grid.GetLength(1); j++)
            {
                var newTile = (GameObject)Instantiate(Tile, new Vector3(-i, 0f, -j), Quaternion.identity);
                newTile.transform.SetParent(transform);

                Grid[i, j] = newTile;
            }
        }
    }

    private bool GetGridCoordFromScreenCoord(float x, float y, out int gridCoordX, out int gridCoordY)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            gridCoordX = (int)Math.Round(hit.point.x * -1, 0);
            gridCoordY = (int)Math.Round(hit.point.z * -1, 0);

            if (0 <= gridCoordX && gridCoordX <= 9 && 0 <= gridCoordY && gridCoordY <= 9)
            {
                return true;
            }

        }


        gridCoordX = -1;
        gridCoordY = -1;
        return false;
    }
}
