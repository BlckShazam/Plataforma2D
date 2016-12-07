using UnityEngine;
using System.Collections;

public class Carro : MonoBehaviour {
	WheelJoint2D union_rueda;
	JointMotor2D motor;

	public float speed = 10f;

	// Use this for initialization
	void Start () {
		union_rueda = GetComponent<WheelJoint2D> ();
		motor = union_rueda.motor;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) {
		
			union_rueda.useMotor = true;
			motor.motorSpeed = union_rueda.motor.motorSpeed - speed;
			union_rueda.motor = motor;
			}
			
		if (Input.GetKeyUp (KeyCode.Space)) {
			motor.motorSpeed = 0f;
			union_rueda.motor = motor;
			union_rueda.useMotor = false;
			}
		}

	void OnCollisionEnter2D (Collision2D col){

	if (col.gameObject.tag == "Pared") {
			speed = 10f;
		}
		if (col.gameObject.tag == "ParedDos"){
			speed = -10f;
		}
	}
}

