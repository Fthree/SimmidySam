using UnityEngine;
using System.Collections.Generic;

public class WaypointGroup : MonoBehaviour {
    Waypoint[] waypointTransforms;
	// Use this for initialization
	void Start () {
        waypointTransforms = GetComponentsInChildren<Waypoint>();
	}
	
    public Waypoint[] getWaypoints()
    {
        return waypointTransforms;
    }
}
