using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludandoEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void finSaludo(){
		this.GetComponent<Animator> ().SetBool ("Saludando", false);
		this.transform.parent.GetComponent<Animator>().SetBool("Saludando", false);
    }
}
