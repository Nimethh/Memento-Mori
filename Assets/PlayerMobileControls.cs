using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileControls : MonoBehaviour
{
    public Joystick movJoystick;
    public Joystick shootJoystick;
    // public Button empButton;
    // public Button specialButton;
    void Start()
    {
        GameObject health = GameObject.Find("HUD/ActualHUD");
        RectTransform healthTransform = health.GetComponent<RectTransform>();
        healthTransform.anchoredPosition = new Vector2(160, healthTransform.anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
