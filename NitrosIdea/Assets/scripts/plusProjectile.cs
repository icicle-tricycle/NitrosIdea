using UnityEngine;
using System.Collections;

public class plusProjectile : MonoBehaviour {

	public GameObject location;
	public GameObject projectile;
	public Vector3 speed = new Vector3(5,0,5);
	public bool activated = false;
	public bool liveFire = false;

	private double edge = 4.5;
	private GameObject upBlast;
	private GameObject downBlast;
	private GameObject leftBlast;
	private GameObject rightBlast;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (activated){

			Blast();
			activated = false;
		}
		if (liveFire){
			upBlast.transform.position=new Vector3(upBlast.transform.position.x + speed.x * Time.deltaTime,
			                                       upBlast.transform.position.y,
			                                       upBlast.transform.position.z);
			downBlast.transform.position = new Vector3(upBlast.transform.position.x,
			                                           upBlast.transform.position.y,
			                                           upBlast.transform.position.z + speed.z * Time.deltaTime * -1);
		}

	}

	void Blast () {
		upBlast = (GameObject)Instantiate(projectile,location.transform.position,location.transform.rotation);
		downBlast = (GameObject)Instantiate(projectile,location.transform.position,location.transform.rotation);
		leftBlast = (GameObject)Instantiate(projectile,location.transform.position,location.transform.rotation);
		rightBlast = (GameObject)Instantiate(projectile,location.transform.position,location.transform.rotation);
		liveFire = true;
	}
}
