using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHurtable{


    public int healthPoints;

    public float shootRange;
    public GameObject target;
    public Shooting shooting;
    public float shootingCooldown;
    public float speed = 10;

    private Vector3 moveX;
    private Vector3 moveY;
    private float actualCooldownTime;
    public double distanceToTarget;
    private float angleToTarget;
    public float xdis;
    public float ydis;
    //private Transform toMovePosition;
    
	void Start () {
        moveY = new Vector3(speed, 0, 0);
        moveX = new Vector3(0, speed, 0);
    }
	
	// Update is called once per frame
	void Update () {

        angleToTarget = Mathf.Atan(ydis / xdis);
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        //distanceToTarget = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) - Mathf.Pow(target.transform.position.y - transform.position.y, 2));
        //angleToTarget = Mathf.Asin( target.transform.position.y / distanceToTarget);
        ydis = (target.transform.position.y - transform.position.y);
        xdis = (target.transform.position.x - transform.position.x);


        if (distanceToTarget < shootRange  && actualCooldownTime <= 0 && (Mathf.Abs(xdis) < 0.1 || Mathf.Abs(ydis) < 0.1))
        {
           // Debug.Log("strzelaj!");
            shooting.shoot();
            actualCooldownTime = shootingCooldown;
        }

        lowerCooldown();
        faceTarget();

        
        move();
	}

    void lowerCooldown()
    {
        if(actualCooldownTime > 0)
        {
            actualCooldownTime -= Time.deltaTime;
        }
    }

    void faceTarget()
    {
        if(xdis >= 0 && ydis >= 0) //w góre
        {
            //Debug.Log("gora");
            transform.rotation = new Quaternion(0, 0, 90, 90);
            
        }
        else if (xdis < 0 && ydis > 0) // w lewo
        {
            //Debug.Log("lewo");
            transform.rotation = new Quaternion(0, 0, 180, 0);

        }
        else if (xdis < 0 && ydis < 0) // w dół
        {
            //Debug.Log("dol");
            transform.rotation = new Quaternion(0, 0, -90, 90);
        } 
        else if (xdis > 0 && ydis < 0) // w prawo
        {
           // Debug.Log("prawo");
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        /*if(angleToTarget > -Mathf.PI / 4 && angleToTarget <= Mathf.PI / 4 && xdis / ydis < 1 && xdis / ydis >= -1) // prawo
        {
            transform.rotation = new Quaternion(0, 0, 90, 90);
            
        }
        else if((angleToTarget >= Mathf.PI / 4 || angleToTarget > -Mathf.PI / 4)  && xdis / ydis > 1 && xdis / ydis >= -1) // gora
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if((angleToTarget <= - Mathf.PI / 4 || angleToTarget <= Mathf.PI / 4) && xdis / ydis >1 && xdis / ydis >= -1)
        {
            transform.rotation = new Quaternion(0, 0, -90, 90);
        }*/
    }

    void move()
    {



        if (Mathf.Abs(ydis) > 0.1 )
        {
            if(ydis >0.1 )
            {
                Vector3 my = moveY * Mathf.Sign(target.transform.position.y - transform.position.y);
                transform.Translate(my * Time.deltaTime * speed);
            }
            else
            {
                Vector3 my = moveY * -Mathf.Sign(target.transform.position.y - transform.position.y);
                transform.Translate(my * Time.deltaTime * speed);
            }
            
            
        }

        if (Mathf.Abs(xdis) > 0.1 )
        {
            if (xdis > 0.1 )
            {
                Vector3 mx = moveX * -Mathf.Sign(target.transform.position.x - transform.position.x);
                transform.Translate(mx * Time.deltaTime * speed);
            }
            else
            {
                Vector3 mx = moveX * Mathf.Sign(target.transform.position.x - transform.position.x);
                transform.Translate(mx * Time.deltaTime * speed);
            }
        }
            
        
    }

    

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
    }

    public int GetCurrentHealthPoints()
    {
        return healthPoints;
    }

}
