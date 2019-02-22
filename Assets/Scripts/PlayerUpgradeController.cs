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
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PreformChestAbility();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PreformArmAbility();
        }


        if (Input.GetKeyDown(KeyCode.R))
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
                        
                        Destroy(playerHand.transform.GetChild(3).gameObject); //Destroy the currently equipped weapon

                        //playerArmUpgrade = GameObject.FindGameObjectWithTag("PlayerArmUpgrade").gameObject; //Check if this works
                        //Should change this to actually find the weapon instead of assuming it.
                    }
                    else
                    {
                        weaponController.UnequipWeapon();

                        //Destroy the weapon the player is currently holding.

                        //GameObject currentlyEquippedWeapon = GameObject.FindGameObjectWithTag("Weapon").gameObject;
                        //if(currentlyEquippedWeapon != null)
                        //{
                        //    Destroy(currentlyEquippedWeapon);

                        //}

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
            Debug.Log("equippedArmUpgrade equals null");
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
}
