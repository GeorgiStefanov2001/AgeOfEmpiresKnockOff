using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour {

    public bool toBeUpgraded = false;
    public string UpgaradeName;

    public GameObject upgradePanel;
    public GameObject upgradeName;
    
    void Start() {

    }

    void Update() {
        upgradePanel.SetActive(toBeUpgraded);
        SetUpgradeName();
    }

    public void UpgradeOn()
    {
        toBeUpgraded = true;
        UpgaradeName = EventSystem.current.currentSelectedGameObject.tag;
    }

    public void UpgradeOff()
    {
        toBeUpgraded = false;
    }

    void SetUpgradeName()
    {
        upgradeName.GetComponent<Text>().text = UpgaradeName;
    }
}
