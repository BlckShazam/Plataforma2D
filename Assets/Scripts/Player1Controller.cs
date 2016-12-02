using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player1Controller : MonoBehaviour {

	private Animator anim;
	bool suelo_cerca = false;
	public float velocidad = 5f;
	//public float velocidad_maxima = 5f; LO COMENTADO ES PARA USAR ACELERACIÓN HASTA UNA VELOCIDAD MAXIMA Y NO UNA VELOCIDAD CONSTANTE DESDE INICIO
	public GameObject particulas_muerte;
	public float fuerza = 300f;
	public AudioClip sonido_salto;
	public AudioClip sonido_herir;
	public AudioClip sonido_moneda;

	private AudioSource audio;
	private Rigidbody2D rb;
	private GameControlScript gcs;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource> ();
		gcs = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
	}

	// Update is called once per frame
	void Update () {
		//Mathf.Abs es equivalente al valor absoluto
		//velocidad = Mathf.Abs(rb.velocity.x);
		//if (velocidad > velocidad_maxima) {
		// transform.localScale.x multiplica esa velocidad maxima por la direccion a donde está mirando el personaje. Esto permite que sea negativa o positiva la velocidad se mueva sin problema y con un límite.
		//rb.velocity = new Vector2(velocidad_maxima * transform.localScale.x, rb.velocity.y);
		//}
		anim.SetFloat("Velocidad", Mathf.Abs(rb.velocity.x)); // igualamos la velocidad al valor de velocity para que al moverse el personaje a X velocidad cambie la animación

		if (Input.GetKey (KeyCode.RightArrow)) {
			MovimientoDerecha ();
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			//anim.SetFloat ("velocity", 0f);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			MovimientoIzquierda ();
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			//anim.SetFloat ("velocity", 0f);
		}
		//
		if (Input.GetKeyDown (KeyCode.UpArrow) && suelo_cerca) {
			Salto ();
			anim.SetBool ("Jump", true);
			audio.PlayOneShot (sonido_salto);
		}

	}

	void MovimientoDerecha(){
		//GetComponent<Rigidbody2D> ().AddForce (Vector2.right*fuerza);
		rb.velocity = new Vector2(velocidad, rb.velocity.y);
		this.transform.localScale = new Vector3(1, 1, 1);
		//anim.SetFloat ("velocity", 1f);
	}

	void MovimientoIzquierda() {
		//GetComponent<Rigidbody2D> ().AddForce (Vector2.left*fuerza);
		rb.velocity = new Vector2(-velocidad, rb.velocity.y);
		this.transform.localScale = new Vector3(-1, 1, 1);
		//anim.SetFloat ("velocity", 1f);
	}

	void Salto() {
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up*fuerza);
	}

	void OnTriggerStay2D(Collider2D objeto){
		if(objeto.tag == "Suelo") {
			suelo_cerca = true;
			anim.SetBool ("Jump", false);
		}
	}

	void OnTriggerExit2D(Collider2D objeto){
		if(objeto.tag == "Suelo") {
			suelo_cerca = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Muerte") {
			Invoke ("muerte", 1);
			//InvokeRepeating hace que se generen objetos cada X tiempo
			audio.PlayOneShot (sonido_herir);
			Instantiate (particulas_muerte, transform.position, transform.rotation);   //Instantiate es coger algo de un prefab de la escena y meterlo. Necesita de: Prefab, posicion y rotacion
		}
		if (col.gameObject.tag == "Moneda" ) {
			audio.PlayOneShot (sonido_moneda);
		}
	}

	void muerte (){
		gcs.respaw ();
	}
}