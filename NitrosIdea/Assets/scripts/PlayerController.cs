using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	[SerializeField] GameObject player;
	[SerializeField] float speed;
	[SerializeField] float health;
	[SerializeField] GameObject[,] tiles;
    [SerializeField] float tileUseTime;

    public Tile currTile;
    bool usingTile;


	// Use this for initialization
	void Start ()
    {
		tiles = GameObject.FindGameObjectWithTag ("Floor").GetComponent <TileArray>().GetGrid;
		player = GameObject.FindGameObjectWithTag("Player");
		speed = 0.1f;
		health = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
		Move ();
	}

	void Move() 
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (transform.right * -speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (transform.forward * -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (transform.right * speed);
        }
        if (Input.GetKeyDown(KeyCode.E) && currTile)
        {
            usingTile = true;
            StartCoroutine("UseTile");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            usingTile = false;
        }
	}

	void TakeDamage(float damage)
    {	
		health -= damage;
	}

	void UseTile()
    {

	}

    IEnumerator UseTile()
    {
        yield return new WaitForSeconds(tileUseTime);
        if (!usingTile)
        {
            yield break;
        }

        if (currTile)
        {
            currTile.FireAttack();
        }
    }
}
