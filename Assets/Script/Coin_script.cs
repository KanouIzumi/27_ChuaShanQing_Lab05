﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_script : MonoBehaviour
{
    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));
    }
}
