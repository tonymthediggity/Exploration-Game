using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    Rigidbody myBody;


    public int travelSpeed;
    public int damage;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();

        myBody.velocity = transform.forward * travelSpeed * Time.deltaTime;

        Destroy(this.gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
    
            Destroy(this.gameObject);
        
    }


}
