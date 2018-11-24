using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

	[SerializeField] List<Transform> Waypoints;
	[SerializeField] float movspeed=2.0f;

	int WaypointIndex=0;

	// Use this for initialization
	void Start () {
		transform.position = Waypoints [WaypointIndex].position;
		
	}
	
	// Update is called once per frame
	void Update () {
		Mov ();
		
	}

	void Mov ()
	{
		if (WaypointIndex <= Waypoints.Count - 1) {
			var TargestLoc = Waypoints [WaypointIndex].transform.position;
			var movmentspeed = movspeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards (transform.position, TargestLoc, movmentspeed);
			if (Vector3.Distance(transform.position,TargestLoc) <= 0.1f) {
				WaypointIndex++;
			}
		}
		else {
			Destroy (gameObject);
		}
	}

}
