using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
	WaveConfig waveconfig;
	List<Transform> Waypoints;


	int WaypointIndex=0;

	// Use this for initialization
	void Start () {
		Waypoints = waveconfig.GetWaypoints ();  
		transform.position = Waypoints [WaypointIndex].position;
		
	}
	
	// Update is called once per frame
	void Update () {
		Mov ();
		
	}
	public void SetWaveConfig(WaveConfig waveconfig)
	{
		this.waveconfig = waveconfig;
	}

	void Mov ()
	{
		if (WaypointIndex <= Waypoints.Count - 1) {
			var TargestLoc = Waypoints [WaypointIndex].transform.position;
			var movmentspeed =waveconfig.GetmovSpeed() * Time.deltaTime;
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
