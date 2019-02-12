using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

    private Seeker seeker;

    public Path path;

    public float speed;

    public bool pathIsEnded = false;

    private float nextWaypointDistance = 1;

    private int currentWaypoint = 0; 


	
	void Start () {
        seeker = GetComponent<Seeker>();
	}
	
	void Update () {
		
	}

    public IEnumerator updatePathEveryRate(Vector2 target, float rate)
    {
        if(target != null && rate != 0 )
        {
            findPath(target);
            yield return new WaitForSeconds(1f / rate);
            StartCoroutine(updatePathEveryRate(target, rate));
        }
    }

    public void findPath(Vector2 target)
    {
        path = null;
        seeker.StartPath(transform.position, target, onPathComplete);
        pathIsEnded = false;
    }

    void onPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    public void moveToPoint()
    {

        //if (target == null) return;
        if (path == null) return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded) return;

            pathIsEnded = true;
            return;
        }

        //pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;

        transform.Translate(dir);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if ( dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
