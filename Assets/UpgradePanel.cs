using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private bool upgradeAquired = false;
    [SerializeField]
    private bool upgradeBehavior = false;
    [SerializeField]
    private bool armUpgrade = false;
    [SerializeField]
    private bool headUpgrade = false;
    [SerializeField]
    private bool goToNextLevel = false;

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
            //ChangeToArmUpgradeUI();
            //StartCoroutine(Wait());
            //if (goToNextLevel == true)
            //{
            //    SceneManager.LoadScene("Level2With");
            //}

            //if (armUpgrade == true || headUpgrade == true)
            //{
            //    if (SceneManager.GetActiveScene().name == "Level1")
            //    {
            //        SceneManager.LoadScene("Level2With");
            //    }
            //    else
            //        headUpgradeUI.SetActive(true);
            //}

            Time.timeScale = 0.0f;

            if (goToNextLevel == true && Input.GetMouseButtonDown(0))
            {
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2With");
                    Time.timeScale = 1.0f;
                }
                else if(SceneManager.GetActiveScene().name == "Level2With")
                {
                    SceneManager.LoadScene("Level3WithArmWithHead");
                    Time.timeScale = 1.0f;
                }
            }

            if (upgradeAquired == true && Input.GetMouseButtonDown(0))
            {
                Debug.Log("upgradeAquired is true");
                upgradeAquiredUI.SetActive(false);
                upgradeBehaviorUI.SetActive(true);
                upgradeAquired = false;
                //StartCoroutine(Wait());
            }
            if (upgradeBehavior == true && Input.GetMouseButtonDown(0))
            {
                Debug.Log("upgradeBehavior is true");
                upgradeBehaviorUI.SetActive(false);
                upgradeBehavior = false;
                if(Input.GetMouseButtonDown(0))
                {
                    armUpgrade = true;
                }
                //if(Input.GetMouseButtonDown(0))
                //{
                //    if (SceneManager.GetActiveScene().name == "Level1")
                //    {
                //        armUpgradeUI.SetActive(true);
                //        //if (Input.GetMouseButtonDown(0))
                //        //{
                //        //    SceneManager.LoadScene("Level2With");
                //        //}
                //    }
                //    else
                //        headUpgradeUI.SetActive(true);
                //}
            }
            if (armUpgrade == true || headUpgrade == true)
            {
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    armUpgradeUI.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Go TO another scene");
                        goToNextLevel = true;
                    }
                }
                else
                {
                    headUpgradeUI.SetActive(true);
                    if(Input.GetMouseButtonDown(0))
                    {
                        goToNextLevel = true;
                    }
                }
            }

            ChangeToUpgradeBehavior();
            
        }
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
    }

    void ChangeToUpgradeBehavior()
    {
        if(upgradeAquired == false && armUpgrade != true)
        {
            upgradeBehavior = true;
        }
    }
    void ChangeToArmUpgradeUI()
    {
        if(upgradeBehavior == false && upgradeAquired == false)
        {
            armUpgrade = true;
        }
    }
}
