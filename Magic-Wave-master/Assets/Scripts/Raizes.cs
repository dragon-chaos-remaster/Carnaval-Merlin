﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raizes : MonoBehaviour
{
    Rigidbody fisica;
    public Transform raizes;
    public float velocidadeProjetil;
    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        raizes = GetComponent<Transform>();

        fisica.AddForce(raizes.forward * velocidadeProjetil);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
