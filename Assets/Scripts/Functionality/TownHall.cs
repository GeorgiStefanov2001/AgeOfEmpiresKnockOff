using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownHall : MonoBehaviour
{
    public int level;
    bool canLevelUp = false;
    float colliderRange = 100f;
    bool showStats = false;
    public int maxHp = 0;
    public int currHealth = 0;
    public int population = 0;
    public int numOfHouses = 0;
    public string leader;

    GameObject townHallInfoPanel;
    public GameObject HP;

    void Start()
    {
        population =PlayerPrefs.GetInt("Population");
        numOfHouses = PlayerPrefs.GetInt("NumberOfHouses"); 
        maxHp = PlayerPrefs.GetInt("maxHealth"); 
        currHealth = PlayerPrefs.GetInt("CurrentHealth");
        level = PlayerPrefs.GetInt("TownHallLvl"); 
        townHallInfoPanel = GameObject.Find("TownHallPanel");  
        leader = PlayerPrefs.GetString("Leader"); 

    }

    void Update()
    {
        GetComponent<BoxCollider>().size = new Vector3((transform.localScale.x - 0.1f) * colliderRange, (transform.localScale.y - 0.1f) * colliderRange * 2, (transform.localScale.z - 0.1f) * colliderRange); //setting the size of the town hall's collider
        LevelUp();
        CheckStats();
        AddjustHealth(0);
    }

    void LevelUp()
    {
        if (canLevelUp)
        {
            level += 1;
            PlayerPrefs.SetInt("TownHallLvl", level); //saving the player's town hall level to the hard 
            canLevelUp = false;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // if we are hovering over the town hall (the collider that we set up) and we have clicked then we show the stats
        {
            showStats = true;
        }
    }

    void CheckStats()
    {
        townHallInfoPanel.SetActive(showStats);
    }

    public void CloseStats()
    {
        showStats = false;
    }

    public void AddjustHealth (int addj) { // in case we take damage or heal

        currHealth += addj;

        if (currHealth <= 0)
        {
            currHealth = 0;
        }else if(currHealth > maxHp)
        {
            currHealth = maxHp;
        }

        Health();
    } 

    public void Health()
    {
        HP.GetComponent<Text>().text = "Health: " + currHealth + " / " + maxHp;

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TownHallLvl", level);
        PlayerPrefs.SetInt("maxHealth", maxHp);
        PlayerPrefs.SetInt("CurrentHealth", currHealth);
        PlayerPrefs.SetInt("Population", population);
        PlayerPrefs.SetInt("NumberOfHouses", numOfHouses);
        PlayerPrefs.SetString("Leader", leader);
    }
}
