using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : Collectable
{
    private Animator anim;
    private bool isShown = false;
    private bool seen = false;

    
        

    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("IMPLEMENTED ON COLLIDE");
        
        

            //if(isShown == false && seen == false) 
            {
                Debug.Log("WAS ACTIVATED");
                
                anim = GetComponent<Animator>();
                if(anim != null)
                {
                    
                    if (anim == null)
                        Debug.Log("anim is null");

                    Debug.Log("Triggered!!!!!!!!!!!!!!!!!!!!!!!!");
                    anim.SetTrigger("bumpReaper");
                    isShown = true;
                    //Time.timeScale = 0;
                    seen = true;
                    Debug.Log("Done");
                    
                }
                    
            }
            /*
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if(anim != null)
                    {
                        anim.SetTrigger("HideReaper");
                        isShown = false;
                        Time.timeScale = 1;
                    }
                }
            */


            
    }   
}
