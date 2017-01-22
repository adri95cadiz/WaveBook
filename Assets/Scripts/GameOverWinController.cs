using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWinController : MonoBehaviour {
	public Text GameOverText;
	public Image GameOverImage;
	public Sprite WinSprite;

	string[] WinArray = new string[] 
	{ 
		"You meet real friends!! Congratulations!!", 
		"Oh my gosh, you're so popular!!"
	};

	// Use this for initialization
	void Start () {
		GameOverImage.sprite = WinSprite;
		GameOverText.text = WinArray[(int)Random.Range (0.0f, 2.0f)];
	}
}
