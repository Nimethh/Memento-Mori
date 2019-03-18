using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private bool upgradeAquiredBool = false;
    [SerializeField]
    private bool upgradeBehaviorBool = false;
    [SerializeField]
    private bool armUpgradeBool = false;
    [SerializeField]
    private bool headUpgradeBool = false;
    [SerializeField]
    private bool goToNextLevelBool = false;

    public GameObject upgradeAquiredUI;
    public GameObject upgradeBehaviorUI;
    public GameObject armUpgradeUI;
    public GameObject headUpgradeUI;

    void Start()
    {
        GameObject.Find("UpgradePanel").SetActive(false);
        upgradeAquiredUI.SetActive(false);
        upgradeBehaviorUI.SetActive(false);
        armUpgradeUI.SetActive(false);
        headUpgradeUI.SetActive(false);
    }
    void Update()
    {
        if (GameObject.Find("UpgradePanel") == true)
        {
            if (goToNextLevelBool == true)
            {
                ChangeScenes();
            }

            ActivatePanel();


            if (armUpgradeBool == true && upgradeBehaviorBool == false && upgradeAquiredBool == false)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    goToNextLevelBool = true;
                }
            }
            else if (headUpgradeBool == true && upgradeBehaviorBool == false && upgradeAquiredBool == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    goToNextLevelBool = true;
                }
            }
            else if (upgradeBehaviorBool == true && upgradeAquiredBool == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    UpdateBools();
                }
            }
            else if (upgradeAquiredBool == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    UpdateBools();
                }
            }
            
        }

    }

    void UpdateBools()
    {
        if(upgradeAquiredBool == true)
        {
            upgradeAquiredBool = false;
        }
        else if(upgradeBehaviorBool == true)
        {
            upgradeBehaviorBool = false;
        }
        else if(armUpgradeBool == true)
        {
            armUpgradeBool = false;
        }
        else if(headUpgradeBool == true)
        {
            headUpgradeBool = false;
        }
    }

    void ActivatePanel()
    {
        if (armUpgradeBool == true && upgradeBehaviorBool == false && upgradeAquiredBool == false)
        {
            upgradeBehaviorUI.SetActive(false);
            armUpgradeUI.SetActive(true);
        }
        else if (headUpgradeBool == true && upgradeBehaviorBool == false && upgradeAquiredBool == false)
        {
            upgradeAquiredUI.SetActive(false);
            headUpgradeUI.SetActive(true);
        }
        else if (upgradeBehaviorBool == true && upgradeAquiredBool == false)
        {
            upgradeAquiredUI.SetActive(false);
            upgradeBehaviorUI.SetActive(true);
        }
        else if (upgradeAquiredBool == true)
        {
            upgradeAquiredUI.SetActive(true);
        }
    }

    void ChangeScenes()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2With");
        }
        else if(SceneManager.GetActiveScene().name == "Level2With")
        {
            SceneManager.LoadScene("Level3WithArmWithHead");
        }
    }
}
