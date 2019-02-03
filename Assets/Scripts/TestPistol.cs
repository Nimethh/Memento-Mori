using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPistol : MonoBehaviour, IWeapon
{
    public GameObject playerHand;

    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
    }

    public void PreformAttack()
    {
        Debug.Log("preformAttack - pistol ");
        GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), playerHand.transform.position, playerHand.transform.rotation);
        bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
    }

    public void PreformSpecialAttack()
    {
        Debug.Log("preformSpecialAttack - pistol");
    }
}
