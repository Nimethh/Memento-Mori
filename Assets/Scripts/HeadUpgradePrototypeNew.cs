using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadUpgradePrototypeNew : MonoBehaviour, IUpgrade
{
    [SerializeField]
    private bool canUseAbility;

    [SerializeField]
    private float slowDownFactor;

    [SerializeField]
    private float abilityCooldownTimerValue;
    [SerializeField]
    private float activationTimerValue;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    BackgroundColorChanger backgroundChanger;

    public Slider HeadOnEffectSlider;
    public Slider HeadOnCooldownSlider;




    private void Start()
    {
        anim = GetComponent<Animator>();

        backgroundChanger = GameObject.FindGameObjectWithTag("Background").gameObject.GetComponent<BackgroundColorChanger>();

        HeadOnEffectSlider = GameObject.Find("HeadUpgradeOnEffect").GetComponent<Slider>();
        HeadOnCooldownSlider = GameObject.Find("HeadUpgradeOnCooldown").GetComponent<Slider>();
    }

    void Update()
    {
        Time.timeScale = slowDownFactor;
        HeadOnCooldownSlider.value = abilityCooldownTimerValue;
        HeadOnEffectSlider.value = activationTimerValue;
    }

    public void PreformAbility()
    {
        Debug.Log("PreformAbility() - HeadUpgradePrototype1");

        if (canUseAbility == false)
        {
            return;
        }

        anim.SetTrigger("SlowDownTime");
    }

}
