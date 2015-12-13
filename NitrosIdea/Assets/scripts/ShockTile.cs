using UnityEngine;
using System.Collections;

public class ShockTile : MonoBehaviour {

	[SerializeField] int damage = 5;
	
	void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
        }
	}
}
