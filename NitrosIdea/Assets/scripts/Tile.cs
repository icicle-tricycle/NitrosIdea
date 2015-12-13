using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{

    public enum TileType
    {
        Basic,
        Cardinal,
        Diagional,
        Aimed,
        Pillar,
        Shock,
    };
    /// <summary>
    /// Variable that affects what kind of tile this behaves as
    /// </summary>
    public TileType Type;

    [SerializeField] GameObject projectile;
    [SerializeField] float destroyTimer;
    [SerializeField] float useTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FireAttack(PlayerController ignore)
    {
        //Debug.Log("Attacking");
        switch (Type)
        {
            case TileType.Basic:
                {
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
            case TileType.Diagional:
                {
                    plusProjectile ne, nw, se, sw;
                    GameObject proj;

                    proj = Instantiate(projectile);
                    ne = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer);
                    ne.NE();
                    ne.ignore = ignore;
                    ne.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);

                    proj = Instantiate(projectile);
                    nw = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer);
                    nw.NW();
                    nw.ignore = ignore;
                    nw.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);

                    proj = Instantiate(projectile);
                    se = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer);
                    se.SE();
                    se.ignore = ignore;
                    se.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
                    
                    proj = Instantiate(projectile);
                    sw = proj.GetComponent<plusProjectile>();
                    Destroy(proj, destroyTimer);
                    sw.SW();
                    sw.ignore = ignore;
                    sw.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
                    break;
                }
            case TileType.Aimed:
                {
                    GameObject projObj;
                    projObj = Instantiate(projectile);
                    aimProjectile proj = projObj.GetComponent<aimProjectile>();
                    Destroy(projObj, destroyTimer);
                    proj.AimAtOther(ignore);
                    proj.ignore = ignore;
                    proj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
                    break;
                }
            default:
                break;
        }
    
    
    }

    public float getUseTime()
    {
        return useTime;
    }
}
