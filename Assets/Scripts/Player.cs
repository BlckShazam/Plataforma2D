using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float velocidad = 5f;
	public float power = 1f;
	public float salto = 400;
	public bool tocando_suelo = false;
	private Animator animator;
	private Rigidbody2D rb;
	private GameControlScript gcs;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		gcs = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("velocidad", Mathf.Abs (rb.velocity.x)); 
		
		if (Input.GetKey ("right")) {
			animator.SetFloat ("velocidad", 1f);
			rb.velocity = new Vector2 (velocidad*power,rb.velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetKey("left")) {
			animator.SetFloat ("velocidad", 1f);
			rb.velocity = new Vector2 (-velocidad*power, rb.velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			animator.SetBool  ("jump", true);
			rb.AddForce (transform.up*salto);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			animator.SetBool ("jump", false);
		}
			
	}

	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = false;
		}
	
	}

	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = true;
			animator.SetBool ("jump", false);
		}
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "muerte") {
			gcs.respaw ();
		}

	}
}