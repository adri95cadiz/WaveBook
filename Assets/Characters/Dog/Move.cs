using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	float direccion = 0.2f;
	public GameObject arbol;
	int contador = 3;
	bool moveRight = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Transform>().position.x > 50 || this.GetComponent<Transform>().position.x < -50) {
			direccion *= -1;
			this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
			moveRight = !moveRight;
		}
		if (this.GetComponent<Transform> ().position.x > arbol.GetComponent<Transform> ().position.x -0.2 && this.GetComponent<Transform> ().position.x < arbol.GetComponent<Transform> ().position.x + 0.2) {
			if (contador == 6) {
				contador = 0;
			}
			if (contador == 0) { 
				this.GetComponent<Animator> ().SetBool ("Mear", true);
				direccion = 0.00241f;
				if (this.GetComponent<Transform> ().position.x > arbol.GetComponent<Transform> ().position.x + 0.1) {
					this.GetComponent<Animator> ().SetBool ("Mear", false);
					if (moveRight) {
						direccion = 0.2f;
					} else {
						direccion = -0.2f;
					}
				}
			}
			contador++;
		}
		this.GetComponent<Transform> ().Translate (new Vector3 (direccion, 0, 0));
	}


}
