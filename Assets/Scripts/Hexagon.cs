using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    private Queue<GameObject> spheres = new Queue<GameObject>();
    public int[] adjacentSpheres;

    private void Start()
    {
        foreach (Transform child in transform)
            spheres.Enqueue(child.gameObject);
    }

    private void LogicallyRotateHex()
    {
        for (var i = 0; i < spheres.Count - 1; i++)
        {
            spheres.Enqueue(spheres.Dequeue());
        }
    }

    private void LogHexColors()
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            Debug.Log(i + " " + spheres.ElementAt(i).GetComponent<MeshRenderer>().material.name);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) LogHexColors();
        if(Input.GetKeyDown(KeyCode.Alpha2)) LogicallyRotateHex();
    }
}
