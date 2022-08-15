using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Sphere : MonoBehaviour
{
    public GameObject effectsGameObject;
    [HideInInspector] public string materialName;
    
    private Animator _animator;
    private Material _material;
    private static readonly int Grow = Animator.StringToHash("Grow");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _material = GetComponent<MeshRenderer>().material;
        
        materialName = _material.name;
    }

    public void PlayAnimation()
    {
        _animator.SetTrigger(Grow);
    }

    // Called from animation event
    public void PlayEffects()
    {
        var psObj = Instantiate(effectsGameObject, transform.position, Quaternion.identity);
        var particleSystemMain = psObj.GetComponent<ParticleSystem>().main;
        particleSystemMain.startColor = _material.color;
        DestroySphere();
    }

    private void DestroySphere()
    {
        Destroy(gameObject);
    }

}