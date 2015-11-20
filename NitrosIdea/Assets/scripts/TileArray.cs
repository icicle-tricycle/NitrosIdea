using UnityEngine;
using System.Collections;

public class TileArray : MonoBehaviour {

    public GameObject tile;
    public GameObject shockTile;
    //public GameObject Floor;

    private Vector2 BOARDSIZE = new Vector2(9, 9);


    private GameObject[,] grid;
    public GameObject[,] GetGrid { get { return grid; } }

	// Use this for initialization
	void Start () {
        Debug.Log("started");
        grid = new GameObject[(int)BOARDSIZE.x, (int)BOARDSIZE.y];
        //Floor = GameObject.FindGameObjectWithTag("Floor");
        MakeGrid();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void MakeGrid(){
        Debug.Log("started make grid");
        GameObject temp;
        for (int i = 0; i < BOARDSIZE.x; i++)
        {
            for (int j = 0; j < BOARDSIZE.y; j++)
            {
                //if (grid[i, j] = null)
                {
                    int rng = Random.Range(0, 2);
                    if (rng == 0)
                    {
                        temp = Instantiate(tile);
                    }
                    else
                    {
                        temp = Instantiate(shockTile);
                    }

                    temp.transform.position = new Vector3(
                        -4f + i * (9 / (BOARDSIZE.x + 0.0f)),
                        0.01f,
                        -4f + j * (9 / (BOARDSIZE.y + 0.0f))
                        );
                    grid[i, j] = temp;
                    temp.transform.parent = this.transform;
                    temp.name = "Tile (" + i + "," + j + ")";
                    Debug.Log("made a tile?");
                }
            }
        }
        Debug.Log("Finished make grid");
    }

	
}
