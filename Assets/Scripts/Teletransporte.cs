using UnityEngine;
using System.Collections;

public class Teletransporte : MonoBehaviour {

	public Transform destino;

	void OnTriggerEnter2D (Collider2D objeto){
	if (objeto.tag == "Player"){
			objeto.transform.position = destino.position;
		}
	}
}
