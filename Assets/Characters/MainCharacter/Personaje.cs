using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void Saluda(){
		this.GetComponent<Animator> ().SetBool ("Saludando", true);
		transform.Find ("brazoprota").GetComponent<Animator> ().SetBool ("Saludando", true);
	}

	public void FinSaludo(){
		this.GetComponent<Animator> ().SetBool ("Saludando", true);
		transform.GetComponentInParent<Animator>().SetBool("finSaludar", true);
		transform.Find ("brazoprota").GetComponent<Animator> ().SetBool ("Saludando", false);
	}
}