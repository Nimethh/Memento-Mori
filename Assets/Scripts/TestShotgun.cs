using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShotgun : MonoBehaviour, IWeapon
{
    public GameObject playerHand;

    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float attackCooldownTimer;
    [SerializeField]
    private bool attackIsOnCooldown;
    [SerializeField]
    private int numberOfBullets;
    [SerializeField]
    private float maxBulletSpreadAngle;
    [SerializeField]
    private int shotsLeft;
    [SerializeField]
    private float ammoRechargeTimer;

    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        attackCooldown = 0.8f;
        attackCooldownTimer = 0f;
        attackIsOnCooldown = false;
        numberOfBullets = 10;
        maxBulletSpreadAngle = 13f;
        shotsLeft = 6;
        ammoRechargeTimer = 0f;
    }

    public void Update()
    {
        if(attackIsOnCooldown == true)
        {
            //if(shotsLeft == 0)
            //{
            //    attackCooldownTimer += 5f;
            //    shotsLeft = 6;
            //    ammoRechargeTimer = 0;
            //}

            attackCooldownTimer = attackCooldownTimer - Time.deltaTime;
            if(attackCooldownTimer <= 0)
            {
                attackIsOnCooldown = false;
            }
        }

        ammoRechargeTimer += 0.2f * Time.deltaTime;
        if(ammoRechargeTimer > 0.3f)
        {
            if(shotsLeft < 6)
            {
                shotsLeft++;
                ammoRechargeTimer = 0f;
            }

        }
    }


    public void PreformAttack()
    {
        //Debug.Log("preformAttack - shotgun");

        if(attackIsOnCooldown == false)
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                float randomAngle = Random.Range((-maxBulletSpreadAngle / 2), (maxBulletSpreadAngle / 2));

                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                difference.Normalize();
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees

                GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/ShotgunBullet"), playerHand.transform.position + new Vector3(Random.Range(0.2f,0.8f), 0,0), playerHand.transform.rotation);
                bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + randomAngle);
            }

            attackIsOnCooldown = true;
            attackCooldownTimer = attackCooldown;
            shotsLeft--;
        }

    }

    public void PreformSpecialAttack()
    {
        //Debug.Log("preformSpecialAttack - shotgun");
    }

}
