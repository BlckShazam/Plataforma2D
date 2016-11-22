using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Animator))]
public class MenuScript : MonoBehaviour {
	Animator anim;
	private bool menu_pausa = false;

	// Use this for initialization
	void Start () {
	anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		//En Update preguntamos si se han pulsado las teclas necesarias.

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (menu_pausa) {
				continuar ();
			}else{
				pausa ();
			}
	
		}
	}

	public void opciones (){
			menu_pausa = false;
			anim.SetBool ("opciones", true);
			anim.SetBool ("pausa", true);

		}

	public void pausa(){
		Time.timeScale = 0;
		anim.SetBool ("pausa", true); //SetBool da un valor booleado a la animacion y este se especifica despues.
		anim.SetBool ("opciones", false);
	
	}

	public void salir (){
		Application.Quit (); //Para salir del juego, pero solo funciona cuando compilamos el juego.
		Debug.Log("Saliendo");
	}

	

	public void continuar () {
		menu_pausa = false;
		Time.timeScale = 1;
		anim.SetBool ("opciones", false);
		anim.SetBool ("pausa", false);
	
	
	}
}
