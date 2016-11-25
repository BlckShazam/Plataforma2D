using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	public GameObject[] monedas;
	private GameObject moneda_nueva;
	private Transform pos_salida;
	private int numero_moneda = 0;
	Animator anim;
	private int Golpeado = 0;

	void Start (){
		pos_salida = transform.Find ("posicion_salida").transform; //Para buscar un objeto dentro de otro objeto. En sistema parental buscas un Child.
		Debug.Log("Cantidad de monedas: "+monedas.Length);
		anim = GetComponent<Animator>();

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player" && moneda_nueva == null) {
			numero_moneda = Random.Range (0, monedas.Length); 
			// generar un RANDOM.RANGE del array usando .Length y especificando el -1 porque cuenta hasta 10 elementos, pero al establecer el 0 como iniciar, habría 11 y se debe restar uno para que sean 10 elementos.

			
			if (Golpeado < 3) {
				
				moneda_nueva = (GameObject)Instantiate (monedas [numero_moneda],
					pos_salida.position,
					transform.rotation);

				anim.SetBool ("golpea", true);

				Golpeado++;

				if (Golpeado == 3) {
					anim.SetBool ("Congelada", true);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D objeto){
		
		if (objeto.tag == "Player" && moneda_nueva == null) {
			//Initiate (moneda, transform.position) // genero Moneda en el mismo sitio donde esta el collider
			Instantiate (monedas[numero_moneda], transform.position, transform.rotation);
		
		}
	}
}
