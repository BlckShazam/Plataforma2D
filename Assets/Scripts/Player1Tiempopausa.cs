using UnityEngine;
using System.Collections;

public class Player1Tiempopausa : MonoBehaviour {
	Animator anim;
	Rigidbody2D rigi;
	public float fuerza = 1;
	public float fsalto = 400;
	// Use this for initialization


	void Start () {
		anim = GetComponent<Animator> (); // Coger el Animator de el elemento que tenga el script
		rigi = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = 0;
		if (Input.GetKey (KeyCode.A)) {
			anim.SetFloat ("velocidad", 1f);
			rigi.AddForce (transform.right*-fuerza);
			Time.timeScale = 1;
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetFloat ("velocidad", 0f);

		}

		if (Input.GetKey (KeyCode.D)) {
			anim.SetFloat ("velocidad", 1f);
			rigi.AddForce (transform.right*fuerza);
			Time.timeScale = 1;
		}

		if (Input.GetKeyUp (KeyCode.D)) {
			anim.SetFloat ("velocidad", 0f);

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool  ("jump", true);
			rigi.AddForce (transform.up*fsalto);
			Time.timeScale = 1;
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetBool ("jump", false);
		}
	}
}
