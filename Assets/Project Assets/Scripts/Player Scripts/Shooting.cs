using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject hook;
    

    public GameObject bulletPrefab;
    public GameObject hookPrefab;

   

    public bool isShooting = false;
    public bool isHookActive = false;

    public int fireRate;
    

    private void Update()
    {
        hook = GameObject.Find("Hook(Clone)");





        if(hook == null)
        {
            isHookActive = false;
        }
       
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1) && isHookActive == false)
        {
            isHookActive = true;
            Grapple();
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    void Grapple()
    {
        Instantiate(hookPrefab, transform.position, transform.rotation);
    }




}
