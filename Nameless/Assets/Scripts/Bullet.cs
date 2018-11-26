using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{

    public float speed = 20f;
    public Rigidbody2D rb;
                  
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        this.gameObject.SetActive(false);
    }
	
    public void OnObjectSpawn()
    {
        rb.velocity = transform.up * speed;
    }
	
}
