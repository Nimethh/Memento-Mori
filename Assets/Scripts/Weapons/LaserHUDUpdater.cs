using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaserHUDUpdater : MonoBehaviour
{
    public Slider ArmOnEffectSlider;
    public Slider ArmOnCooldownSlider;

    public float effectValue;
    public float cooldownValue;
    public bool canFireLaser;



    void Start()
    {
        ArmOnEffectSlider = GameObject.Find("ArmUpgradeOnEffect").GetComponent<Slider>();
        ArmOnCooldownSlider = GameObject.Find("ArmUpgradeOnCooldown").GetComponent<Slider>();
        canFireLaser = true;
    }


    private void Update()
    {
        ArmOnEffectSlider.value = effectValue;
        ArmOnCooldownSlider.value = cooldownValue;
    }

    public void LaserSound()
    {
        FindObjectOfType<AudioManager>().Play("PlayerLaser");
    }
}
