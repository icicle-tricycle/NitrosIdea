using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	public GameObject player;
	public float speed;
	public int health;
	public GameObject[,] tiles;

	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectWithTag ("Floor").GetComponent <TileArray>().GetGrid;
		player = GameObject.FindGameObjectWithTag("Player");
		speed = 0.1f;
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	public void Move() {
		if (Input.GetKey (KeyCode.W)) transform.position += (transform.forward * speed);
		if (Input.GetKey (KeyCode.A)) transform.position += (transform.right * -speed);
		if (Input.GetKey (KeyCode.S)) transform.position += (transform.forward * -speed);
		if (Input.GetKey (KeyCode.D)) transform.position += (transform.right * speed);
	}
	public void TakeDamage(int damage){	
		health -= damage;
	}
	public void UseTile(){
	}
}
