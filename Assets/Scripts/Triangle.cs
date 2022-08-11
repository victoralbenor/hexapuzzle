using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public bool canLog;
    private void OnTriggerEnter(Collider other)
    {
        if(canLog) Debug.Log(other.GetComponent<MeshRenderer>().material.name);
    }
}
