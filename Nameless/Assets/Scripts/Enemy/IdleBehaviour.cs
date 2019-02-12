using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : IBehaviour
{
    public Enemy enemy;

    private Vector2[] pp;

    private int tour = 0;

    private bool firts = true;

    public IdleBehaviour(Enemy enemy)
    {
        this.enemy = enemy;
        //this.enemy.eai.findPath(enemy.transform.position);
        this.enemy.eai.pathIsEnded = true;
        this.pp = new Vector2[2];
        pp[0] = new Vector2(0, 0);
        pp[1] = new Vector2(-30, -20);
        enemy.eai.speed = 2;

    }


    public void Act()
    {
        patrol(pp);
    }

    public void patrol(Vector2[] patrolPoints)
    {
        if(firts == true)
        {
            enemy.eai.findPath(patrolPoints[tour]);
            tour++;
            if (tour >= pp.Length)
            {
                tour = 0;
            }
            firts = false;
        }
       

        if (enemy.eai.pathIsEnded == true)
        {

            enemy.eai.findPath(patrolPoints[tour]);
            tour++;
            if (tour >= pp.Length)
            {
                tour = 0;
            }
        }

        enemy.eai.moveToPoint();
    }


    void moveToPoint1(Vector2 p)
    {
        enemy.eai.findPath(p);
        enemy.eai.moveToPoint();
    }

    void moveToPoint2(Vector2 p)
    {
        enemy.eai.findPath(p);
        enemy.eai.moveToPoint();
    }

}
