using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public enum TileType
    {
        basic,
        cardinal,
        diagional,
        pillar,
    };
    /// <summary>
    /// Variable that affects what kind of tile this behaves as
    /// </summary>
    public TileType Type;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
