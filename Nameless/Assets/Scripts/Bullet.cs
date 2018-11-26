using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject {

    public float speed = 20f;
    public Rigidbody2D rb;

	// Use this for initialization
	/*void Start () {
        rb.velocity = transform.up * speed;
       // Destroy(gameObject);
	}*/

    void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log(obj.name);
        Destroy(gameObject);
    }
	
    public void OnObjectSpawn()
    {
        rb.velocity = transform.up * speed;
    }
	
}
