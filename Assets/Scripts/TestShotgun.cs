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




    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        attackCooldown = 1.0f;
        attackCooldownTimer = 0f;
        attackIsOnCooldown = false;
        numberOfBullets = 8;
        maxBulletSpreadAngle = 15f;
    }

    public void Update()
    {
        if(attackIsOnCooldown == true)
        {
            attackCooldownTimer = attackCooldownTimer - Time.deltaTime;
            if(attackCooldownTimer <= 0)
            {
                attackIsOnCooldown = false;
            }
        }
    }


    public void PreformAttack()
    {
        Debug.Log("preformAttack - shotgun");

        if(attackIsOnCooldown == false)
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                float randomAngle = Random.Range((-maxBulletSpreadAngle / 2), (maxBulletSpreadAngle / 2));

                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                difference.Normalize();
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees

                GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/ShotgunBullet"), playerHand.transform.position, playerHand.transform.rotation);
                bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + randomAngle);

            }

            attackIsOnCooldown = true;
            attackCooldownTimer = attackCooldown;
        }



    }

    public void PreformSpecialAttack()
    {
        Debug.Log("preformSpecialAttack - shotgun");
    }

}
