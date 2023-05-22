using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // experience
    public int enemyNumber = 1;

    //Logic
    public float triggerLength = 0.3f;
    public float chaseLength = 0.5f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;


    //hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    //speed
    public float enemyXSpeed = 0.65f;
    public float enemyYSpeed = 0.9f;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.Player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();


        //override base speed values
        xSpeed = enemyXSpeed;
        ySpeed = enemyYSpeed;
    }

    private void FixedUpdate()
    {
        //is player in range
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if(Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
            {
                chasing = true;
            }

            if(chasing)
            {
                if(!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            return;
        }



        //UpdateMotor(Vector3.zero)


        //check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if(hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            //array is not cleaned up, so this does it
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.enemiesKilled += enemyNumber;
    }
}
