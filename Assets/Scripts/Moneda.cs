using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(AudioSource))] //En caso de no tener un objeto de tipo AudioSource, se lo incrustamos nosotros.
public class Moneda : MonoBehaviour {
	private Rigidbody2D rb;	
	GameObject txt_moneda;
	ControlMonedas ctrl_moneda;
	public int suma = 5;

	// Use this for initialization
	void Start () {
		//Destroy (gameObject, 2);
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (Random.Range(-100, 100),100));
		txt_moneda = GameObject.Find ("texto_moneda");
		ctrl_moneda = txt_moneda.GetComponent<ControlMonedas> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			ctrl_moneda.suma_monedas (suma);
			Destroy (gameObject);
		}
	}
}