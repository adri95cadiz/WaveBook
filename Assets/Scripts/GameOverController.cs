using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
	public Text GameOverText;
	public Image GameOverImage;
	public Sprite WinSprite;
	public Sprite LooseSprite;


	string[] WinArray = new string[] 
	{ 
		"You meet real friends!! Congratulations!!", 
		"Oh my gosh, you're so popular!!"
	};
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
		if (true) {
			GameOverImage.sprite = WinSprite;
			GameOverText.text = WinArray[(int)Random.Range (0.0f, 2.0f)];


		} else {
			GameOverImage.sprite = LooseSprite;
			GameOverText.text = LooseArray[(int)Random.Range (0.0f, 5.0f)];

		}

	}

}
