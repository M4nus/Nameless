using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 5;

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        this.gameObject.SetActive(false);
        IHurtable o = col.gameObject.GetComponent<IHurtable>();

        if(o != null)
        {
            o.TakeDamage(damage);

            if(o.GetCurrentHealthPoints() <= 0)
            {
                o.Die();
            }

        }

        

    }


	
    public void OnObjectSpawn()
    {
        rb.velocity = transform.up * speed;
    }
	
}
