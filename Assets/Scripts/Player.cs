﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float maxSpeed = 5f;
    float rotSpeed = 180f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;
        // these codes perform the moses
    }
}