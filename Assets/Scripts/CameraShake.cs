using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from www.youtube.com/watch?v=9A9yj8KnM8c
//Channel: Brackeys
//Title of video: CAMERA SHAKE in Unity, released 25 Feb. 2018

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        //Debug.Log("Shake!");


        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            if (Time.timeScale == 0)
            {
                yield break;
            }

            float scale = Mathf.Lerp(magnitude, 0, elapsed / duration);
            
            float x = Random.Range(-1, 1) * scale;
            float y = Random.Range(-1, 1) * scale;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed = elapsed + Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
