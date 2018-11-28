using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	[Header ("Player Movement")]
	[SerializeField] float MovSpeed=10f;
	[SerializeField] float padding=1f;
	[SerializeField] int health=100;
	[Header ("Projectile")]
	[SerializeField] GameObject Laserprefab;
	[SerializeField] float projectileSpeed=10f;
	[SerializeField] float projectilefireperid=0.1f;
	Coroutine firingCoroutine;
	float xMin;
	float xMax;
	float yMin;
	float yMax;

	// Use this for initialization
	void Start () {
		SetUpMovBoundaries ();
	}

	private void SetUpMovBoundaries ()
	{
		Camera GameCamera=Camera.main;
		xMin = GameCamera.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x+padding;
		xMax = GameCamera.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x-padding;
		yMin = GameCamera.ViewportToWorldPoint (new Vector3 (0, 0, 0)).y+padding;
		yMax = GameCamera.ViewportToWorldPoint (new Vector3 (0, 1, 0)).y-padding;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Fire ();
		
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

	void Fire ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			firingCoroutine= StartCoroutine(FireCountinously());
		
		}
		if (Input.GetButtonUp ("Fire1")) {
			StopCoroutine(firingCoroutine);
		}
	}
	IEnumerator FireCountinously()
	{
		while (true) {
			GameObject laser= Instantiate(Laserprefab,transform.position,Quaternion.identity) as GameObject;
			laser.GetComponent<Rigidbody2D>().velocity=new Vector2(0, projectileSpeed);
			yield return new WaitForSeconds(projectilefireperid);
		}
	}

	private void Move(){
		var DeltaX = Input.GetAxis ("Horizontal") * Time.deltaTime*MovSpeed;
		var DeltaY = Input.GetAxis ("Vertical") * Time.deltaTime*MovSpeed;

		var NewXPos = Mathf.Clamp(transform.position.x + DeltaX,xMin,xMax);
		var NewYPos = Mathf.Clamp(transform.position.y + DeltaY, xMin,xMax);

		transform.position = new Vector2 (NewXPos,NewYPos);
	}
}
