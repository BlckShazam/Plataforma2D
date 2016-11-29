using UnityEngine;
using System.Collections;

public class AutoDestruccionParticulas : MonoBehaviour {
	
	ParticleSystem sistema_particulas;

	// Use this for initialization
	void Start () {
		sistema_particulas = GetComponent<ParticleSystem> ();

		Destroy (gameObject, sistema_particulas.duration);  // lo que queremos destruir y cuando (tiempo).

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
