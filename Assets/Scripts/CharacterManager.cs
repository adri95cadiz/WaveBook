using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterManager : MonoBehaviour {
	string Seed;
	private class PossibleSprites {
		public Object Head { get; set; }
		public Object Body { get; set; }
		public Object Shirt { get; set; }
		public Object Sleeve { get; set; }
		public Object Hand { get; set; }
		public Object RaisedSleeve { get; set; }
		public Object RaisedHand { get; set;}
		public List<Object> Faces { get; set; }
		public List<Object> Beards { get; set; }
		public List<Object> Hair { get; set; }
	}

	private static CharacterManager _instance = null;
	public static CharacterManager Instance {
		get { return _instance; }
		private set { _instance = value; }
	}

	public GameObject CharacterPrefab;

	private List<Object> hats;
	private List<Object> glasses;
	private Dictionary<Character.CharGender, PossibleSprites> spritesByGender;

	private List<Character> storedCharacters;

	public void ClearStoredCharacters () {
		foreach (var _char in storedCharacters)
			DestroyObject (_char.gameObject);
		storedCharacters.Clear ();
	}

	public void AddStoredCharacter(Character _char) {
		storedCharacters.Add (_char);
		DontDestroyOnLoad (_char.gameObject);
	}

	public Character GetStoredCharacter(int _index) {
		return storedCharacters [_index];
	}

	public int GetNumStoredCharacters() {
		return storedCharacters.Count;
	}

	public Sprite GetRandomHat () {
		return hats.Count == 0 ? null : (Sprite)hats[Random.Range(0, hats.Count)];
	}

	public Sprite GetRandomGlasses () {
		return glasses.Count == 0 ? null : (Sprite)glasses[Random.Range(0, glasses.Count)];
	}

	public Sprite GetHead (Character.CharGender _gender) {
		return (Sprite)spritesByGender [_gender].Head;
	}

	public Sprite GetBody (Character.CharGender _gender) {
		return (Sprite)spritesByGender [_gender].Body;
	}

	public Sprite GetShirt (Character.CharGender _gender) {
		return (Sprite)spritesByGender [_gender].Shirt;
	}

	public Sprite GetSleeve (Character.CharGender _gender) {
		return (Sprite)spritesByGender [_gender].Sleeve;
	}

	public Sprite GetHand (Character.CharGender _gender) {
		return (Sprite)spritesByGender [_gender].Hand;
	}

	public Sprite GetRaisedSleeve (Character.CharGender _gender) {
		return (Sprite)spritesByGender [_gender].RaisedSleeve;
	}

	public Sprite GetRaisedHand (Character.CharGender _gender) {
		return (Sprite)spritesByGender [_gender].RaisedHand;
	}

	public Sprite GetRandomFace (Character.CharGender _gender) {
		List<Object> _sprites = spritesByGender [_gender].Faces;

		int index = Random.Range (0, _sprites.Count);
		Seed += index*2;
		return _sprites.Count == 0 ? null : (Sprite)_sprites[index];
	}

	public Sprite GetRandomBeard (Character.CharGender _gender) {
		List<Object> _sprites = spritesByGender [_gender].Beards;

		int index = Random.Range (0, _sprites.Count);
		Seed += index*3;
		return _sprites.Count == 0 ? null : (Sprite)_sprites[index];
	}

	public Sprite GetRandomHair (Character.CharGender _gender) {
		List<Object> _sprites = spritesByGender [_gender].Hair;

		int index = Random.Range (0, _sprites.Count);
		Seed += index*5;
		return _sprites.Count == 0 ? null : (Sprite)_sprites[index];
	}

	public Character CreateCharacter () {
		return CreateCharacter (Vector3.zero);
	}

	public Character CreateCharacter (Vector3 _pos) {
		Character _c = Instantiate (CharacterPrefab).GetComponent<Character> ();
		_c.Randomize ();
		_c.transform.localPosition = _pos;
		return _c;

	}

	public Character CreateCharacter (Vector3 _pos, float scaleFactor) {
		Character _c = Instantiate (CharacterPrefab).GetComponent<Character> ();
		_c.Randomize ();
		_c.transform.localPosition = _pos;
		_c.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
		Seed = "0";

		return _c;
	}

	public string GetSeed(){
		return Seed;
	}

	void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);

			Object[] _aux = Resources.LoadAll ("Textures/Character/Hats", typeof(Sprite));
			hats = new List<Object> (_aux);
			_aux = Resources.LoadAll ("Textures/Character/Glasses", typeof(Sprite));
			glasses = new List<Object> (_aux);
			glasses.Add (null);
			PossibleSprites _maleSprites = new PossibleSprites ();
			{
				_maleSprites.Head = Resources.Load ("Textures/Character/Male/maleHeadBase", typeof(Sprite));
				_maleSprites.Body = Resources.Load ("Textures/Character/Male/maleBody", typeof(Sprite));
				_maleSprites.Shirt = Resources.Load ("Textures/Character/Male/maleShirt", typeof(Sprite));
				_maleSprites.Sleeve = Resources.Load ("Textures/Character/Male/maleArmSleeve", typeof(Sprite));
				_maleSprites.Hand = Resources.Load ("Textures/Character/Male/maleArm", typeof(Sprite));
				_maleSprites.RaisedSleeve = Resources.Load ("Textures/Character/Male/maleArmSleeveWave", typeof(Sprite));
				_maleSprites.RaisedHand = Resources.Load ("Textures/Character/Male/maleArmWave", typeof(Sprite));
				_aux = Resources.LoadAll ("Textures/Character/Male/Faces", typeof(Sprite));
				_maleSprites.Faces = new List<Object> (_aux);
				_aux = Resources.LoadAll ("Textures/Character/Male/Beards", typeof(Sprite));
				_maleSprites.Beards = new List<Object> (_aux);
				_maleSprites.Beards.Add (null);
				_aux = Resources.LoadAll ("Textures/Character/Male/Hair", typeof(Sprite));
				_maleSprites.Hair = new List<Object> (_aux);
			}

			PossibleSprites _femaleSprites = new PossibleSprites ();
			{
				_femaleSprites.Head = Resources.Load ("Textures/Character/Female/femaleFaceBaseMockup", typeof(Sprite));
				_femaleSprites.Body = Resources.Load ("Textures/Character/Female/femaleBodyMockup", typeof(Sprite));
				_femaleSprites.Shirt = Resources.Load ("Textures/Character/Female/femaleShirtMockup", typeof(Sprite));
				_femaleSprites.Sleeve = Resources.Load ("Textures/Character/Female/femaleArmMockup", typeof(Sprite));
				_femaleSprites.Hand = Resources.Load ("Textures/Character/Female/femaleArmMockup", typeof(Sprite));
				_femaleSprites.RaisedSleeve = Resources.Load ("Textures/Character/Female/femaleArmMockup", typeof(Sprite));
				_femaleSprites.RaisedHand = Resources.Load ("Textures/Character/Female/femaleArmMockup", typeof(Sprite));
				_aux = Resources.LoadAll ("Textures/Character/Female/Faces", typeof(Sprite));
				_femaleSprites.Faces = new List<Object> (_aux);
				_femaleSprites.Beards = new List<Object> (0);
				_aux = Resources.LoadAll ("Textures/Character/Female/Hair", typeof(Sprite));
				_femaleSprites.Hair = new List<Object> (_aux);
			}

			spritesByGender = new Dictionary<Character.CharGender, PossibleSprites> {
				{Character.CharGender.Male, _maleSprites},
				{Character.CharGender.Female, _femaleSprites}
			};

			storedCharacters = new List<Character>();
		} else
			Destroy (gameObject);
	}
}
