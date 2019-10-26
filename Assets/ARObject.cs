using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObject : MonoBehaviour
{
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -70f) 
        {
            Strike();
        }
    }

    void Strike()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, 0f, 0f);
        transform.position = pos;
        
    }

    void OnCollisionEnter(Collision other)
    {
        //Make blast sound
        //Recude live
        Strike();
    }
}
