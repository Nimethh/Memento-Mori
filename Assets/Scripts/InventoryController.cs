using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickUpWeaponLayerMask;

    [SerializeField]
    private GameObject pickUpWeaponUI;

    [SerializeField]
    private Text itemDescription;
    [SerializeField]
    private Text itemName;
    [SerializeField]
    private Image itemIcon;

    [SerializeField]
    private Collider2D upgradeCollider;

    [SerializeField]
    private PlayerWeaponController weaponController;

    void Start ()
    {
        weaponController = GetComponent<PlayerWeaponController>();
        pickUpWeaponLayerMask = LayerMask.GetMask("PickUpWeapon");
        pickUpWeaponUI = GameObject.FindGameObjectWithTag("PickUpWeaponUI").gameObject; //Not sure if this is correct.
        itemName = pickUpWeaponUI.transform.GetChild(0).GetComponent<Text>();
        itemIcon = pickUpWeaponUI.transform.GetChild(1).GetComponent<Image>();
        itemDescription = pickUpWeaponUI.transform.GetChild(2).GetComponent<Text>();


    }

    void Update ()
    {
        //search for nearby items that can be picked up.
        if (StandingCloseToAWeapon() == true)
        {
            pickUpWeaponUI.SetActive(true);
        }
        else
        {
            pickUpWeaponUI.SetActive(false);
        }
    }


    private bool StandingCloseToAWeapon()
    {
        upgradeCollider = Physics2D.OverlapCircle(transform.position, 1, pickUpWeaponLayerMask);

        if (upgradeCollider != null)
        {

            itemIcon.sprite = upgradeCollider.transform.Find("WeaponIcon").GetComponent<SpriteRenderer>().sprite;
            if (itemIcon.sprite == null)
            {
                Debug.Log("Could not find itemIcon.sprite - called from StandingCloseToAWeapon() in InventoryController");
            }
            itemName.text = upgradeCollider.GetComponent<IWeaponCrate>().objectSlug;
            if(itemName.text == null)
            {
                Debug.Log("itemName.text is null - called from StandingCloseToAWeapon() in InventoryController");
            }

            //Change the itemName and itemIcon
            if (Input.GetKeyDown(KeyCode.X))
            {
                IWeaponCrate weaponToEquip = upgradeCollider.GetComponent<IWeaponCrate>();
                if(weaponToEquip == null)
                {
                    Debug.Log("Could not find IWeaponCrate - called from StandingCloseToAWeapon() in InventoryController");
                }
                else
                {
                    Debug.Log("Equipped weapon from crate - called from StandingCloseToAWeapon() in InventoryController");
                    weaponController.EquipWeapon(weaponToEquip);
                    Destroy(upgradeCollider.gameObject);
                    upgradeCollider = null;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
