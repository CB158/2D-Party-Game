﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
