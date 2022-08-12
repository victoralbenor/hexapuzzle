using System;
using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float duration;
    public KeyCode rotateKey;

    private void Update()
    {
        if(Input.GetKeyDown(rotateKey))
            StartCoroutine(RotateSmoothly(Vector3.up * 60f, duration));
    }

    private IEnumerator RotateSmoothly(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }
}