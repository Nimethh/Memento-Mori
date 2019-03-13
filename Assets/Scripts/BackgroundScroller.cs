using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    
    [SerializeField]
    private float quadLength;
    [SerializeField]
    private float scrollingSpeed;

    private AudioSource aS;

    private Vector3 startPosition;

	void Start ()
    {
        startPosition = transform.position;
        aS = GetComponent<AudioSource>();
        aS.Play();
	}
	
	void Update ()
    {
        float updatePosition = Mathf.Repeat(Time.time * scrollingSpeed, quadLength);
        transform.position = startPosition + Vector3.left * updatePosition;
	}
}
