using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]  int health=100;
	[SerializeField] float shotCounter;
	[SerializeField] float minTimeBetweenShots=0.2f;
	[SerializeField] float maxTimeBetweenShots=3f;
	[SerializeField] GameObject projectile;
	[SerializeField] float projectileSpeed=10f;
	// Use this for initialization
	void Start () {
		shotCounter = Random.Range (minTimeBetweenShots, maxTimeBetweenShots);
		
	}
	
	// Update is called once per frame
	void Update () {
		CountDownAndShoot ();
	}

	void CountDownAndShoot ()
	{
		shotCounter -= Time.deltaTime;
		if (shotCounter <= 0f) {
			Fire();
			shotCounter = Random.Range (minTimeBetweenShots, maxTimeBetweenShots);
		}
	}

	private void Fire(){
		GameObject laser = Instantiate (
			projectile,
			transform.position,
			Quaternion.identity
		)as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity=new Vector2(0, -projectileSpeed);
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
