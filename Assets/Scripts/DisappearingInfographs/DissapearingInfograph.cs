using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissapearingInfograph : MonoBehaviour
{
    [SerializeField]
    private float ActiveTime;

    void Update()
    {
        ActiveTime = ActiveTime - Time.unscaledDeltaTime;
        if(ActiveTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
