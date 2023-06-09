using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int coinsAmount = 5;

    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Give " + coinsAmount + " Coins!");
            GameManager.instance.ShowText("+" + coinsAmount + " coins", 45, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
        }
        
    }
}
