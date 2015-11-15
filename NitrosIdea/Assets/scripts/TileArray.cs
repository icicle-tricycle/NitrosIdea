using UnityEngine;
using System.Collections;

public class TileArray : MonoBehaviour {

	private GameObject[,] grid;

	// Use this for initialization
	void Start () {
		grid = new GameObject[12, 12];
		TakeGridFromScene ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void AddTile(GameObject t){
		for (int i = 0; i < grid.GetLength(0); i++) {
			for(int j = 0; j < grid.GetLength (1); j++){
				if(grid[i,j] = null){
					grid[i,j] = t;
				}
			}
		}
	}
	GameObject[,] GetGrid{get { return grid;} }
	void MakeGrid(){
		//TODO finish this method
	}
	void TakeGridFromScene(){
		GameObject[] temp = GameObject.FindGameObjectsWithTag ("Tile");
		for (int i = 0; i < temp.Length; i++) {
			AddTile(temp[i]);
		}
	}
}
