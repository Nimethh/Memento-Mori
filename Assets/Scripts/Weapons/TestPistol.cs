using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPistol : MonoBehaviour, IWeapon
{
    public GameObject playerHand;
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float attackCooldownCounter;

    [SerializeField]
    private float maxBulletSpreadAngle;


    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        attackCooldown = 0.2f;

        maxBulletSpreadAngle = 2f;
    }

    public void Update()
    {
        if (attackCooldownCounter > 0)
        {
            attackCooldownCounter = attackCooldownCounter - Time.deltaTime;
        }
    }

    public void PreformAttack(float rotationZ)
    {
        if (attackCooldownCounter > 0)
        {
            return;
        }

        float randomAngle = Random.Range((-maxBulletSpreadAngle / 2), (maxBulletSpreadAngle / 2));

        //rotationZ = Mathf.Clamp(rotationZ, minAngle, maxAngle);

        GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), playerHand.transform.position + new Vector3(Random.Range(0.2f, 0.8f), 0, 0), playerHand.transform.rotation);
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + randomAngle);

        ////Debug.Log("preformAttack - pistol ");
        //GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), playerHand.transform.position, playerHand.transform.rotation);
        //bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
        attackCooldownCounter = attackCooldown;
    }

    public void PreformSpecialAttack()
    {
        //Debug.Log("preformSpecialAttack - pistol");
    }
}
