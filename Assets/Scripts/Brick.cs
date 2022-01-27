using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Vector3 origin;
    public Quaternion originRotation;
    Rigidbody rb;
    Collider col;
    Renderer ren;
    
    // Start sets the variables to be used for the repositions
    void Start()
    {
        origin = this.transform.localPosition;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        ren = GetComponent<MeshRenderer>();
    }

   public void RePosition()
    {
        this.transform.localPosition = origin;
        this.transform.rotation = originRotation;
        rb.isKinematic = true;
        col.enabled = false;
        ren.enabled = false;
    }

}
