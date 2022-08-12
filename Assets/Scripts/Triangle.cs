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
            if (canLog) Debug.Log($"{name} from {transform.parent.parent.name} is adjacent to {hit.transform.name} from {hit.transform.parent.parent.name}");
            _adjacentTriangle = hit.transform.GetComponent<Triangle>();
        }
            
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log(other.GetComponent<MeshRenderer>().material.name);
        sphere = col.GetComponent<Sphere>();
        if (_adjacentTriangle && _adjacentTriangle.sphere)
        {
            Debug.Log("Tenho adj");
            if (sphere.transform.GetComponent<MeshRenderer>().material.name ==
                _adjacentTriangle.sphere.transform.GetComponent<MeshRenderer>().material.name)
            {
                Debug.Log("Cor igual");
                Destroy(_adjacentTriangle.sphere.gameObject);
                Destroy(sphere.gameObject);
            }
        }
    }
}