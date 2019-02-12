using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRailGun : MonoBehaviour, IWeapon
{
    public GameObject playerHand;
    private Animator anim;

    [SerializeField]
    private float chargeTime;
    [SerializeField]
    private float maximumChargeTime;
    [SerializeField]
    private float perfectChargeTime;
    [SerializeField]
    private float perfectChargeDuration;
    [SerializeField]
    private bool increaseChargeTimer;
    [SerializeField]
    private int maxDamage;
    [SerializeField]
    private int normalDamage;
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float attackCooldownTimer;
    [SerializeField]
    private bool attackIsOnCooldown;
    [SerializeField]
    private bool hasPlayedPerfectTimeAnim;

    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        anim = GetComponent<Animator>();

        chargeTime = 0f;
        maximumChargeTime = 2f;
        perfectChargeTime = 1.2f;
        perfectChargeDuration = 0.3f;
        increaseChargeTimer = false;
        maxDamage = 100;
        normalDamage = 30;
        attackCooldown = 1f;
        attackCooldownTimer = 0f;
        attackIsOnCooldown = false;
        hasPlayedPerfectTimeAnim = false;
}

private void Update()
    {
        if(attackIsOnCooldown == true)
        {
            attackCooldownTimer = attackCooldownTimer - Time.deltaTime;
            if(attackCooldownTimer <= 0)
            {
                attackIsOnCooldown = false;
            }
        }

        if(increaseChargeTimer == true)
        {
            chargeTime += Time.deltaTime;
            if(chargeTime >= perfectChargeTime)
            {
                if(hasPlayedPerfectTimeAnim == false)
                {
                    anim.Play("PerfectTimeFlash");
                    hasPlayedPerfectTimeAnim = true;
                }


            }
        }

       if(Input.GetMouseButtonUp(0) && attackIsOnCooldown == false && chargeTime > 0)
        {
            FireLaser();
            chargeTime = 0f;
            //increaseChargeTimer = false;
        }
        else if(chargeTime >= maximumChargeTime && attackIsOnCooldown == false && chargeTime > 0)
        {
            FireLaser();
            chargeTime = 0f;
            //increaseChargeTimer = false;
        }
    }

    public void PreformAttack()
    {

        increaseChargeTimer = true;
       
        //Debug.Log("preformAttack - railgun ");
    }

    public void PreformSpecialAttack()
    {
        //Debug.Log("preformSpecialAttack - railgun");
    }

    private void FireLaser()
    {

        if (chargeTime >= perfectChargeTime && chargeTime <= perfectChargeTime+perfectChargeDuration)
        {
            Debug.Log("Perfect attack!");
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/RailGunBulletPerfect"), playerHand.transform.position, playerHand.transform.rotation);
            bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
            attackIsOnCooldown = true;
            attackCooldownTimer = attackCooldown;
        }
        else
        {
            Debug.Log("Normal attack");
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/RailGunBullet"), playerHand.transform.position, playerHand.transform.rotation);
            bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
            attackIsOnCooldown = true;
            attackCooldownTimer = attackCooldown;
        }

        hasPlayedPerfectTimeAnim = false;
        increaseChargeTimer = false;

    }
}
