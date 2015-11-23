using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public enum TileType
    {
        Basic,
        Cardinal,
        Diagional,
        Pillar,
        Shock,
    };
    /// <summary>
    /// Variable that affects what kind of tile this behaves as
    /// </summary>
    public TileType Type;

    [SerializeField]
    GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if((transform.position.x < -5) ||
            (transform.position.x > 5) ||
            (transform.position.z > 5) ||
            (transform.position.z < -5)
            )
        {
            Debug.Log("entered destruction check");
            Destroy(this.gameObject);
        }
	
	}

	public void FireAttack(PlayerController ignore)
    {
        Debug.Log("Attacking");
        switch (Type)
        {
            case TileType.Basic:
                {
                    Debug.Log("basic");
                    break;
                }
            case TileType.Cardinal:
                {
                    Debug.Log("Cardinal");
                    plusProjectile up, down, left, right;
                    up = Instantiate(projectile).GetComponent<plusProjectile>();
                    up.Up();
                    up.ignore = ignore;
                    up.transform.position = new Vector3 (this.transform.position.x,this.transform.position.y + .5f,this.transform.position.z);
                    down = Instantiate(projectile).GetComponent<plusProjectile>();
                    down.Down();
                    down.ignore = ignore;
                    down.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
                    left = Instantiate(projectile).GetComponent<plusProjectile>();
                    left.Left();
                    left.ignore = ignore;
                    left.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
                    right = Instantiate(projectile).GetComponent<plusProjectile>();
                    right.Right();
                    right.ignore = ignore;
                    right.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
                    break;
                }
            default:
                break;
        }
    
    
    }
}
