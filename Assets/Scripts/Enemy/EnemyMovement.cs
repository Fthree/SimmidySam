using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public WaypointGroup waypoints;
    public Player player;
    Waypoint nextWaypoint;
    int index = 0;

	// Use this for initialization
	void Start () {
        //nextWaypoint = waypoints.getWaypoints()[index];
        //index++;
    }
	
	// Update is called once per frame
	void Update () {
        
        //float distance = Vector3.Distance(transform.position, nextWaypoint.transform.position);

        //if (distance < 7.5f)
        //{
        //    nextWaypoint = waypoints.getWaypoints()[index];
        //    index++;

        //    if(index > waypoints.getWaypoints().Length - 1)
        //    {
        //        index = 0;
        //    }
        //    return;
        //}

        //Vector3 heading = transform.position - nextWaypoint.transform.position;
        //heading.Scale(new Vector3(0.5f, 0.5f, 0.5f));
        //GetComponent<Rigidbody>().AddForce(-heading);
        transform.LookAt(player.transform.position);
	}
}
