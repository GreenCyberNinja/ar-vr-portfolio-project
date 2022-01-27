using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj1 : MonoBehaviour
{
    /// objective1 knock over all blocks within x amount of time
    public GameObject Strct, GM;
    private Component[] RBs;
    public int curnumbrk = 0, maxblock = 0, maxtime = 45;
    float y = 0;
    bool timerIsRunning = false;

    // Start set the randomly selected structure
    void Start()
    {
        Strct.transform.position = new Vector3(0, 0, 0);
        RBs = Strct.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody brick in RBs)
        {
            maxblock += 1;
            brick.isKinematic = false;
        }
        y = Random.Range(30, maxtime);
        StartCoroutine(DisplayObj());
    }
    private void Update()
    {
        if (timerIsRunning)
        {
            y -= Time.deltaTime;
            if (y <= 0)
            {

            }
        }
    }
    IEnumerator DisplayObj()
    {
        timerIsRunning = false;
        yield return new WaitForSeconds(5);
        timerIsRunning = true;
    }
    private void OnTriggerEnter(Collider other) 
    {
        curnumbrk += 1;
        other.GetComponent<Brick>().RePosition();
    }
}
