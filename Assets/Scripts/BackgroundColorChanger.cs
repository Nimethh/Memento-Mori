using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] backgroundSprites;

    private Color redHue;
    private Color normal;

    void Start()
    {
        redHue = new Color(1f, 0.16f, 0.16f, 1f);
        normal = new Color(1, 1, 1, 1);

    }

    void Update()
    {
        
    }

    public void ChangeHueToRed()
    {
        Debug.Log("Changing Hue to Red");
        for (int i = 0; i < backgroundSprites.Length; i++)
        {
            backgroundSprites[i].color = redHue;
        }
    }

    public void ChangeBackToNormal()
    {
        Debug.Log("Changing Hue to Normal");

        for (int i = 0; i < backgroundSprites.Length; i++)
        {
            backgroundSprites[i].color = normal;
        }
    }

}
