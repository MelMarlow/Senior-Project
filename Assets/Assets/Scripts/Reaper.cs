using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : Collectable
{
    private Animator anim;
    private bool isShown = false;
    private bool seen = false;

    private void Start()
    {
       anim = GetComponent<Animator>(); 
    }

    protected override void OnCollide(Collider2D coll)
    {
        
            if(!isShown && !seen) 
            {
                seen = true;

                if(anim != null)
                {
                    anim.SetTrigger("BumpReaper");
                    isShown = true;
                    Time.timeScale = 0;

                    
                }
                    
            }
            
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if(anim != null)
                    {
                        anim.SetTrigger("HideReaper");
                        isShown = false;
                        Time.timeScale = 1;
                    }
                }
        
    }   
}
