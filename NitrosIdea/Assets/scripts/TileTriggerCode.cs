using UnityEngine;
using System.Collections;

public class TileTriggerCode : MonoBehaviour 
{
    Tile parentTile;

    void Start()
    {
        parentTile = transform.parent.gameObject.GetComponent<Tile>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCollider")
        {
            //Debug.Log("made it to the inside");
            other.GetComponentInParent<PlayerController>().currTile = parentTile;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerCollider")
        {
            if (other.GetComponentInParent<PlayerController>().currTile == parentTile)
            {
                other.GetComponentInParent<PlayerController>().currTile = null;
            }
        }
    }
}
