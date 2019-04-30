using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour {

    Rigidbody myBody;
    GameObject gun;
    GameObject player;
    Rigidbody playerBody;
    Rigidbody gunBody;
    LineRenderer rope;

    SpringJoint bodyJoint;

    public bool isHooked = false;
    public bool needsFixedJoint = true;
    public bool hasFixedJoint = false;

    public GameObject firePoint;
    public Vector3 firePointPos;

    public Vector3 position;
    public Vector3 posDifference;



    public float speed;
    float step;
    public int travelSpeed;
    public float hookCurrDistance;
    public float hookMaxDistance;
    public float hookMaxCloseness;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.isKinematic = false;
        myBody.velocity = transform.forward * travelSpeed * Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
        playerBody = player.GetComponent<Rigidbody>();
        bodyJoint = playerBody.GetComponent<SpringJoint>();

        

        firePoint = GameObject.FindGameObjectWithTag("FP");
        rope = GetComponent<LineRenderer>();
        speed = 44;


        

        

        //Destroy(this.gameObject, 2);
    }

    private void Update()
    {
        position = myBody.transform.position;
        posDifference = position  - playerBody.position;
        
       // direction = transform.position - playerBody.position;
       // if (hookCurrDistance > hookMaxCloseness && isHooked && Input.GetKey(KeyCode.LeftShift))
       // {
       //     playerBody.AddForce(posDifference * speed, ForceMode.Force);
        //}

        step = speed * Time.deltaTime;
        firePointPos =  firePoint.transform.position;
        
        rope.SetPosition(0, transform.position);
        rope.SetPosition(1, firePointPos);

        // = playerBody.gameObject.GetComponent<SpringJoint>();

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
            hasFixedJoint = true;
        }

        if (isHooked == true && needsFixedJoint == true)
        {
            AddFixedJoint();
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        myBody.isKinematic = true;

        GameObject newHookParent = collision.gameObject;
        this.transform.parent = newHookParent.transform;

        
    }

    void AddFixedJoint()
    {
        
       // FixedJoint hookJoint = gameObject.AddComponent<FixedJoint>();
        

        //hookJoint.connectedBody = playerBody;
        bodyJoint.connectedBody = GetComponentInParent<Rigidbody>();
        //playerJoint.anchor = hookJoint.transform.position;
        
        needsFixedJoint = false;


        
    }

    public void ReelIn()
    {




        
        




        // Moves correctly but without physics: 
        // player.transform.position = Vector3.MoveTowards(player.transform.position, this.transform.position, step);

    }
}
