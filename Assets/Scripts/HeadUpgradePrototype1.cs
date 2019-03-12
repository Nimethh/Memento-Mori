﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    BackgroundColorChanger backgroundChanger;

    public Slider HeadOnEffectSlider;
    public Slider HeadOnCooldownSlider;




    private void Start()
    {
        backgroundChanger = GameObject.FindGameObjectWithTag("Background").gameObject.GetComponent<BackgroundColorChanger>();

        HeadOnEffectSlider = GameObject.Find("HeadUpgradeOnEffect").GetComponent<Slider>();
        HeadOnCooldownSlider = GameObject.Find("HeadUpgradeOnCooldown").GetComponent<Slider>();

        abilityCooldown = 15f;
        abilityCooldownCounter = 0f;
        slowDownDuration = 10f;
        slowDownScale = 0.3f;
    }

    void Update()
    {
        if (abilityCooldownCounter > 0)
        {
            abilityCooldownCounter = abilityCooldownCounter - Time.deltaTime;
            if(slowDownTimeRemaining <= 0)
            {
                HeadOnCooldownSlider.maxValue = (abilityCooldown - slowDownDuration);
                HeadOnCooldownSlider.value = (abilityCooldownCounter);// - (abilityCooldown - slowDownDuration);
                Debug.Log("CooldownSlider value: " + HeadOnCooldownSlider.value);
            }
        }

        if (slowDownTimeRemaining > 0)
        {
            HeadOnEffectSlider.value = (slowDownTimeRemaining / slowDownDuration);
            slowDownTimeRemaining -= Time.unscaledDeltaTime; //This might be wrong.
            if (slowDownTimeRemaining <= 0)
            {
                HeadOnEffectSlider.value = 0;
                backgroundChanger.ChangeBackToNormal();
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
        //Time.timeScale = slowDownScale;
        slowDownTimeRemaining = slowDownDuration;

        StartCoroutine(SlowDown());

        backgroundChanger.ChangeHueToRed();
    }


    public IEnumerator SlowDown()
    {
        //float duration = 10.0f;
        float elapsedTime = 0.0f;
        float easeIntoSlowMotionTime = 2f;
        float easeBackToNormalSpeed = 2f;
        float easeFactor = 0.01f;

        while(elapsedTime < slowDownDuration)
        {
            if (elapsedTime < easeIntoSlowMotionTime)
            {
                Time.timeScale -= easeFactor;
                if (Time.timeScale < slowDownScale)
                {
                    Time.timeScale = slowDownScale;
                }
            }

            //if (elapsedTime > (duration - easeBackToNormalSpeed))
            if (elapsedTime > (slowDownDuration - easeBackToNormalSpeed))
            {
                Time.timeScale += easeFactor;
                if (Time.timeScale > 1)
                {
                    Time.timeScale = 1;
                }
            }

            elapsedTime += Time.unscaledDeltaTime;
            //Debug.Log(elapsedTime + " " + Time.timeScale);

            yield return null;
        }

        Time.timeScale = 1;

    }
}
