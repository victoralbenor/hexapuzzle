using UnityEngine;
using UnityEngine.Serialization;

public class Rotate : MonoBehaviour
{
    [FormerlySerializedAs("rotateSpeed")] public float speed;

    private Camera _mainCamera;
    private float _rotationProgress;
    private LayerMask _clickLayerMask;
    private Quaternion _targetRotation;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rotationProgress = 1f;
        _clickLayerMask = 1 << gameObject.layer;
    }
    
    private void Update()
    {
        if (_rotationProgress >= 1f) CheckForInput(); 
        else ContinueRotation(); 
    }

    private void CheckForInput()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit, 1000f, _clickLayerMask)) return;
        if (hit.transform != transform) return;
        _rotationProgress = 0f;
        _targetRotation = transform.rotation * Quaternion.AngleAxis(60f, Vector3.forward);
    }

    private void ContinueRotation()
    {
        _rotationProgress += speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _rotationProgress);
    }
}