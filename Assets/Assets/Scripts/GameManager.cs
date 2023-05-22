using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
       
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        Debug.Log("awoken");

        
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> xpTable;

    //Refrences
    public Player Player;
    // public weapon weapon...
    public FloatingTextManager FloatingTextManager;

    //Logic
    public int soulPoints;
    public int enemiesKilled;
    public int coins;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //save state
    /*
        INT preferedSkin
        INT coins
        INT soulPoints
        INT enemiesKilled
    */
    public void SaveState()
    {
        Debug.Log("SaveState");
        string s = "";

        s += "0" + "|";
        s += coins.ToString() + "|";
        s += soulPoints.ToString() + "|";
        s += enemiesKilled.ToString();


        PlayerPrefs.SetString("SaveState", s);
        
       
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            Debug.Log("has key");
            return;
        }
            

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //0|10|3|12

        //Change Player skin
        coins = int.Parse(data[1]);
        soulPoints = int.Parse(data[2]);
        enemiesKilled = int.Parse(data[3]);

    
        Debug.Log("LoadState");
    }


}
