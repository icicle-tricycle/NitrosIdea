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
        other.gameObject.GetComponent<PlayerController>().currTile = parentTile;
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().currTile = null;
    }
}
