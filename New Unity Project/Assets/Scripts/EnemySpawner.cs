using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] List<WaveConfig> waveConfigs;
	int StartingWave=0;
	// Use this for initialization
	void Start () {
		var currentWave = waveConfigs [StartingWave];
		StartCoroutine (SawnAllWnwmiesInwave (currentWave));
	}

	private IEnumerator SawnAllWnwmiesInwave(WaveConfig waveConfig)
	{
		for (int enemycount=0; enemycount<waveConfig.GetnumberOFEnemeies(); enemycount++) 
		{
			Instantiate (
			waveConfig.GetenemyPrefab (),
			waveConfig.GetWaypoints () [0].transform.position,
			Quaternion.identity
			);
			yield return new WaitForSeconds (waveConfig.Gettimebetweenspawn ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
