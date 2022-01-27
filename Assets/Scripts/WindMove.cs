using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMove : MonoBehaviour
{
    public Vector3 playerORGN, windPos;

     public Vector3 dir;
     public float power;
    float moveSpeed = 5f;
    float Dis;
    public bool moveNow = false;
    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3((windPos.x - playerORGN.x), 0, (windPos.z - playerORGN.z));
        dir.Normalize();

    }

    // Update is called once per frame
    void Update()
    {
        if (moveNow)
        {
            //moves the wind away
            this.transform.position = transform.position + dir * moveSpeed * Time.deltaTime;
            Dis = Vector3.Distance(windPos, transform.position);
            power = power - Dis;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
            Destroy(this.gameObject);
        if (other.tag == "Block")
        {
            other.attachedRigidbody.AddForce(transform.position * power);
        }    
    }
}
