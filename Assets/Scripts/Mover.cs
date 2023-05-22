using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    //creates the variable representing the collision box
    protected BoxCollider2D boxCollider;
    //Creates the Vector that represents the amount of movement
    private Vector3 moveDelta;
    //creates a variable used to detect if creatures can move onto a tile
    private RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed= 1.0f;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    
    protected virtual void UpdateMotor(Vector3 input)
    {
        //resets moveDelta to zero
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //logs movements in console if un-slashed
        //Debug.Log(x);
        //Debug.Log(y);

        //swaps direction sprite faces for right or left movement
        //does this by switching the scale to -1 on the x axis when moving left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1,1,1);


        //add push vector
        moveDelta += pushDirection;

        //reduce push force every frame
        pushDirection = Vector3.Lerp(pushDirection,Vector3.zero, pushRecoverySpeed);


        //makes sure you can move there by casting a box there first, if the box returns null, you move
        //for the y-axis
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Creature", "Blocking"));
        if (hit.collider == null)
        {
            //I LIKE TO MOVE IT, MOVE IT!
            //translates the transform(rot.,scale,posi. of thing) in the direction & amount of moveDelta
            //Time.deltaTime is the int of seconds between the two frames
            //this prevents higher fps machines from having faster characters
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }


        //makes sure you can move there by casting a box there first, if the box returns null, you move
        //for the x-axis
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Creature", "Blocking"));
        if (hit.collider == null)
        {
            //I LIKE TO MOVE IT, MOVE IT!
            //translates the transform(rot.,scale,posi. of thing) in the direction & amount of moveDelta
            //Time.deltaTime is the int of seconds between the two frames
            //this prevents higher fps machines from having faster characters
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
    }
}
