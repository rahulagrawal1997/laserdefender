using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

	[SerializeField] GameObject enemyPrefab;
	[SerializeField] GameObject pathPrefab;
	[SerializeField] float timebetweenspawn=0.5f;
	[SerializeField] float spawnRandomFactor=0.3f;
	[SerializeField] int numberOFEnemies=5;
	[SerializeField] float movSpeed=2f;

	public GameObject GetenemyPrefab(){return enemyPrefab;}

	public GameObject GetpathPrefab(){return pathPrefab;}
	public float Gettimebetweenspawn(){return timebetweenspawn;}
	public float GetspawnRandomFactor(){return spawnRandomFactor;}
	public int GetnumberOFEnemeies(){return numberOFEnemies;}
	public float GetmovSpeed(){return timebetweenspawn;}
}
