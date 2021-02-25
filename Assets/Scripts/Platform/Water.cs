﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject respawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != null && other.CompareTag("Player") && PlayerManager._instance.rockState==RockStates.Fire)
        {
            other.transform.position = respawn.transform.position;
        }
    }
}
