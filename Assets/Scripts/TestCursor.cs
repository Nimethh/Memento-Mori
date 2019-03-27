using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCursor : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField]
    public Sprite cursorBlue;
    [SerializeField]
    public Sprite cursorRed;

    [SerializeField]
    private PlayerUpgradeController upgradeController;

    void Start()
    {
        Cursor.visible = false;
        renderer = GetComponent<SpriteRenderer>();
        upgradeController = GameObject.Find("Player").GetComponent<PlayerUpgradeController>();
    }

    void Update()
    {
        if(GameObject.Find("AugmentationPanel") == true || GameObject.Find("GameOverMenu") == true || GameObject.Find("PauseMenu") == true)
        {
            Cursor.visible = true;
        }

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (upgradeController.ArmUpgradeIsEquipped() == true)
        {
            transform.position = cursorPos - new Vector2(0, +0.4f);
        }
        else
        {
            transform.position = cursorPos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            renderer.sprite = cursorRed;
        }

        if(Input.GetMouseButtonUp(0))
        {
            renderer.sprite = cursorBlue;
        }

    }
}
