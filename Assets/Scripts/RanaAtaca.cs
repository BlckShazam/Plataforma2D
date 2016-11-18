using UnityEngine;
using System.Collections;

public class RanaAtaca : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>(); // Coger el Animator de el elemento que tenga el script
	}


	void OnTriggerEnter2D (Collider2D objeto){
		if(objeto.tag == "Player"){
			anim.SetTrigger("Salto");
		}

	}
	// Update is called once per frame
	void Update () {

}
}