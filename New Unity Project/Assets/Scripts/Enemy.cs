using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]  int health=100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		Damage damageDealer = other.gameObject.GetComponent<Damage> ();
		ProcessHit (damageDealer);
	}

	void ProcessHit (Damage damageDealer)
	{
		health -= damageDealer.GetDamage ();
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
