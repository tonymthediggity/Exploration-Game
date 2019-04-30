using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour {

    //public GameObject hookPrefab;
    HookScript hookScript;
    public GameObject player;
    public Rigidbody playerBody;
    
    public float speed;
    public float step;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBody = player.GetComponent<Rigidbody>();
        speed = 6.5f;
        
    }

    public void Update()
    {
        //hookPrefab = GameObject.Find("Hook(Clone)");
        hookScript = GetComponent<HookScript>();

        step = speed * Time.deltaTime;

        if (hookScript.isHooked == true)
        {
            
         
           player.transform.position = Vector3.MoveTowards(player.transform.position, this.transform.position, step);
            
        }
    }
}
