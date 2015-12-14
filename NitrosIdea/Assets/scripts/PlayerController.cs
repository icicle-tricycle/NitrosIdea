using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] int health;
    GameObject floor;
    [SerializeField] float tileUseTime;
    [SerializeField] int numFlashes;
    [SerializeField] float flashTime;
    [SerializeField] bool isPlayerOne;

    //GameObject player;
    public Tile currTile;
    bool usingTile;
    bool isImmune = false;
    MeshRenderer renderer;
	public TextMesh healthText;
	GameObject healthBar;

    // Use this for initialization
    void Start()
    {
        floor = GameObject.FindGameObjectWithTag("Floor");
        //player = gameObject;
        speed = 0.1f;
        health = 8;
        renderer = GetComponent<MeshRenderer>();
		healthBar = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        
    }

    void OnDisable()
    {
        if(isPlayerOne)
        {
            print("Player 1 is dead");
        }
        else
        {
            print("Player 2 is dead");
        }
        if (floor != null)
        {
            floor.GetComponent<TileArray>().resetNeeded = true;
        }
    }

    void OnEnable()
    {
        
        if (health > 0) return;

        health = 10;
        isImmune = false;
        if (isPlayerOne)
        {
            print("Player 1 is alive");
        }
        else
        {
            print("Player 2 is alive");
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.E) && currTile && !usingTile)
            {
                usingTile = true;
                //Starts a thread that calls this method
                StartCoroutine("UseTile");
            }
            else
            {
                usingTile = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightControl) && currTile && !usingTile)
            {
                usingTile = true;
                //Starts a thread that calls this method
                StartCoroutine("UseTile");
            }
            else
            {
                usingTile = false;
            }
        }

        if (usingTile)
        {
            return;
        }
        if (isPlayerOne)
        {
            //Input.GetAxis("Vertical");
            //editor -> project settings -> something else
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
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += (transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += (transform.right * -speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += (transform.forward * -speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += (transform.right * speed);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            health -= damage;
            isImmune = true;
            if (!CheckIsDead())
            {
                StartCoroutine(StopImmunity());
            }
        }
		healthBar.transform.GetChild(health).GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator UseTile()
    {
        //leaves the method for X seconds and then finishes the method later
        yield return new WaitForSeconds(currTile.getUseTime());
        if (!usingTile)
        {
            yield break;
        }

        if (currTile)
        {
            currTile.FireAttack(this);
            usingTile = false;

            if (isPlayerOne)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    usingTile = true;
                    //Starts a thread that calls this method
                    StopCoroutine("UseTile");
                    StartCoroutine("UseTile");
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.RightControl))
                {
                    usingTile = true;
                    //Starts a thread that calls this method
                    StopCoroutine("UseTile");
                    StartCoroutine("UseTile");
                }
            }
        }
    }

    IEnumerator StopImmunity()
    {
        for (int i = 0; i < numFlashes; i++)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(flashTime);
        }
        isImmune = false;
        renderer.enabled = true;
    }

    bool CheckIsDead()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }

}
