using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour, IWeapon
{
    public GameObject playerHand;

    [SerializeField]
    private GameObject gunBarrel;

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
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float attackCooldownCounter;

    [SerializeField]
    private float maxBulletSpreadAngle;

    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;

        //playerHand.GetComponent<SpriteRenderer>().enabled = false;

        gunBarrel = transform.Find("GunBarrel").gameObject;
        if (gunBarrel == null)
        {
            Debug.Log("Did not find GunBarrel object");
        }

        specialAttackCooldown = 10f;
        specialAttackActiveTime = 3f;
        specialAttackActiveCounter = 0f;
        attackCooldown = 0.1f;

        maxBulletSpreadAngle = 5f;
    }

    public void Update()
    {
        if (attackCooldownCounter > 0)
        {
            attackCooldownCounter = attackCooldownCounter - Time.deltaTime;
        }

        if (specialAttackCooldownCounter > 0)
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
        if(attackCooldownCounter > 0)
        {
            return;
        }

        float randomAngle = Random.Range((-maxBulletSpreadAngle / 2), (maxBulletSpreadAngle / 2));

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees



        if (specialAttackActivated == false)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), gunBarrel.transform.position /*+ new Vector3(Random.Range(0.2f, 0.8f), 0, 0)*/, gunBarrel.transform.rotation);
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + randomAngle);

            //GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), playerHand.transform.position, playerHand.transform.rotation);
            //bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
        }
        else
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunSpecialBullet"), gunBarrel.transform.position /*+ new Vector3(Random.Range(0.2f, 0.8f), 0, 0)*/, gunBarrel.transform.rotation);
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + randomAngle);

            //GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunSpecialBullet"), playerHand.transform.position, playerHand.transform.rotation);
            //bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
        }
        attackCooldownCounter = attackCooldown;
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
