using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRailGun : MonoBehaviour, IWeapon
{
    public GameObject playerHand;
    private GameObject particle;
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

    //Added 2019-02-17
    [SerializeField]
    private float minScale = 1;

    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        particle = transform.Find("Particle").gameObject;

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
            //Added 2019-02-17
            minScale += 3.0f * Time.deltaTime;
            if(minScale > 7)
            {
                minScale = 7;
            }

            particle.SetActive(true);
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
        else
        {
            particle.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0) && attackIsOnCooldown == false && chargeTime > 0)
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
            //Debug.Log("Perfect attack!");
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/RailGunBulletPerfect"), playerHand.transform.position, playerHand.transform.rotation);
            bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
            //bullet.transform.localScale = new Vector3(1, 6, 1);
            attackIsOnCooldown = true;
            attackCooldownTimer = attackCooldown;
            minScale = 1;

        }
        else
        {
            //Debug.Log("Normal attack");
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/RailGunBullet"), playerHand.transform.position, playerHand.transform.rotation);
            bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
            bullet.transform.localScale = new Vector3(1, minScale, 1);

            attackIsOnCooldown = true;
            attackCooldownTimer = attackCooldown;
            minScale = 1;
        }

        hasPlayedPerfectTimeAnim = false;
        increaseChargeTimer = false;

    }
}
