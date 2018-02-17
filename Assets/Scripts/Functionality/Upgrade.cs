using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour {

    public bool toBeUpgraded = false;
    string UpgradeName;

    public GameObject upgradePanel;
    public GameObject upgradeName;
    public GameObject upgradeLevel;
    
    void Start() {

    }

    void Update() {
        upgradePanel.SetActive(toBeUpgraded);
        SetUpgradeNameAndLevel();
    }

    public void UpgradeOn()
    {
        toBeUpgraded = true;
        UpgradeName = EventSystem.current.currentSelectedGameObject.tag;
        if (GameObject.Find(EventSystem.current.currentSelectedGameObject.tag).GetComponent<TownHall>().level >= GameObject.Find(EventSystem.current.currentSelectedGameObject.tag).GetComponent<TownHall>().maxLevel)
        {
            upgradeLevel.GetComponent<Text>().text = "MAX LEVEL";
        }
        else
        {
            upgradeLevel.GetComponent<Text>().text = "To Level " + (GameObject.Find(EventSystem.current.currentSelectedGameObject.tag).GetComponent<TownHall>().level + 1);
        }
    }

    public void UpgradeOff()
    {
        toBeUpgraded = false;
    }

    void SetUpgradeNameAndLevel()
    {
        upgradeName.GetComponent<Text>().text = UpgradeName;
    }

    public void UpgradeBuilding()
    {
        if (UpgradeName == "Town Hall" && GameObject.Find("Town Hall").GetComponent<TownHall>().level < GameObject.Find("Town Hall").GetComponent<TownHall>().maxLevel)
        {

            if (GameObject.Find("Town Hall").GetComponent<TownHall>().level >= 5)
            {
                if (GameObject.Find("Town Hall").GetComponent<TownHall>().level >= 10)
                {
                    PlayerPrefs.SetInt("Town3", 1);
                }
                PlayerPrefs.SetInt("Town2", 1);
            }
            else
            {
                GameObject.Find("Town Hall").transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            }
            GameObject.Find("Town Hall").GetComponent<TownHall>().level += 1;
            GameObject.Find("Town Hall").GetComponent<TownHall>().maxHp += 100;
            GameObject.Find("Town Hall").GetComponent<TownHall>().currHealth = GameObject.Find("Town Hall").GetComponent<TownHall>().maxHp;
        }

        if (GameObject.Find(EventSystem.current.currentSelectedGameObject.tag).GetComponent<TownHall>().level >= GameObject.Find(EventSystem.current.currentSelectedGameObject.tag).GetComponent<TownHall>().maxLevel)
        {
            upgradeLevel.GetComponent<Text>().text = "MAX LEVEL";
        }
        else
        {
            upgradeLevel.GetComponent<Text>().text = "To Level " + (GameObject.Find(EventSystem.current.currentSelectedGameObject.tag).GetComponent<TownHall>().level + 1);
        }
    }
}
