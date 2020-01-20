﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public AudioClip musicClipFour;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pickups")
        {
            musicSource.clip = musicClipFour;
            musicSource.Play();
        }
    }
}
