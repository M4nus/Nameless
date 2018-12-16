using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefeab;
    ObjectPooler objectPooler;
	
	
    void Start()
    {
        objectPooler = ObjectPooler.Instance; 
    }

	

    public void shoot()
    {
        objectPooler.SpawnFromPool("Bullet", firePoint.transform.position, firePoint.transform.rotation);
        //Instantiate(bulletPrefeab, firePoint.position, firePoint.rotation);
    }
}
