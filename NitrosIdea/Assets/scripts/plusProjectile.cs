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
    public Directions dir;
	
	// Update is called once per frame
	void Update () {
        switch (dir)
        {
            case Directions.N:
                {
                    this.transform.position += speed * transform.forward;
                    break;
                }
            case Directions.NE:
                {
                    this.transform.position += speed * new Vector3(.5f, 0, .5f);
                    break;
                }
            case Directions.E:
                {
                    this.transform.position += speed * transform.right;
                    break;
                }
            case Directions.SE:
                {
                    this.transform.position += speed * new Vector3(.5f, 0, -.5f);
                    break;
                }
            case Directions.S:
                {
                    this.transform.position += speed * transform.forward * -1;
                    break;
                }
            case Directions.SW:
                {
                    this.transform.position += speed * new Vector3(-.5f, 0, -.5f);
                    break;
                }
            case Directions.W:
                {
                    this.transform.position += speed * transform.right * -1;
                    break;
                }
            case Directions.NW:
                {
                    this.transform.position += speed * new Vector3(-.5f, 0, .5f);
                    break;
                }
            default:
                {
                    this.transform.position += speed * transform.forward * -1;
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

    void OnTriggerStay(Collider other)
    {
        if ( other.tag == "Player" && other.gameObject != ignore.gameObject)
        {
            Debug.Log("dealt damage to " + other.gameObject.transform.name);
            //Debug.Log("other object is: " + other.gameObject.transform.name);
            //Debug.Log("Ignore target is: " + ignore.transform.name);
            other.gameObject.GetComponent<PlayerController>().TakeDamage(5);
        }
    }
}
