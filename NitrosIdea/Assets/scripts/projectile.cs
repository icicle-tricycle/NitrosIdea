using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

	enum Direction{
		Up,
		Down,
		Left,
		Right,
		TopLeft,
		BottomLeft,
		BottomRight,
		TopRight
	};

	Direction dir;

	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dir == Direction.Up) this.transform.position += speed * transform.forward;
		else if (dir == Direction.Down) this.transform.position += speed * transform.forward * -1;
		else if (dir == Direction.Left) this.transform.position += speed * transform.right * -1;
		else if (dir == Direction.Right) this.transform.position += speed * transform.right;
		else if (dir == Direction.TopLeft) this.transform.position += speed * new Vector3(-.5f,0,.5f);
		else if (dir == Direction.BottomLeft)this.transform.position = speed * new Vector3(-.5f,0,-.5f);
		else if (dir == Direction.TopRight) this.transform.position += speed * new Vector3(.5f,0,.5f);
		else if (dir == Direction.BottomRight)this.transform.position = speed * new Vector3(-.5f,0,-.5f);

	}

	public void Up(){ dir = Direction.Up; }

	public void Down(){ dir = Direction.Down; }

	public void Left(){ dir = Direction.Left; }

	public void Right(){ dir = Direction.Right; }

	public void TopLeft(){ dir = Direction.TopLeft; }

	public void BottomLeft(){ dir = Direction.BottomLeft; }

	public void BottomRight(){ dir = Direction.BottomRight; }
}
