using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickUpItemLayerMask;

    [SerializeField]
    private GameObject pickUpItemUI;

    [SerializeField]
    private Text itemText;
    [SerializeField]
    private Image itemIcon;

    [SerializeField]
    private Collider2D upgradeColliders;

    void Start ()
    {
        pickUpItemLayerMask = LayerMask.GetMask("PickUpItem");
        pickUpItemUI = GameObject.FindGameObjectWithTag("PickUpItemUI").gameObject; //Not sure if this is correct.
        itemText = pickUpItemUI.transform.GetChild(0).GetComponent<Text>();
        itemIcon = pickUpItemUI.transform.GetChild(1).GetComponent<Image>();
    }
	
	void Update ()
    {
        //search for nearby items that can be picked up.
        if (StandingCloseToAnUpgrade() == true)
        {
            pickUpItemUI.SetActive(true);
        }
        else
        {
            pickUpItemUI.SetActive(false);
        }
    }


    private bool StandingCloseToAnUpgrade()
    {
        upgradeColliders = Physics2D.OverlapCircle(transform.position, 3, pickUpItemLayerMask);

        if (upgradeColliders != null)
        {
            //Change the itemName and itemIcon
            return true;
        }
        else
        {
            return false;
        }
    }
}
