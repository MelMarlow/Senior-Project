using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    
    public Text enemiesKilledNumber, soulsSavedNumber, healthNumber;

    //logic
    public RectTransform healthBar;

    public void UpdateMenu()
    {
        //Meta
        healthNumber.text = ("Health " + GameManager.instance.Player.hitpoint.ToString() + "/25");

        soulsSavedNumber.text = GameManager.instance.soulPoints.ToString();

        enemiesKilledNumber.text = GameManager.instance.enemiesKilled.ToString();

        //health bar
        healthBar.sizeDelta = new Vector3(20 * GameManager.instance.Player.hitpoint, 1, 1); 

    }
}
