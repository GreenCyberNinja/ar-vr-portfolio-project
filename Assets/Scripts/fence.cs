using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fence : MonoBehaviour
{
void OnCollisionEnter(Collision other)
{    
    Debug.Log("splat");
    Destroy(other.gameObject);
}
}
