using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{

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
    [SerializeField] float destroyTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
                    plusProjectile up, down, left, right;
                    GameObject proj;
                    proj = Instantiate(projectile);
                    up = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer);
 
                    up.Up();
                    up.ignore = ignore;
                    up.transform.position = new Vector3 (this.transform.position.x,this.transform.position.y + .5f,this.transform.position.z);

                    proj = Instantiate(projectile);
                    down = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer); 

                    down.Down();
                    down.ignore = ignore;
                    down.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);

                    proj = Instantiate(projectile);
                    left = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer); 

                    left.Left();
                    left.ignore = ignore;
                    left.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);

                    proj = Instantiate(projectile);
                    right = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer); 

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
