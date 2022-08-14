using System;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public string materialName;

    private void Start()
    {
        materialName = GetComponent<MeshRenderer>().material.name;
    }
}