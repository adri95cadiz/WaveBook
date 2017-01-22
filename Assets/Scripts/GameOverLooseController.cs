using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLooseController : MonoBehaviour {
	public Text GameOverText;
	public Image GameOverImage;
	public Sprite LooseSprite;

	string[] LooseArray = new string[] 
	{ 
		"Are you even trying?", 
		"Shame FOREVER!!!", 
		"You will die alone (with 72 cats).",
		"That was very embarrassing...",
		"Friends? What is that? Food?"
	};

	// Use this for initialization
	void Start () {
		GameOverImage.sprite = LooseSprite;
		GameOverText.text = LooseArray[(int)Random.Range (0.0f, 5.0f)];
	}
}
