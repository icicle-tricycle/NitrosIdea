using UnityEngine;
using System.Collections;

public class plusProjectile : MonoBehaviour {

    public float speed = 10;
    public string dir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (dir == "up") this.transform.position += speed * transform.forward;
        else if (dir == "down") this.transform.position += speed * transform.forward * -1;
        else if (dir == "left") this.transform.position += speed * transform.right * -1;
        else if (dir == "right") this.transform.position += speed * transform.right;

	
	}

    public void Up()
    {
        dir = "up";
    }

    public void Down()
    {
        dir = "down";
    }

    public void Left()
    {
        dir = "left";
    }

    public void Right()
    {
        dir = "right";
    }
}
