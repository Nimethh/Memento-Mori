using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadUpgradePrototype1 : MonoBehaviour, IUpgrade
{
    [SerializeField]
    private float abilityCooldown;
    [SerializeField]
    private float abilityCooldownCounter;

    [SerializeField]
    private float slowDownDuration;
    [SerializeField]
    private float slowDownTimeRemaining;
    [SerializeField]
    private float slowDownScale;

    private void Start()
    {
        abilityCooldown = 15f;
        abilityCooldownCounter = 0f;
        slowDownDuration = 5f;
        slowDownScale = 0.4f;
    }

    void Update()
    {
        if (abilityCooldownCounter > 0)
        {
            abilityCooldownCounter = abilityCooldownCounter - Time.deltaTime;
        }

        if (slowDownTimeRemaining > 0)
        {
            slowDownTimeRemaining -= Time.unscaledDeltaTime; //This might be wrong.
            if(slowDownTimeRemaining <= 0)
            {
                Time.timeScale = 1;
            }
        }
    }

    public void PreformAbility()
    {
        Debug.Log("PreformAbility() - HeadUpgradePrototype1");

        if (abilityCooldownCounter > 0)
        {
            return;
        }

        SlowDownTime();
        abilityCooldownCounter = abilityCooldown;
    }

    private void SlowDownTime()
    {
        Time.timeScale = slowDownScale;
        slowDownTimeRemaining = slowDownDuration;
    }

}
