using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsGenerator : MonoBehaviour {
	const float X = 356.0f;
	const float Y = 0.0f;
	const int scaleFactor = 180;

	// Use this for initialization
	void Start () {
		CharacterManager.Instance.ClearStoredCharacters ();
		CharacterManager.Instance.AddStoredCharacter (CharacterManager.Instance.CreateCharacter (new Vector3 (X, Y, -10), scaleFactor));
		CharacterManager.Instance.AddStoredCharacter (CharacterManager.Instance.CreateCharacter (new Vector3(X+119.0f, Y, -10), scaleFactor));
		CharacterManager.Instance.AddStoredCharacter (CharacterManager.Instance.CreateCharacter (new Vector3(X+238.0f, Y, -10), scaleFactor));
	}
}
