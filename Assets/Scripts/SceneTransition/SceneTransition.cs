using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneNameWith;
    public string nextSceneNameWithout;
    public void LoadSceneWithoutUpgrade(string p_nextSceneNameWith)
    {
        nextSceneNameWith = p_nextSceneNameWith;
        SceneManager.LoadScene(p_nextSceneNameWith);
    }

    public void LoadSceneWithUpgrade(string p_nextSceneNameWithout)
    {
        nextSceneNameWithout = p_nextSceneNameWithout;
        SceneManager.LoadScene(p_nextSceneNameWithout);
    }
}
