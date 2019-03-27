using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EMPListener : MonoBehaviour
{
    [SerializeField]
    private string LevelToChangeTo;
    public bool activated = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("ControlRobot").GetComponent<BossHealth>().Die();
            activated = true;
        }
    }
}
