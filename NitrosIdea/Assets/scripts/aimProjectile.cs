using UnityEngine;
using System.Collections;

public class aimProjectile : MonoBehaviour
{

    public float speed;
    //public string dir;
    public PlayerController ignore;
    private PlayerController target;

    private Vector2 dir;
    private Vector3 vecToTarget;

    public void Aim(PlayerController trgt)
    {
        target = trgt;
    }

    /// <summary>
    /// Aims at the player who is not the parameter
    /// </summary>
    /// <param name="trgt"></param>
    public void AimAtOther(PlayerController trgt)
    {
        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i] != trgt)
            {
                target = players[i];
            }
        }
    }

    private void moveToTarget()
    {
        vecToTarget = new Vector3(target.transform.position.x - this.transform.position.x, 0, target.transform.position.z - this.transform.position.z);
        vecToTarget.Normalize();
    }

    // Use this for initialization
    void Start()
    {
        moveToTarget();
        

    }

    void Update()
    {
        this.transform.position += speed * vecToTarget * Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.gameObject != ignore.gameObject)
        {
            //Debug.Log("dealt damage to " + other.gameObject.transform.name);
            other.gameObject.GetComponent<PlayerController>().TakeDamage(5);
        }
    }
}
