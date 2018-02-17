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
    public GameObject town2;
    public GameObject town3;
    
    void Start() {

    }

    void Update() {
        upgradePanel.SetActive(toBeUpgraded);
        SetUpgradeName();
    }

    public void UpgradeOn()
    {
        toBeUpgraded = true;
        UpgradeName = EventSystem.current.currentSelectedGameObject.tag;
    }

    public void UpgradeOff()
    {
        toBeUpgraded = false;
    }

    void SetUpgradeName()
    {
        upgradeName.GetComponent<Text>().text = UpgradeName;
    }

    public void UpgradeBuilding()
    {
        if(UpgradeName == "Town Hall" && GameObject.Find("TownHall").GetComponent<TownHall>().level < 15)
        {
            if (GameObject.Find("TownHall").GetComponent<TownHall>().level >= 5)
            {
                if (GameObject.Find("TownHall").GetComponent<TownHall>().level >= 10)
                {
                    town3.SetActive(true);
                }
                town2.SetActive(true);
            }
            else
            {
                GameObject.Find("TownHall").transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            }
            GameObject.Find("TownHall").GetComponent<TownHall>().level += 1;
            GameObject.Find("TownHall").GetComponent<TownHall>().maxHp += 50;
            GameObject.Find("TownHall").GetComponent<TownHall>().currHealth = GameObject.Find("TownHall").GetComponent<TownHall>().maxHp;
        }
    }
}
