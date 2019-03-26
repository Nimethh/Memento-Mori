using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLaserGun : MonoBehaviour, IWeapon
{
    public GameObject playerHand;
    private GameObject beam;

    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private float attackCooldownCounter;
    [SerializeField]
    private float attackActiveTime;
    [SerializeField]
    private float attackActiveCounter;
    [SerializeField]
    private bool attackActivated;



    public void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").gameObject;
        beam = transform.Find("Beam").gameObject;
        beam.SetActive(false);

        attackCooldown = 10f;
        attackCooldownCounter = 0;
        attackActiveTime = 1.0f;
        attackActiveCounter = 0f;
        attackActivated = false;
    }

    public void Update()
    {
        if(attackCooldownCounter > 0)
        {
            attackCooldownCounter = attackCooldownCounter - Time.deltaTime;
        }

        if(attackActivated == true)
        {
            attackActiveCounter = attackActiveCounter - Time.deltaTime;
            if(attackActiveCounter <= 0)
            {
                beam.SetActive(false);
                attackActivated = false;
            }
        }
    }

    public void PreformAttack(float angle)
    {
        if(attackCooldownCounter > 0)
        {
            return;
        }

        Debug.Log("preformAttack - lasergun");
        beam.SetActive(true);
        attackActivated = true;
        attackActiveCounter = attackActiveTime;
        attackCooldownCounter = attackCooldown;
    }

    public void PreformSpecialAttack()
    {
        Debug.Log("preformSpecialAttack - lasergun");
    }

}
