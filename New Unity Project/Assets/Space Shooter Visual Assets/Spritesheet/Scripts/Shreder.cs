using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreder : MonoBehaviour {

	private void OnTriggerEnter2d(Collider2D collision)
	{
		Destroy (collision.gameObject);
	}
}
