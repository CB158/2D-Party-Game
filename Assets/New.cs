using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip musicClipOne;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        musicSource.clip = musicClipOne;
        musicSource.Play();
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
