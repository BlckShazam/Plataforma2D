using UnityEngine;
using System.Collections;

public class GeneradorMonedas : MonoBehaviour {
	public GameObject moneda_nueva;
	public GameObject moneda;

	void OnTriggerEnter2D(Collider2D objeto){
		if(objeto.tag == "Player" &&  moneda_nueva == null) {
			moneda_nueva = (GameObject)Instantiate (moneda, transform.position, transform.rotation);
		}
	}

}