using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour, IWeapon
{
    public GameObject playerHand;

    [SerializeField]
    private float specialAttackCooldown;
    [SerializeField]
    private float specialAttackCooldownCounter;
    [SerializeField]
    private float specialAttackActiveTime;
    [SerializeField]
    private float specialAttackActiveCounter;
    [SerializeField]
    private bool specialAttackActivated;



    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        specialAttackCooldown = 10f;
        specialAttackActiveTime = 3f;
        specialAttackActiveCounter = 0f;
    }

    public void Update()
    {
        if(specialAttackCooldownCounter > 0)
        {
            specialAttackCooldownCounter -= Time.deltaTime;
        }

        if (specialAttackActivated == true)
        {
            specialAttackActiveCounter -= Time.deltaTime;
            if(specialAttackActiveCounter <= 0)
            {
                specialAttackActivated = false;
            }
        }
    }

    public void PreformAttack()
    {
        Debug.Log("preformAttack - gun");
        if(specialAttackActivated == false)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), playerHand.transform.position, playerHand.transform.rotation);
            bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
        }
        else
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunSpecialBullet"), playerHand.transform.position, playerHand.transform.rotation);
            bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
        }

    }

    public void PreformSpecialAttack()
    {
        Debug.Log("preformSpecialAttack - gun");
        if(specialAttackActivated == false && specialAttackCooldownCounter <= 0)
        {
            specialAttackActivated = true;
            specialAttackActiveCounter = specialAttackActiveTime;
            specialAttackCooldownCounter = specialAttackCooldown;
        }
    }

}
