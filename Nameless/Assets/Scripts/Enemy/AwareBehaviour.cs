using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareBehaviour : IBehaviour {

    private Enemy enemy;
    private Vector2 pointToCheck;
    public AwareBehaviour(Enemy enemy, Vector2 point)
    {
        this.enemy = enemy;
        this.pointToCheck = point;
        this.enemy.eai.findPath(pointToCheck);
        enemy.eai.speed = 4;
    }
	
    public void Act()
    {
        enemy.eai.moveToPoint();
    }
}
