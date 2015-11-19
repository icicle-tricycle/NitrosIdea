using UnityEngine;
using System.Collections;

public class TileArray : MonoBehaviour {

    public Tile tile;
    public GameObject Floor;

    [System.NonSerialized]
    public Vector2 BOARDSIZE = new Vector2(12, 12);
    

	private Tile[,] grid;
    public Tile[,] GetGrid { get { return grid; } }

	// Use this for initialization
	void Start () {
        Debug.Log("started");
        grid = new Tile[(int)BOARDSIZE.x, (int)BOARDSIZE.y];
        Floor = GameObject.FindGameObjectWithTag("Floor");
        MakeGrid();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void MakeGrid(){
        Tile temp;
        for (int i = 0; i < BOARDSIZE.x; i++)
        {
            for (int j = 0; j < BOARDSIZE.y; j++)
            {
                if (grid[i, j] = null)
                {
                    temp = Instantiate(tile);
                    temp.transform.position = new Vector3(
                        -4.5f + i * (9 / BOARDSIZE.x),
                        0f,
                        -4.5f + i * (9 / BOARDSIZE.y)
                        );
                    grid[i, j] = temp;
                }
            }
        }
	}

	
}
