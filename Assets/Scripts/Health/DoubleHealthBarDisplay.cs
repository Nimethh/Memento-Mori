using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleHealthBarDisplay : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarRight;
    [SerializeField]
    private Slider healthBarLeft;

    private IHealth health;

    void Start()
    {
        health = GetComponent<IHealth>();

        healthBarRight.maxValue = health.GetHealth();
        healthBarLeft.maxValue = health.GetHealth();
        healthBarRight.value = health.GetHealth();
        healthBarLeft.value = health.GetHealth();
    }

    void Update()
    {
        healthBarRight.value = health.GetHealth();
        healthBarLeft.value = health.GetHealth();
    }
}
