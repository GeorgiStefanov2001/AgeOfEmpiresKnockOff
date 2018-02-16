using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownHall : MonoBehaviour
{
    public int level = 0;
    bool canLevelUp = false;
    float colliderRange = 100f;
    bool showStats = false;

    GameObject townHallInfoPanel;

    void Start()
    {
        level = level == 0 ? 1 : PlayerPrefs.GetInt("TownHallLvl"); //if the level is 0 (new game) then we set it to 1, otherwise we set it to the players level that is saved on the hard
        townHallInfoPanel = GameObject.Find("TownHallPanel"); //we get the panel for the town hall info
    }

    void Update()
    {
        GetComponent<BoxCollider>().size = new Vector3((transform.localScale.x - 0.1f) * colliderRange, (transform.localScale.y - 0.1f) * colliderRange * 2, (transform.localScale.z - 0.1f) * colliderRange); //setting the size of the town hall's collider
        LevelUp();
        CheckStats();
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
}
