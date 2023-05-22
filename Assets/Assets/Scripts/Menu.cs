using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : Stats
{

    private Animator anim;
    private bool isMenuShown = false;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }


    protected virtual void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isMenuShown)
            {
                if(anim != null)
                {
                    anim.SetTrigger("show");
                    isMenuShown = true;
                    Time.timeScale = 0;

                    UpdateMenu();
                }
                
            }
        

            else 
            {
                if(anim != null)
                {
                    anim.SetTrigger("hide");
                    isMenuShown = false;
                    Time.timeScale = 1;
                }
            }
        }
    }   
}

