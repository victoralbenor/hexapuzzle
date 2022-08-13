using System;
using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float duration;

    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;
    private LayerMask _layerMask;
    private bool _isRotating;
    private Quaternion _targetRotation;
    public float rotateSpeed;
    private float _t;

    private void Start()
    {
        _mainCamera = Camera.main;
        _layerMask = LayerMask.GetMask("Hexagon");
    }
    
    private void Update()
    {
        if (_isRotating)
        {
            _t += rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _t);
            if (_t >= 1f) _isRotating = false;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit, 1000f, _layerMask))
                {
                    if (_hit.transform == transform)
                    {
                        _isRotating = true;
                        _t = 0f;
                        _targetRotation = transform.rotation * Quaternion.AngleAxis(60f, Vector3.forward);
                    }
                }
            }
        }
    }
}