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

    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        attackCooldown = 0.2f;

    }

    public void Update()
    {
        if (attackCooldownCounter > 0)
        {
            attackCooldownCounter = attackCooldownCounter - Time.deltaTime;
        }
    }

    public void PreformAttack()
    {
        if (attackCooldownCounter > 0)
        {
            return;
        }

        Debug.Log("preformAttack - pistol ");
        GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), playerHand.transform.position, playerHand.transform.rotation);
        bullet.transform.rotation = playerHand.transform.GetChild(0).gameObject.transform.rotation;
        attackCooldownCounter = attackCooldown;
    }

    public void PreformSpecialAttack()
    {
        Debug.Log("preformSpecialAttack - pistol");
    }
}
