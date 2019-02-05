using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : IBehaviour
{
    public Enemy enemy;

    public IdleBehaviour(Enemy enemy)
    {
        this.enemy = enemy;
    }


    public void Act()
    {
        Enemy.Point[] points = new Enemy.Point[1];
        //points[0] = new Enemy.Point(0, 0);
        //points[0] = new Enemy.Point(30, 30);
        //points[0] = new Enemy.Point(-30, 0);
        enemy.moveToPoint(new Enemy.Point(-30, 30));
        //patrol(points);
    }

    public void patrol(Enemy.Point[] patrolPoints)
    {
        foreach(Enemy.Point p in patrolPoints)
        {
            enemy.moveToPoint(p);
        }
    }
}
