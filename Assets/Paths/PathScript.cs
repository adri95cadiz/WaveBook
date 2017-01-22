using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour {

	private Character character;
	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
//		this.Animacion ();
	}
	
	// Update is called once per frame
	void Update () {		

	}

	public void SetCharacter(Character _char) {
		_char.transform.SetParent (transform, false);
		character = _char;
	}

	public Character GetCharacter () {
		return character;
	}

	public void Animacion(){
		this.GetComponent<Animator>().SetBool("Wait", false);
	}

	public void SetRandomPath(){
		List<int> _possibleIndices = new List<int> {
			0,
			1,1,1,1,
			2,2,2,2,
			3,3,3,3,
			4,4,4,4,
			5,5,5,5
		};

		this.GetComponent<Animator> ().SetInteger ("Path", _possibleIndices[Random.Range (0, _possibleIndices.Count)]);
	}

	public void finAnimacion(){
		this.GetComponent<Animator>().SetBool("Wait", true);
	}

	public void shouldIWave(){
		GameLogic.Instance.CharacterWantsToWave (this);
	}

	public void pause(float _time) {
		StartCoroutine (pausarAnimacion (_time));
	}

	private IEnumerator pausarAnimacion(float tiempo){
		animator.enabled = false;
		yield return new WaitForSeconds(tiempo);
		animator.enabled = true;
	}
}
