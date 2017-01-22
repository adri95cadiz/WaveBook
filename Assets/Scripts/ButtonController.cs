using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	public string buttonName;
	Button button;
	Image buttonImage;
	public Sprite initButtonImage;
	public Sprite finalButtonImage;


	[FMODUnity.EventRef] 	//FMOD
	public string SoundLogin = "event:/Clicks"; 	//FMOD

	void Awake()
	{
		GameObject canvas = GameObject.Find ("Canvas");
		Transform buttonTransform = canvas.transform.Find (buttonName);
		this.button = buttonTransform.gameObject.GetComponent<Button> ();
		this.buttonImage = buttonTransform.gameObject.GetComponent<Image> ();
	}
		
	void Update () {
		if (Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown(0)) 
		{
			this.buttonImage.sprite = this.finalButtonImage;
			FMODUnity.RuntimeManager.PlayOneShot (SoundLogin, new Vector3 (0,0,0)); //FMOD
		} 
		else if(Input.GetButtonUp("Jump"))
		{
			this.buttonImage.sprite = this.initButtonImage;
			this.button.onClick.Invoke ();
		}
	}
}
