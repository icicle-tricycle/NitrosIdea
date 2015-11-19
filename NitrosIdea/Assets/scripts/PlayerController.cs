using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	public GameObject player;
	public float speed;
	public float health;
	public GameObject floor;

	// Use this for initialization
	void Start () {
        floor = GameObject.FindGameObjectWithTag("Floor");
		player = GameObject.FindGameObjectWithTag("Player");
		speed = 0.1f;
		health = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	void Move() {
		if (Input.GetKey (KeyCode.W)) transform.position += (transform.forward * speed);
		if (Input.GetKey (KeyCode.A)) transform.position += (transform.right * -speed);
		if (Input.GetKey (KeyCode.S)) transform.position += (transform.forward * -speed);
		if (Input.GetKey (KeyCode.D)) transform.position += (transform.right * speed);
	}
	void TakeDamage(float damage){	
		health -= damage;
	}
	void UseTile(){
	}
}
