using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : Collectable
{
    protected override void OnCollect()
    {
        if(!collected)
            GameManager.instance.ShowText("hello" , 45, Color.white, transform.position, Vector3.up * 50, 3.0f);
    }
}
