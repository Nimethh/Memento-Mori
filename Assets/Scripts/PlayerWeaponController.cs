using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField]
    private bool shouldSpawnDefaultGun;

    public GameObject playerHand;
    public GameObject equippedWeapon { get; set; }
    public IWeapon equippedWeaponInterface;
    
    public bool hasWeaponEquipped;

    private Joystick shootJoystick;

    void Start()
    {
        hasWeaponEquipped = false;
        if (shouldSpawnDefaultGun)
        {
            EquipDefaultGun();
        }

        PlayerMobileControls mobileControls = GetComponent<PlayerMobileControls>();
        if(mobileControls != null)
            shootJoystick = mobileControls.shootJoystick;
    }

    private void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //     PreformWeaponAttack();
        // }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    PreformWeaponSpecialAttack();
        //}
    }

    private void FixedUpdate()
    {
        bool shooting;

        if(shootJoystick != null)
            shooting = shootJoystick.Direction.sqrMagnitude > 0;
        else
            shooting = Input.GetMouseButton(0);


        if (shooting)
        {
            PreformWeaponAttack();
        }
    }

    //Dissapeared when I moved the script into the Interface folder
    public void EquipWeapon(IWeaponCrate weaponToEquip)
    {
        if(equippedWeapon != null)
        {
            UnequipWeapon();
            //Destroy(playerHand.transform.GetChild(0).gameObject); //Destroy the currently equipped weapon
        }

        //Loading the weapon from the resources folder -> "Weapons" and then which weapon by its objectslug
        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + weaponToEquip.objectSlug), playerHand.transform.position, playerHand.transform.rotation); 
        equippedWeapon.transform.SetParent(playerHand.transform); //Setting the weapon in our playerhand 
        equippedWeaponInterface = equippedWeapon.GetComponent<IWeapon>();

        hasWeaponEquipped = true;
    }

    public void EquipDefaultGun()
    {
        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/gun"), playerHand.transform.position, playerHand.transform.rotation);
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

        Vector2 direction;
        float rotationZ;

        if(shootJoystick != null) {
            direction = shootJoystick.Direction;
        } else {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }

        direction.Normalize();

        rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Finding the angle in degrees
        equippedWeaponInterface.PreformAttack(rotationZ);
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
