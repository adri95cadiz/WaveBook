using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (GameObject.Find("CharacterManager"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
