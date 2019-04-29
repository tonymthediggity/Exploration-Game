using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour {

    public GameObject hookPrefab;
    HookScript hookScript;
    public GameObject player;
    public float speed;
    public float step;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        step = speed * Time.deltaTime;
    }

    public void Update()
    {
        hookPrefab = GameObject.Find("Hook(Clone)");
        hookScript = hookPrefab.GetComponent<HookScript>();

        if(hookScript.isHooked == true)
        {
            player.transform.position = Vector3.MoveTowards(transform.position, hookPrefab.transform.position, step);
            
        }
    }
}
