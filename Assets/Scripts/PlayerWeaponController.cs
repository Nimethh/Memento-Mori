using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    public GameObject playerHand;
    public GameObject equippedWeapon { get; set; }
    public IWeapon equippedWeaponInterface;

    public bool hasWeaponEquipped;

    void Start()
    {
        hasWeaponEquipped = false;   
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PreformWeaponAttack();
        }



        if (Input.GetMouseButtonDown(1))
        {
            PreformWeaponSpecialAttack();
        }
    }

    private void FixedUpdate()
    {
        //Added 2019-02-14
        if (Input.GetMouseButton(0))
        {
            PreformWeaponAttack();
        }
    }

    //Dissapeared when I moved the script into the Interface folder
    public void EquipWeapon(IWeaponCrate weaponToEquip)
    {
        if(equippedWeapon != null)
        {
            Destroy(playerHand.transform.GetChild(0).gameObject); //Destroy the currently equipped weapon
        }

        //Loading the weapon from the resources folder -> "Weapons" and then which weapon by its objectslug
        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + weaponToEquip.objectSlug), playerHand.transform.position, playerHand.transform.rotation); 
        equippedWeapon.transform.SetParent(playerHand.transform); //Setting the weapon in our playerhand 
        equippedWeaponInterface = equippedWeapon.GetComponent<IWeapon>();

        hasWeaponEquipped = true;
    }

    public void UnequipWeapon()
    {
        Debug.Log("UnequippedWeapon() called");

        if(hasWeaponEquipped == true)
        {
            equippedWeaponInterface = null;
            Destroy(equippedWeapon);
        }
    }


    public void PreformWeaponAttack()
    {
        if(equippedWeaponInterface == null)
        {
            //Debug.Log("equippedWeaponInterface equals null");
            return;
        }

        equippedWeaponInterface.PreformAttack();
    }

    public void PreformWeaponSpecialAttack()
    {
        if (equippedWeaponInterface == null)
        {
            Debug.Log("equippedWeaponInterface equals null");
            return;
        }

        equippedWeaponInterface.PreformSpecialAttack();
    }

}
