using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	public GameObject moneda;
	private GameObject moneda_nueva;


	void OnTriggerEnter2D(Collider2D objeto){
		
		if (objeto.tag == "Player" && moneda_nueva == null) {
			Instantiate (moneda, transform.position, transform.rotation);
		
		}
	}
}
