using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArmUpgradePrototype1 : MonoBehaviour, IArmUpgrade
{
    [SerializeField]
    private GameObject playerHand;
    [SerializeField]
    private GameObject gunBarrel;
    [SerializeField]
    private GameObject laserBeam;
    [SerializeField]
    private LaserHUDUpdater HUDUpdater;
    [SerializeField]
    private bool canFireLaser;

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

    [SerializeField]
    private Slider ArmOnEffectSlider;
    [SerializeField]
    private Slider ArmOnCooldownSlider;

    void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;

        playerHand.GetComponent<SpriteRenderer>().enabled = false;


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

        HUDUpdater = laserBeam.GetComponent<LaserHUDUpdater>();

        anim = laserBeam.GetComponent<Animator>();
        if(anim == null)
        {
            Debug.Log("Did not find Animator on the laserBeam object");
        }


        attackCooldown = 0.1f;

        laserAttackCooldown = 15f;
        laserAttackCooldownCounter = 0;

        ArmOnEffectSlider = GameObject.Find("ArmUpgradeOnEffect").GetComponent<Slider>();
        ArmOnCooldownSlider = GameObject.Find("ArmUpgradeOnCooldown").GetComponent<Slider>();
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
        if (attackCooldownCounter > 0 || ArmOnEffectSlider.value > 0)
        {
            return;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees

        Debug.Log("preformAttack - armWeapon ");
        GameObject bullet = (GameObject)Instantiate(Resources.Load<GameObject>("Bullets/GunBullet"), gunBarrel.transform.position, gunBarrel.transform.rotation);
        //bullet.transform.rotation = gunBarrel.transform.rotation;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        attackCooldownCounter = attackCooldown;
    }

    public void PreformAbility()
    {
        Debug.Log("ArmUpgrade PreformAbility() Called");

        //if (laserAttackCooldownCounter > 0)
        //{
        //    return;
        //}

        canFireLaser = HUDUpdater.canFireLaser;
        if (canFireLaser == false)
        {
            return;
        }

        Debug.Log("preformSpecialAttack() - lasergun");

        anim.SetTrigger("FireLaser");
        laserAttackCooldownCounter = laserAttackCooldown;

        //weeapon overheat
        attackCooldownCounter += 7.0f;
    }

}
