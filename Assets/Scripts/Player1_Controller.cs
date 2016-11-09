using UnityEngine;
using System.Collections;

public class Player1_Controller : MonoBehaviour {
	Animator anim;
	Rigidbody2D rb_player;
	public float fuerza = 100f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); // Coger el animator del elemento que tenga el script
		rb_player = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			anim.SetFloat ("Velocidad",1f); //cuando presiones la tecla A, se activa
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetFloat ("Velocidad",0f); //cuando presiones la tecla A, se activa
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Jump",true); //cuando presiones la tecla A, se activa
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up*fuerza);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetBool ("Jump",false); //cuando presiones la tecla A, se activa
		}
	}

}
