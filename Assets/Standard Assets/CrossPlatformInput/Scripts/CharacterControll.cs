using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterControll : MonoBehaviour
{
    public float speed = 0.3f;
    private Quaternion quat;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        
        transform.Rotate(new Vector3(x, y, 0));
        transform.position += transform.forward * Time.deltaTime * speed;


        /* 
        if (!x.Equals(0) && !y.Equals(0))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
            Mathf.Atan2(x,y) * Mathf.Rad2Deg ,transform.eulerAngles.z);
        }

        if (!x.Equals(0) || !y.Equals(0))
        {
            Vector3 movement = new Vector3(x, 0, y);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else
        {

        }   
        */
    }

    public void PlaceCharacter() 
    {
        transform.localPosition = Vector3.zero;
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
         transform.rotation = Quaternion.FromToRotation(Vector3.zero, transform.forward);
    }
}
