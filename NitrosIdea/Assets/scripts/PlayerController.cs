﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] int health;
    [SerializeField] GameObject floor;
    [SerializeField] float tileUseTime;
    [SerializeField] int numFlashes;
    [SerializeField] float flashTime;
    [SerializeField] bool isPlayerOne;

    GameObject player;
    public Tile currTile;
    bool usingTile;
    bool isImmune = false;
    MeshRenderer renderer;


    // Use this for initialization
    void Start()
    {
        floor = GameObject.FindGameObjectWithTag("Floor");
        player = gameObject;
        speed = 0.1f;
        health = 100;
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
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
            if (Input.GetKeyDown(KeyCode.E) && currTile)
            {
                usingTile = true;
                //Starts a thread that calls this method
                StartCoroutine("UseTile");
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                usingTile = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && currTile)
            {
                usingTile = true;
                //Starts a thread that calls this method
                StartCoroutine("UseTile");
            }
            if (Input.GetKeyUp(KeyCode.Space))
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
            if (!checkIsDead())
            {
                StartCoroutine(stopImmunity());
            }
        }
    }

    IEnumerator UseTile()
    {
        //leaves the method for X seconds and then finishes the method later
        yield return new WaitForSeconds(tileUseTime);
        if (!usingTile)
        {
            yield break;
        }

        if (currTile)
        {
            currTile.FireAttack(this);
        }
    }

    IEnumerator stopImmunity()
    {
        for (int i = 0; i < numFlashes; i++)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(flashTime);
        }
        isImmune = false;
        renderer.enabled = true;
    }

    bool checkIsDead()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
