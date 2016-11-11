using UnityEngine;
using System.Collections;

public class Moneda : MonoBehaviour {
	public  int suma;
	private Rigidbody2D rb;
	GameObject txt_moneda;
	ControlMonedas ctrl_moneda; //accedemos a otro script que ya hemos creado anteriormente

	// Use this for initialization
	void Start () {
		int sumar = 5;
		Destroy (gameObject, 3);
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2(Random.Range (-100,100),100));
		txt_moneda = GameObject.Find ("texto_moneda");
			ctrl_moneda = txt_moneda.GetComponent<ControlMonedas>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){

		if (col.gameObject.tag == "Player") {
			ctrl_moneda.suma_monedas (suma);
			Destroy (gameObject);
		}
	}
	/*void OnDestroy() {
		GameObject.Find ("texto_monedas").GetComponent<ControlMonedas> ().suma_monedas (5);
		}*/

}
