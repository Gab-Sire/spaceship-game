using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{

    public GameObject missilePrefab;
    Transform firePoint;

    void Start()
    {
        firePoint = GetComponent<Transform>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.origin + (ray.direction *);
            Debug.Log("World point " + point);*/

            GameObject missile = Instantiate(missilePrefab, firePoint.transform.position, transform.rotation);
            missile.GetComponent<Missile>().target = GameObject.Find("target").transform;
        }
    }
}
