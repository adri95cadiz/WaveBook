using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChicaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Saluda(){
		this.GetComponent<Animator> ().SetBool ("Saludando", true);
	}

	public void Saludando (){
		transform.Find ("Pivote").GetComponent<Animator> ().SetBool ("Saludando", true);
	}

	public void Perdiste(){
		SceneManager.LoadScene ("GameOverLoose");	
	}
}
