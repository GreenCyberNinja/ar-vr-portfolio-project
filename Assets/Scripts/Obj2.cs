using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obj2 : MonoBehaviour
{
    /// objective 2 is remove x in y amount of time
    public GameObject Strct, GM;
    private Component[] RBs;
    bool timerIsRunning = false;
    int x, curnumbrk, minblock = 20, maxblock = 0;
    public float maxtime;
    public float y;
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
        x = Random.Range(minblock, maxblock);
        y = Random.Range(30, maxtime);
        StartCoroutine(DisplayObj());
    }

    private void Update()
    {
        if (timerIsRunning)
            if (y >= 0)
            {
                y -= Time.deltaTime;
                if (curnumbrk >= x)
                {
                    timerIsRunning = false;
                    GM.GetComponent<GameMaster>().GameWin();
                    GM.GetComponent<GameMaster>().ReturnStructure(Strct);
                    this.enabled = false;
                }
            }
            else
            {
                timerIsRunning = false;
                GM.GetComponent<GameMaster>().GameLose();
                GM.GetComponent<GameMaster>().ReturnStructure(Strct);
                this.enabled = false;
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
