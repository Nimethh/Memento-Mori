using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderDeath : MonoBehaviour
{
    public float fallDelay = 3f;
    public float fallLength = 5f;
    public GameObject explosion;
    public Vector3 fallEndPosition = new Vector3();
    private Vector3 tmpPos = new Vector3();

    private Animator animation;
    private float startTime;
    private bool afterFallTriggered;
    void Start()
    {
        animation = GetComponent<Animator>();
        startTime = -1f;
        afterFallTriggered = false;
        FindObjectOfType<AudioManager>().Play("CommanderDestroyed");
    }

    // Update is called once per frame
    void Update()
    {
        // Play death sound

        // Final fall
        if (animation.GetCurrentAnimatorStateInfo(0).IsName("DeathFall")) {
            if(startTime < 0) {
                startTime = Time.time;
            }

            else {
                float timeDif = Time.time - startTime;
                float fallProgress = timeDif - fallDelay;
                float fallProgressNorm = fallProgress / fallLength;

                // Execute fall
                if(timeDif >= fallDelay && fallProgress < fallLength) {
                    transform.position = Vector3.Lerp(transform.position, fallEndPosition, fallProgressNorm);
                }

                // After fall
                if(fallProgressNorm >= 0.65f && !afterFallTriggered) {
                    afterFallTriggered = true;

                    // Shake camera
                    Debug.Log("Commander death shake started");
                    CameraShake shake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
                    shake.StartCoroutine(shake.Shake(2f, 0.5f));
                    // Spawn explosion
                    Vector3 explosionPos = new Vector3(fallEndPosition.x, -7f, fallEndPosition.z);
                    GameObject explosionObj = Instantiate(explosion, explosionPos, new Quaternion());
                    explosionObj.transform.localScale = new Vector3(2f, 2.5f, 2f);
                    explosionObj.layer = LayerMask.NameToLayer("Background");
                }

                // After explosion
                if(fallProgressNorm >= 2f && afterFallTriggered) {
                    Destroy(gameObject);
                }
            }
        }
    }
    
    public void PlayDeathSound()
    {
        FindObjectOfType<AudioManager>().Play("CommanderDestroyed");
    }
}
