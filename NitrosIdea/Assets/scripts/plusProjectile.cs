using UnityEngine;
using System.Collections;

public class plusProjectile : MonoBehaviour {

    public float speed;
    //public string dir;
    public PlayerController ignore;

    public enum Directions
    {
        N = 0,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW
    };
    [SerializeField]
    private Directions dir;
	
	// Update is called once per frame
	void Update () {
        switch (dir)
        {
            case Directions.N:
                {
                    this.transform.position += speed * transform.forward * Time.deltaTime;
                    break;
                }
            case Directions.NE:
                {
                    this.transform.position += speed * new Vector3(.5f, 0, .5f) * Time.deltaTime;
                    break;
                }
            case Directions.E:
                {
                    this.transform.position += speed * transform.right * Time.deltaTime;
                    break;
                }
            case Directions.SE:
                {
                    this.transform.position += speed * new Vector3(.5f, 0, -.5f) * Time.deltaTime;
                    break;
                }
            case Directions.S:
                {
                    this.transform.position += speed * transform.forward * -1 * Time.deltaTime;
                    break;
                }
            case Directions.SW:
                {
                    this.transform.position += speed * new Vector3(-.5f, 0, -.5f) * Time.deltaTime;
                    break;
                }
            case Directions.W:
                {
                    this.transform.position += speed * transform.right * -1 * Time.deltaTime;
                    break;
                }
            case Directions.NW:
                {
                    this.transform.position += speed * new Vector3(-.5f, 0, .5f) * Time.deltaTime;
                    break;
                }
            default:
                {
                    this.transform.position += speed * transform.forward * -1 * Time.deltaTime;
                    break;
                }
        }

	
	}

    public void Up()
    {
        dir = Directions.N;
    }

    public void Down()
    {
        dir = Directions.S;
    }

    public void Left()
    {
        dir = Directions.W;
    }

    public void Right()
    {
        dir = Directions.E;
    }

    public void NE() { dir = Directions.NE; }
    public void NW() { dir = Directions.NW; }
    public void SE() { dir = Directions.SE; }
    public void SW() { dir = Directions.SW; }

    void OnTriggerStay(Collider other)
    {
        if ( other.tag == "Player" && other.gameObject != ignore.gameObject)
        {
            //Debug.Log("dealt damage to " + other.gameObject.transform.name);
            other.gameObject.GetComponent<PlayerController>().TakeDamage(5);
        }
    }
}
