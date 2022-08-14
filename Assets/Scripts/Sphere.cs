using System;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [HideInInspector] public string materialName;
    private ParticleSystem _particleSystem;
    
    private void Start()
    {
        var material = GetComponent<MeshRenderer>().material;
        materialName = material.name;
        var particleSystemMain = _particleSystem.main;
        particleSystemMain.startColor = material.color;
    }
}