using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour {

    Rigidbody myBody;
    LineRenderer rope;

    public bool isHooked = false;

    public GameObject firePoint;
    public Vector3 firePointPos;




    public int travelSpeed;
    public float hookCurrDistance;
    public float hookMaxDistance;
    public float hookMaxCloseness;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.isKinematic = false;
        myBody.velocity = transform.forward * travelSpeed * Time.deltaTime;

        firePoint = GameObject.FindGameObjectWithTag("FP");
        rope = GetComponent<LineRenderer>();


        

        

        //Destroy(this.gameObject, 2);
    }

    private void Update()
    {
        firePointPos =  firePoint.transform.position;
        
        rope.SetPosition(0, transform.position);
        rope.SetPosition(1, firePointPos);

        hookCurrDistance = Vector3.Distance(transform.position, firePoint.transform.position);
        if(hookCurrDistance > hookMaxDistance)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetMouseButtonDown(1) && myBody.isKinematic == true)
        {
            Destroy(this.gameObject);
        }

        if (myBody.isKinematic == true)
        {
            isHooked = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        myBody.isKinematic = true;

        GameObject newHookParent = collision.gameObject;
        this.transform.parent = newHookParent.transform;

        
    }
}
