using UnityEngine;
using System.Collections;

public class Moneda : MonoBehaviour {
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2(Random.Range (-10,10),10)*20);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player"){
			Destroy (gameObject, 1);
		}
	}
}
