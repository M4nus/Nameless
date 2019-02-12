using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class Enemy : MonoBehaviour, IHurtable{


    public int healthPoints;

    public float shootRange;
    public GameObject target;
    public Shooting shooting;
    public float shootingCooldown;
    public float speed;

    private Vector3 moveX;
    private Vector3 moveY;
    private Vector2 targetVector;
    public float actualCooldownTime;
    private float angleToTarget;
    public float xdis;
    public float ydis;
    public float distanceToTarget;
    private IBehaviour behaviour;
    public EnemyAI eai;
    
	void Start () {
        moveY = new Vector3(speed, 0, 0);
        moveX = new Vector3(0, speed, 0);
        eai = GetComponent<EnemyAI>();
        behaviour = new IdleBehaviour(this);
        target = Player1Controls.instance.player1;
    }
	
	void Update () {

        behaviour.Act();
    }

    public void lowerCooldown()
    {
        if(actualCooldownTime > 0)
        {
            actualCooldownTime -= Time.deltaTime;
        }
    }

    public void faceTarget()
    {


        if(angleToTarget <= 45 + 10&& xdis > 0) // prawo
        {
            Debug.Log("prawo");
            transform.rotation = new Quaternion(0, 0, 0, 0);
            
        }
        else if(angleToTarget > 45 && angleToTarget <= 3 * 45 -10 && ydis > 0 ) // gora
        {
            Debug.Log("gora");
            transform.rotation = new Quaternion(0, 0, 90, 90);
        }
        else if(angleToTarget > 3 * 45  + 10 && xdis < 0) // lewo
        {
            Debug.Log("lewo");
            transform.rotation = new Quaternion(0, 0, 180, 0);
        }
        else if (angleToTarget > 45 && angleToTarget <= 3 * 45 -10 && ydis < 0) // dol
        {
            Debug.Log("dol");
            transform.rotation = new Quaternion(0, 0, 90, -90);
        }
    }

    public void moveToPlayer()
    {
        targetVector = new Vector2(target.gameObject.transform.position.x - gameObject.transform.position.x, target.gameObject.transform.position.y - gameObject.transform.position.y);
        angleToTarget = Vector2.Angle(new Vector2(1, 0), targetVector);
        ydis = (target.transform.position.y - transform.position.y);
        xdis = (target.transform.position.x - transform.position.x);
        distanceToTarget = Vector2.Distance(gameObject.transform.position, target.transform.position);

        if ((Mathf.Abs(ydis) > 1 && Mathf.Abs(xdis) > 1) || distanceToTarget >= shootRange)
        {

            if (Mathf.Abs(ydis) > 0.5)
            {
                if (ydis > 0.5)
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

            else if (Mathf.Abs(xdis) > 0.5)
            {
                if (xdis > 0.5)
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

    public void setBaheviour(IBehaviour behaviour)
    {
        if(behaviour != null)
        {
            this.behaviour = behaviour;
        }
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
