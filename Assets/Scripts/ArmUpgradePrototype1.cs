using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmUpgradePrototype1 : MonoBehaviour, IArmUpgrade
{
    [SerializeField]
    private GameObject gunBarrel;
    [SerializeField]
    private GameObject laserBeam;
    [SerializeField]
    private Animator anim;

    //Normal Bullets
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float attackCooldownCounter;

    //Laser
    [SerializeField]
    private float laserAttackCooldown;
    [SerializeField]
    private float laserAttackCooldownCounter;

    void Start()
    {
        gunBarrel = transform.Find("GunBarrel").gameObject;
        if(gunBarrel == null)
        {
            Debug.Log("Did not find GunBarrel object");
        }

        laserBeam = transform.Find("LaserBeam").gameObject;
        if(laserBeam == null)
        {
            Debug.Log("Did not find LaserBeam object");
        }

        anim = laserBeam.GetComponent<Animator>();
        if(anim == null)
        {
            Debug.Log("Did not find Animator on the laserBeam object");
        }


        attackCooldown = 0.2f;

        laserAttackCooldown = 10f;
        laserAttackCooldownCounter = 0;

    }

    void Update()
    {
        //Normal Bullet
        if (attackCooldownCounter > 0)
        {
            attackCooldownCounter = attackCooldownCounter - Time.deltaTime;
        }

        //Laser
        if (laserAttackCooldownCounter > 0)
        {
            laserAttackCooldownCounter = laserAttackCooldownCounter - Time.deltaTime;
        }

    }

    public void PreformAttack()
    {
        if (attackCooldownCounter > 0)
        {
            return;
        }

        Debug.Log("preformAttack - armWeapon ");
        GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), gunBarrel.transform.position, gunBarrel.transform.rotation);
        bullet.transform.rotation = gunBarrel.transform.gameObject.transform.rotation;
        attackCooldownCounter = attackCooldown;
    }

    public void PreformAbility()
    {
        Debug.Log("ArmUpgrade PreformAbility() Called");

        if (laserAttackCooldownCounter > 0)
        {
            return;
        }

        Debug.Log("preformSpecialAttack() - lasergun");

        anim.SetTrigger("FireLaser");
        laserAttackCooldownCounter = laserAttackCooldown;

        //weeapon overheat
        attackCooldownCounter += 3.0f;
    }
}
