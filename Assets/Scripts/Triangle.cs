using UnityEngine;

public class Triangle : MonoBehaviour
{
    public bool canLog;
    public Sphere sphere; 
    public Triangle _adjacentTriangle;
     

    private void Start()
    {
        var rayOrigin = transform.position + Vector3.up * 0.5f + transform.right * -0.85f;
        var rayDirection = transform.right * -0.5f;
        if (Physics.Raycast(rayOrigin,
                rayDirection,
                out var hit
            ))
        {
            _adjacentTriangle = hit.transform.GetComponent<Triangle>();
        }
            
    }

    // After rotation, sphere enters new triangle
    private void OnTriggerEnter(Collider col)
    {
        // Get incoming sphere
        if(!col.TryGetComponent<Sphere>(out var s)) return;
        sphere = s;
        
        if (_adjacentTriangle && _adjacentTriangle.sphere)
        {
            if (!sphere.transform.TryGetComponent<MeshRenderer>(out var sphereMeshRenderer)) return;

            if (sphereMeshRenderer.material.name ==
                _adjacentTriangle.sphere.transform.GetComponent<MeshRenderer>().material.name)
            {
                Debug.Log("Cor igual");
                Destroy(_adjacentTriangle.sphere.gameObject);
                Destroy(sphere.gameObject);
            }
        }
    }
}