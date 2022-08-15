using UnityEngine;
using UnityEngine.Serialization;

public class Slice : MonoBehaviour
{
    [HideInInspector] public Sphere sphere;
    private Slice _adjacentSlice;

    private void Start()
    {
        // Save references to the adjacent slices
        var rayOrigin = transform.position + Vector3.up * 0.5f + transform.right * -0.85f;
        var rayDirection = transform.right * -0.5f;
        if (Physics.Raycast(rayOrigin, rayDirection, out var hit))
            _adjacentSlice = hit.transform.GetComponent<Slice>();
    }

    // After rotation, new sphere enters the slice
    private void OnTriggerEnter(Collider col)
    {
        // Make sure it is a sphere, then save its reference
        if (!col.TryGetComponent<Sphere>(out var s)) return;
        sphere = s;

        if (!_adjacentSlice || !_adjacentSlice.sphere) return; // Do I have an adjacent slice that contains a sphere?
        if (sphere.materialName != _adjacentSlice.sphere.materialName) return; // Are the material names the same?  
        _adjacentSlice.sphere.PlayAnimation();
        sphere.PlayAnimation();
    }
}