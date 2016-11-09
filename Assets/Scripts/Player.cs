using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float velocidad = 5f;
	private Animator animator;
	private Rigidbody2D rb;
	public float power = 1f;
	public float fuerza = 400f;
	public bool tocando_suelo = false;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	

	}
	
	// Update is called once per frame
	void Update () {
		//llamamos a la "velocidad" del animator y la velocidad del rigidbody y con el valor absoluto nos aseguramos de que funcione en terminos negativos.
		animator.SetFloat ("Velocidad", Mathf.Abs(rb.velocity.x));

		if (Input.GetKey ("right")) {
		
			rb.velocity = new Vector2 (velocidad*power,rb.velocity.y);
			transform.localScale = new Vector3 (1, 1);
		} 
	 	if (Input.GetKey ("left")) {
		
			rb.velocity = new Vector2 (-velocidad*power,rb.velocity.y);//rb.velocity.y llama a la velocidad propia que tiene RB en Y
			transform.localScale = new Vector3 (-1, 1);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
		
			animator.SetBool ("Jump", true);
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * fuerza);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
		
			animator.SetBool ("Jump", false);

		}
			
	}

	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
		
			tocando_suelo = true;
		}
	}

	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
		
			tocando_suelo = false;
			animator.SetBool ("Jump", true);
		}
	}
}
