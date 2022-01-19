using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj3 : MonoBehaviour
{
    ///knock all of x blocks 
    public GameObject Strct;
    private Component[] RBs;
    // Start set the randomly selected structure
    void Start()
    {
        Strct.transform.position = new Vector3(0, 0, 0);
        RBs = Strct.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody brick in RBs)
            brick.isKinematic = false;
    }
}
