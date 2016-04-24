using UnityEngine;

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
}
