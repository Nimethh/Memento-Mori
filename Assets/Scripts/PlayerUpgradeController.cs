using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHand;
    [SerializeField]
    private GameObject playerHead;
    [SerializeField]
    private GameObject playerChest;

    [SerializeField]
    private bool armUpgradeEquipped;
    [SerializeField]
    private bool armUpgradeGrayedOut;
    [SerializeField]
    private bool headUpgradeEquipped;
    [SerializeField]
    private bool headUpgradeGrayedOut;

    [SerializeField]
    private GameObject playerEyePatch;

    [SerializeField]
    private IUpgrade equippedHeadUpgrade;
    [SerializeField]
    private IUpgrade equippedChestUpgrade;
    [SerializeField]
    private IArmUpgrade equippedArmUpgrade; // { get; set; }

    [SerializeField]
    private PlayerWeaponController weaponController;
    

    void Start()
    {
        weaponController = GetComponent<PlayerWeaponController>();
        //SetUpHUDIcons();
        SetUpArmHUD();
        SetUpHeadHUD();
        if (headUpgradeEquipped == true)
        {
            GameObject.Find("Eye").SetActive(true);
            //playerEyePatch.SetActive(true);
        }
        else
            GameObject.Find("Eye").SetActive(false);
            //playerEyePatch.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PreformChestAbility();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PreformArmAbility();
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PreformHeadAbility();
        }
    }

    private void FixedUpdate()
    {
        //Added 2019-02-14
        if (Input.GetMouseButton(0))
        {
            PreformArmAttack();
        }
    }

    //Dissapeared when I moved the script into the Interface folder
    public void EquipUpgrade(string upgradeSlug)
    {
        Debug.Log("EquippedUpgrade() - called from PlayerUpgradeController");

        switch (upgradeSlug)
        {
            case "ArmUpgrade":
                {
                    Debug.Log("Case ArmUpgrade");

                    if (equippedArmUpgrade != null)
                    {
                        Debug.Log("Trying to add an arm upgrade when we already have one! This should never happen");
                        //Destroy(playerHand.transform.GetChild(3).gameObject);
                    }
                    else
                    {
                        weaponController.UnequipWeapon();
                        Debug.Log("Should have unequipped the weapon if we held one");
                    }
                    //Loading the weapon from the resources folder -> "Weapons" and then which weapon by its objectslug
                    GameObject equippedArm = (GameObject)Instantiate(Resources.Load<GameObject>("Upgrades/" + upgradeSlug), playerHand.transform.position, playerHand.transform.rotation);
                    equippedArm.transform.SetParent(playerHand.transform); //Setting the weapon in our playerhand 
                    equippedArmUpgrade = equippedArm.GetComponent<IArmUpgrade>();

                    if(equippedArmUpgrade == null)
                    {
                        Debug.Log("Could not find the IArmUpgrade component of EquippedArmUpgrade, called from PlayerUpgradeController");
                    }
                    else
                    {
                        playerHand.GetComponent<SpriteRenderer>().sprite = null;
                        playerHand.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                        playerHand.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = null;

                    }
                }
                break;
            case "ChestUpgrade":
                {
                    Debug.Log("Case ChestUpgrade");

                    if (equippedChestUpgrade != null)
                    {
                        Destroy(playerChest.transform.GetChild(0).gameObject); //Destroy the currently equipped upgrade
                        //Should change this to actually find the Upgrade instead of assuming it.
                    }
                    //Loading the weapon from the resources folder -> "Weapons" and then which weapon by its objectslug
                    GameObject equippedChest = (GameObject)Instantiate(Resources.Load<GameObject>("Upgrades/" + upgradeSlug), playerChest.transform.position, playerChest.transform.rotation);
                    equippedChest.transform.SetParent(playerHand.transform); //Setting the weapon in our playerhand 
                    equippedChestUpgrade = equippedChest.GetComponent<IUpgrade>();

                    if (equippedChestUpgrade == null)
                    {
                        Debug.Log("Could not find the IUpgrade component of EquippedChestUpgrade, called from PlayerUpgradeController");
                    }

                }
                break;
            case "HeadUpgrade":
                {
                    Debug.Log("Case HeadUpgrade");

                    if (equippedHeadUpgrade != null)
                    {
                        Destroy(playerHead.transform.GetChild(0).gameObject); //Destroy the currently equipped upgrade
                        //Should change this to actually find the Upgrade instead of assuming it.
                    }
                    //Loading the weapon from the resources folder -> "Weapons" and then which weapon by its objectslug
                    GameObject equippedHead = (GameObject)Instantiate(Resources.Load<GameObject>("Upgrades/" + upgradeSlug), playerHead.transform.position, playerHead.transform.rotation);
                    equippedHead.transform.SetParent(playerHead.transform); //Setting the weapon in our playerhand 
                    equippedHeadUpgrade = equippedHead.GetComponent<IUpgrade>();

                    if (equippedHeadUpgrade == null)
                    {
                        Debug.Log("Could not find the IUpgrade component of EquippedHeadUpgrade, called from PlayerUpgradeController");
                    }
                }
                break;
            case "HeadUpgradeNew":
                {
                    Debug.Log("Case HeadUpgrade");

                    if (equippedHeadUpgrade != null)
                    {
                        Destroy(playerHead.transform.GetChild(0).gameObject); //Destroy the currently equipped upgrade
                        //Should change this to actually find the Upgrade instead of assuming it.
                    }
                    //Loading the weapon from the resources folder -> "Weapons" and then which weapon by its objectslug
                    GameObject equippedHead = (GameObject)Instantiate(Resources.Load<GameObject>("Upgrades/HeadUpgradeNew"), playerHead.transform.position, playerHead.transform.rotation);
                    equippedHead.transform.SetParent(playerHead.transform); //Setting the weapon in our playerhand 
                    equippedHeadUpgrade = equippedHead.GetComponent<IUpgrade>();

                    if (equippedHeadUpgrade == null)
                    {
                        Debug.Log("Could not find the IUpgrade component of EquippedHeadUpgrade, called from PlayerUpgradeController");
                    }
                }
                break;

            default:
                Debug.Log("Default case in EquipUpgrade, Did you check the IUpgrade's objectslug?");
                break;
        }

    }

    public void PreformArmAbility()
    {
        if(equippedArmUpgrade == null)
        {
            Debug.Log("equippedArmUpgrade equals null");
            return;
        }
        equippedArmUpgrade.PreformAbility();
    }

    public void PreformArmAttack()
    {
        if (equippedArmUpgrade == null)
        {
            //Debug.Log("equippedArmUpgrade equals null");
            return;
        }

        equippedArmUpgrade.PreformAttack();
    }

    public void PreformChestAbility()
    {
        if (equippedChestUpgrade == null)
        {
            Debug.Log("equippedChestUpgrade equals null");
            return;
        }

        equippedChestUpgrade.PreformAbility();
    }


    public void PreformHeadAbility()
    {
        if (equippedHeadUpgrade == null)
        {
            Debug.Log("equippedChestUpgrade equals null");
            return;
        }

        equippedHeadUpgrade.PreformAbility();
    }

    private void SetUpHUDIcons()
    {
        //setting up the icons for the upgrades
        if (armUpgradeEquipped == true)
        {
            //set the sprite to be unlocked
            EquipUpgrade("ArmUpgrade");
            GameObject.Find("ArmUpgradeGrayedOut").SetActive(false);
            GameObject.Find("ArmUpgradeLocked").SetActive(false);
        }
        else if (armUpgradeGrayedOut == true)
        {
            //set the sprite to be grayed out
            GameObject.Find("ArmUpgradeLocked").SetActive(false);
            GameObject.Find("ArmUpgradeOnEffect").SetActive(false);
            GameObject.Find("ArmUpgradeOnCooldown").SetActive(false);
        }
        else
        {
            //set the sprite to be locked
            GameObject.Find("ArmUpgradeGrayedOut").SetActive(false);
            GameObject.Find("ArmUpgradeOnEffect").SetActive(false);
            GameObject.Find("ArmUpgradeOnCooldown").SetActive(false);
        }

        //setting up the icons for the upgrades
        if (headUpgradeEquipped == true)
        {
            //set the sprite to be unlocked
            EquipUpgrade("HeadUpgradeNew");
            GameObject.Find("HeadUpgradeGrayedOut").SetActive(false);
            GameObject.Find("HeadUpgradeLocked").SetActive(false);
        }
        else if (headUpgradeGrayedOut == true)
        {
            //set the sprite to be grayed out
            GameObject.Find("HeadUpgradeLocked").SetActive(false);
            GameObject.Find("HeadUpgradeOnEffect").SetActive(false);
            GameObject.Find("HeadUpgradeOnCooldown").SetActive(false);
        }
        else
        {
            //set the sprite to be locked
            GameObject.Find("HeadUpgradeGrayedOut").SetActive(false);
            GameObject.Find("HeadUpgradeOnEffect").SetActive(false);
            GameObject.Find("HeadUpgradeOnCooldown").SetActive(false);
        }
    }

    private void SetUpArmHUD()
    {
        if (armUpgradeEquipped == true)
        {
            //set the sprite to be unlocked
            EquipUpgrade("ArmUpgrade");
            GameObject.Find("ArmUpgradeGrayedOut").SetActive(false);
            GameObject.Find("ArmUpgradeLocked").SetActive(false);
        }
        else if (armUpgradeGrayedOut == true)
        {
            //set the sprite to be grayed out
            GameObject.Find("ArmUpgradeLocked").SetActive(false);
            GameObject.Find("ArmUpgradeOnEffect").SetActive(false);
            GameObject.Find("ArmUpgradeOnCooldown").SetActive(false);
        }
        else
        {
            //set the sprite to be locked
            GameObject.Find("ArmUpgradeGrayedOut").SetActive(false);
            GameObject.Find("ArmUpgradeOnEffect").SetActive(false);
            GameObject.Find("ArmUpgradeOnCooldown").SetActive(false);
        }
    }

    private void SetUpHeadHUD()
    {
        if (headUpgradeEquipped == true)
        {
            //set the sprite to be unlocked
            EquipUpgrade("HeadUpgradeNew");
            GameObject.Find("HeadUpgradeGrayedOut").SetActive(false);
            GameObject.Find("HeadUpgradeLocked").SetActive(false);
        }
        else if (headUpgradeGrayedOut == true)
        {
            //set the sprite to be grayed out
            GameObject.Find("HeadUpgradeLocked").SetActive(false);
            GameObject.Find("HeadUpgradeOnEffect").SetActive(false);
            GameObject.Find("HeadUpgradeOnCooldown").SetActive(false);
        }
        else
        {
            //set the sprite to be locked
            GameObject.Find("HeadUpgradeGrayedOut").SetActive(false);
            GameObject.Find("HeadUpgradeOnEffect").SetActive(false);
            GameObject.Find("HeadUpgradeOnCooldown").SetActive(false);
        }
    }

    public bool ArmUpgradeIsEquipped()
    {
        return armUpgradeEquipped;
    }

    public bool HeadUpgradeIsEquipped()
    {
        return headUpgradeEquipped;
    }
}
