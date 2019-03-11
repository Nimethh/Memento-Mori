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

    void Start()
    {
        Cursor.visible = false;
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos - new Vector2(0,+0.3f);

        if(Input.GetMouseButtonDown(0))
        {
            renderer.sprite = cursorRed;
        }

        if(Input.GetMouseButtonUp(0))
        {
            renderer.sprite = cursorBlue;
        }

    }
}
