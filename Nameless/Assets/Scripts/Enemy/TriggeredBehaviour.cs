using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredBehaviour : MonoBehaviour ,IBehaviour
{
    public Enemy enemy;
    private float updateRate = 2f;

    private IEnumerator coroutine;
    public TriggeredBehaviour(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.eai.speed = 5;
        //coroutine = enemy.eai.updatePathEveryRate(Player1Controls.instance.player1.transform.position, updateRate);
        //StartCoroutine(enemy.eai.updatePathEveryRate(new Vector2(30, 30), updateRate));
        //up();
    }

    //void up()
    //{
    //    Debug.Log("Path path path");
    //    enemy.eai.findPath(Player1Controls.instance.player1.transform.position);
    //    //enemy.eai.findPath(enemy.target.transform.position);
    //    //yield return new WaitForSeconds(1f / updateRate);
    //    //StartCoroutine(updatePath());
    //}


    //IEnumerator updatePath()
    //{
    //    Debug.Log("Path path path");
    //    enemy.eai.findPath(Player1Controls.instance.player1.transform.position);
    //    //enemy.eai.findPath(enemy.target.transform.position);
    //    yield return new WaitForSeconds(1f / updateRate);
    //    StartCoroutine(updatePath());
    //}

    public void Act()
    {
        if (enemy.distanceToTarget < enemy.shootRange && enemy.actualCooldownTime <= 0 && (Mathf.Abs(enemy.xdis) < 0.7 || Mathf.Abs(enemy.ydis) < 0.7))
        {
            enemy.shooting.Shoot();
            enemy.actualCooldownTime = enemy.shootingCooldown;
        }

        enemy.lowerCooldown();
        enemy.faceTarget();
        //enemy.eai.moveToPoint();
        enemy.moveToPlayer();
    }
}
