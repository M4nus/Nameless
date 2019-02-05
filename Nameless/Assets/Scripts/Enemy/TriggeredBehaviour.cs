using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredBehaviour : IBehaviour
{
    public Enemy enemy;

    public TriggeredBehaviour(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Act()
    {
        if (enemy.distanceToTarget < enemy.shootRange && enemy.actualCooldownTime <= 0 && (Mathf.Abs(enemy.xdis) < 0.7 || Mathf.Abs(enemy.ydis) < 0.7))
        {
            enemy.shooting.Shoot();
            enemy.actualCooldownTime = enemy.shootingCooldown;
        }

        enemy.lowerCooldown();
        enemy.faceTarget();
        enemy.moveToPlayer();
    }
}
