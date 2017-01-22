using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	
	private static readonly int WAVE_TRIGGER_HASH = Animator.StringToHash ("Wave");
	private static readonly int WALK_TRIGGER_HASH = Animator.StringToHash("Walk");

	private static readonly List<Color> AVAILABLE_COLORS = new List<Color> {
		Color.white,
		Color.black,
		Color.green,
		Color.blue,
		Color.red,
		Color.yellow,
		Color.grey
	};

	public enum CharGender { Male, Female }

	private CharGender _gender;
	public CharGender Gender {
		get { return _gender; }
		private set { _gender = value; }
	}

	private int _charIndex;
	public int Index {
		get { return _charIndex; }
		set { _charIndex = value; }
	}

	private string CharSeed;
	private GameObject headBase;
	private GameObject headHair;
	private GameObject headFace;
	private GameObject headBeard;
	private GameObject headGlasses;
	private GameObject headHat;

	private GameObject bodyBackground;
	private GameObject bodyShirt;

	private GameObject armSleeve;
	private GameObject armHand;

	private GameObject raisedArmSleeve;
	private GameObject raisedArmHand;

	private Animator animator;

	public void Randomize () {
		_gender = CharGender.Male;//Random.Range (1, 3) == 1 ? CharGender.Male : CharGender.Female;

		CharacterManager _cm = CharacterManager.Instance;

		headBase.GetComponent<SpriteRenderer> ().sprite = _cm.GetHead (_gender);
		bodyBackground.GetComponent<SpriteRenderer> ().sprite = _cm.GetBody (_gender);

		var _bodyShirtRenderer = bodyShirt.GetComponent<SpriteRenderer> ();
		_bodyShirtRenderer.sprite = _cm.GetShirt (_gender);

		var _armSleeveRenderer = armSleeve.GetComponent<SpriteRenderer> ();
		_armSleeveRenderer.sprite = _cm.GetSleeve (_gender);

		armHand.GetComponent<SpriteRenderer> ().sprite = _cm.GetHand (_gender);

		var _raisedArmSleeveRenderer = raisedArmSleeve.GetComponent<SpriteRenderer> ();
		_raisedArmSleeveRenderer.sprite = _cm.GetRaisedSleeve (_gender);

		raisedArmHand.GetComponent<SpriteRenderer> ().sprite = _cm.GetRaisedHand (_gender);

		headHair.GetComponent<SpriteRenderer> ().sprite = _cm.GetRandomHair (_gender);
		headFace.GetComponent<SpriteRenderer> ().sprite = _cm.GetRandomFace (_gender);
		headBeard.GetComponent<SpriteRenderer> ().sprite = _cm.GetRandomBeard (_gender);
		headGlasses.GetComponent<SpriteRenderer> ().sprite = _cm.GetRandomGlasses ();
		headHat.GetComponent<SpriteRenderer> ().sprite = _cm.GetRandomHat ();

		Color _clothesColor = AVAILABLE_COLORS[Random.Range(0, AVAILABLE_COLORS.Count)];
		_clothesColor.a = _armSleeveRenderer.color.a;
		_armSleeveRenderer.color = _clothesColor;
		_raisedArmSleeveRenderer.color = _clothesColor;
		_bodyShirtRenderer.color = _clothesColor;

		CharSeed = _cm.GetSeed ();
	}

	public bool isEqual(Character personaje){
		return personaje.GetSeed().Equals(this.CharSeed);
	}

	public string GetSeed(){
		return this.CharSeed;
	}

	public void Walk () {
		animator.SetTrigger (WALK_TRIGGER_HASH);
	}

	public void Wave () {
		animator.SetTrigger (WAVE_TRIGGER_HASH);
	}

	void Awake () {
		GameObject _head = transform.Find ("Translator/Head").gameObject;
		headBase = _head.transform.Find ("Base").gameObject;
		headHair = _head.transform.Find ("Hair").gameObject;
		headFace = _head.transform.Find ("Face").gameObject;
		headBeard = _head.transform.Find ("Beard").gameObject;
		headGlasses = _head.transform.Find ("Glasses").gameObject;
		headHat = _head.transform.Find ("Hat").gameObject;

		GameObject _body = transform.Find ("Translator/Body").gameObject;
		bodyBackground = _body.transform.Find ("Background").gameObject;
		bodyShirt = _body.transform.Find ("Shirt").gameObject;

		GameObject _arm = _body.transform.Find ("Arm").gameObject;
		armSleeve = _arm.transform.Find ("Sleeve").gameObject;
		armHand = _arm.transform.Find ("Hand").gameObject;

		GameObject _raisedArm = _body.transform.Find ("RaisedArm").gameObject;
		raisedArmSleeve = _raisedArm.transform.Find ("Sleeve").gameObject;
		raisedArmHand = _raisedArm.transform.Find ("Hand").gameObject;

		animator = GetComponent<Animator> ();
	}

//	void Start () {
//		Randomize ();
//		Walk ();
//		Wave ();
//	}
}
