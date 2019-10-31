using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerHealth)), RequireComponent(typeof(Combat))]
public class PlayerController : MonoBehaviour
{
    public float speed = 0.3f;
    private Quaternion quat;

    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Vertical");
        float y = CrossPlatformInputManager.GetAxis("Horizontal");

        transform.Rotate(new Vector3(x, y, 0));
        transform.position += transform.forward * Time.deltaTime * speed;
        // Debug.Log("Move to " + transform.position.ToString() + " time " + Time.deltaTime + " forward " + transform.forward.ToString() + " speed " + speed.ToString());


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

        if (true) // Todo: change to get key from input for player shooting
        {
            Combat combat = GetComponent<Combat>();
            if (combat != null)
            {
                combat.Attack();
            }
        }
    }

    public void PlaceCharacter()
    {
        var sound = gameObject.GetComponentInChildren<AudioSource>();
        sound.enabled = true;

        transform.localPosition = new Vector3(0, 1, 0);
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.FromToRotation(Vector3.zero, transform.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Health myHealth = GetComponent<Health>();
        if (myHealth != null)
        {
            myHealth.ModifyHealth(int.MaxValue);
        }
    }
}
