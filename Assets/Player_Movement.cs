using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //creates the variable representing the collision box
    private BoxCollider2D boxCollider;

    //Creates the Vector that represents the amount of movement
    private Vector3 moveDelta;
    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // FixedUpdate is called at a rate defined in the editor
    private void FixedUpdate()
    {
        //detects amount of movement as a float
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //reset moveDelta
        moveDelta = new Vector3(x,y,0);

    //logs movements in console if un-slashed
    //Debug.Log(x);
    //Debug.Log(y);

    //swaps direction sprite faces for right or left movement
    if (moveDelta.x > 0)
        transform.localScale = Vector3.one;
    else if (moveDelta.x < 0)
        transform.localScale = new Vector3(-1,1,1);

    //I LIKE TO MOVE IT, MOVE IT!
    //translates the transform(rot.,scale,posi.) in the direction & amount of moveDelta
    //Time.deltaTime is the int of seconds between the two frames
    //this prevents higher fps machines from having faster characters
    transform.Translate(moveDelta * Time.deltaTime);
    }
}
