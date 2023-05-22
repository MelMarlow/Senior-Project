using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[100];

    protected virtual void Start()
    {
        Debug.Log("started");
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //collision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);

            //array is not cleaned up, so this does it
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("OnCollider was not implemented in " + this.name);
    }
}
