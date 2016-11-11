using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlMonedas : MonoBehaviour {
	
	private int monedas = 0;
	Text texto;

	void Start(){
	
		texto = GetComponent<Text> ();
		resetear ();
		suma_monedas (11); //ejemplo de llamar a funciones que necesitan parametros.
	}



	public void suma_monedas(int cantidad){
		monedas = monedas + cantidad; //monedas += cantidad;

		if (monedas < 0) {
			monedas = 0;
		}
	
		texto.text = monedas.ToString (); //ToString convierte numeros en cadena de texto.
	}
	public void resetear(){
		monedas = 0;
		texto.text = monedas.ToString();

	}
}
