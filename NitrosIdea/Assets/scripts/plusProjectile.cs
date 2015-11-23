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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //if (dir == Directions.N) this.transform.position += speed * transform.forward;
        //else if (dir == Directions.S) this.transform.position += speed * transform.forward * -1;
        //else if (dir == Directions.W) this.transform.position += speed * transform.right * -1;
        //else if (dir == Directions.E) this.transform.position += speed * transform.right;

        switch (dir)
        {
            case Directions.N:
                {
                    this.transform.position += speed * transform.forward;
                    break;
                }
            //case Directions.NE:
            //    {
            //        this.transform.position += speed * transform.forward;
            //        break;
            //    }
            case Directions.E:
                {
                    this.transform.position += speed * transform.right;
                    break;
                }
            //case Directions.SE:
            //    {
            //        this.transform.position += speed * transform.forward;
            //        break;
            //    }
            case Directions.S:
                {
                    this.transform.position += speed * transform.forward * -1;
                    break;
                }
            //case Directions.SW:
            //    {
            //        this.transform.position += speed * transform.forward;
            //        break;
            //    }
            case Directions.W:
                {
                    this.transform.position += speed * transform.right * -1;
                    break;
                }
            //case Directions.NW:
            //    {
            //        this.transform.position += speed * transform.forward;
            //        break;
            //    }
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
        if (other.gameObject != ignore.gameObject)
        {
            Debug.Log("dealt damage to " + other.gameObject.transform.name);
            //Debug.Log("other object is: " + other.gameObject.transform.name);
            //Debug.Log("Ignore target is: " + ignore.transform.name);
            other.gameObject.GetComponent<PlayerController>().TakeDamage(5);
        }
        else
        {
            Debug.Log("Passed through ignore target");
        }
    }
}
