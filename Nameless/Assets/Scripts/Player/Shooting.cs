using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool canShoot = true;
    public Transform firePoint;
    public GameObject bulletPrefeab;
    ObjectPooler objectPooler; 
	
	
    void Start()
    {
        objectPooler = ObjectPooler.Instance; 
    }

    public void ShootControl(string trigger)
    {
        if(Input.GetAxisRaw(trigger) != 0)
        {
            if(canShoot)
            {
                Debug.Log(trigger);
                Shoot();
            }  
        }
    }
       
    public void Shoot()
    {
        objectPooler.SpawnFromPool("Bullet", firePoint.transform.position, firePoint.transform.rotation);
        canShoot = false;
        StartCoroutine(BulletCooldown(0.5f));
    }

    IEnumerator BulletCooldown(float cooldown)
    {
        while(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            yield return null;
        }
        canShoot = true;
    }
}
