using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    public bool isActive;
    public float platformTimer;
    public AudioSource[] sounds;

    public PlayerBehaviour player;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        platformTimer = 0;
        isActive = false;
        sounds = GetComponents<AudioSource>();
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            platformTimer += Time.deltaTime *0.2f;
            _Shrink();
        }
        if (isActive == false)
        {
            if (transform.localScale != scale)
            {
                Debug.Log("regrowing");
                platformTimer += Time.deltaTime;
                transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), scale, platformTimer);
                if (!sounds[1].isPlaying)
                    sounds[1].Play();

            }
           if(transform.localScale == scale) platformTimer = 0;
        }
       
    }

    private void _Shrink()
    {
        if (transform.localScale != new Vector3(0, 0, 0))
        {
            transform.localScale = Vector3.Lerp(scale, new Vector3(0, 0, 0), platformTimer);
            if (!sounds[0].isPlaying)
                sounds[0].Play();
        }
       if(transform.localScale == new Vector3(0,0,0))
        {
            isActive = false;

            platformTimer = 0;
        } 
    }
}
