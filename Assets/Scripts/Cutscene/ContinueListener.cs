using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueListener : MonoBehaviour
{
    [SerializeField]
    private string SceneToChangeTo;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(SceneToChangeTo);
        }
    }
}
