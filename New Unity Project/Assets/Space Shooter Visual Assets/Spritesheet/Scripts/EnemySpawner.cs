using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] List<WaveConfig> waveConfigs;
	[SerializeField]int StartingWave=0;
	[SerializeField]bool looping= false;
	// Use this for initialization
	IEnumerator Start () {
		do {
			yield return StartCoroutine (SpawnAllWaves ());
		} while(looping);
	}
	private IEnumerator SpawnAllWaves()
	{
		for (int waveIndex=StartingWave; waveIndex<waveConfigs.Count; waveIndex++) 
		{
			var currentWave = waveConfigs [waveIndex];
			yield return StartCoroutine(SawnAllWnwmiesInwave(currentWave));
		}
	}

	private IEnumerator SawnAllWnwmiesInwave(WaveConfig waveConfig)
	{
		for (int enemycount=0; enemycount<waveConfig.GetnumberOFEnemeies(); enemycount++) 
		{
			var newEnemy=Instantiate (
			waveConfig.GetenemyPrefab (),
			waveConfig.GetWaypoints () [0].transform.position,
			Quaternion.identity);
			newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
			yield return new WaitForSeconds (waveConfig.Gettimebetweenspawn ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
