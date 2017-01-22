using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

	private static class Constants {
		public const int NUM_CHARACTERS = 30;
		public const int NUM_BUDDIES = 3;
		public const int BUDDY_INDEX_MARGIN = 2;
		public const int NUM_NON_BUDDIES = 5;	// People waving, non-buddies
		public const float STAGE_DURATION = 60.0f;
    }

	public GameObject ContainerPrefab;

	private static GameLogic _instance;
	public static GameLogic Instance {
		get { return _instance; }
		private set { _instance = value; }
	}

    private int friendCounter;
	private Prota prota;
	private ChicaScript chica;
	private GameObject containerContainer;
	private List<PathScript> containers;
	private List<int> buddyIndices;
	private List<int> nonBuddyIndices;
	private float wavingTime;

	private Character wavingCharacter;

	public void CharacterWantsToWave (PathScript _charContainer) {
		if (wavingCharacter != null)
			return;
		
		Character _char = _charContainer.GetCharacter ();
		if (buddyIndices.Contains (_char.Index) || nonBuddyIndices.Contains (_char.Index)) {
			_char.Wave ();
			_charContainer.pause (wavingTime);

			wavingCharacter = _char;
			StartCoroutine (WaitForWaveToFinish (_charContainer));
		}
	}

	private IEnumerator WaitForWaveToFinish(PathScript _charContainer) {
		yield return new WaitForSeconds (wavingTime);

		wavingCharacter = null;
		_charContainer.GetCharacter ().Walk ();
	}

	private IEnumerator StartMovingCoroutine () {
		int _nextCharacter = 0;

		float _interval = Constants.STAGE_DURATION / Constants.NUM_CHARACTERS;

		while (_nextCharacter < containers.Count) {
			if (wavingCharacter != null && buddyIndices.Contains (containers[_nextCharacter].GetCharacter ().Index)) {
				// Buddy and someone is still waving
				if (_nextCharacter < containers.Count - 1) {
					var _aux = containers [_nextCharacter];
					containers [_nextCharacter] = containers [_nextCharacter + 1];
					containers [_nextCharacter + 1] = _aux;
				} else {	// Last character, buddy and someone is still waving!!
					yield return new WaitForSeconds (_interval);
					continue;
				}
			}

			PathScript _container = containers [_nextCharacter];

			_container.Animacion ();
			_container.SetRandomPath ();
			_container.GetCharacter ().Walk ();

			yield return new WaitForSeconds (_interval);
			++_nextCharacter;
		}
	}

	private void addContainer(Character _char) {
		PathScript _container = Instantiate (ContainerPrefab).GetComponent<PathScript> ();
		containers.Add (_container);

		_container.SetCharacter (_char);
		_container.transform.SetParent (containerContainer.transform, false);
	}

	void Awake () {
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);

		prota = GameObject.Find ("Personaje").GetComponent<Prota> ();
		chica = GameObject.Find ("Chica").GetComponent<ChicaScript> ();
		containerContainer = GameObject.Find ("Contenedores");
		containers = new List<PathScript> ();

		buddyIndices = new List<int> ();
		nonBuddyIndices = new List<int> ();

		Vector3 _characterPos = new Vector3 (-3.9f, -11.53f, 27f);
		float _characterScale = 14.4424f;

		for (int i = Constants.NUM_BUDDIES; i >= 1; --i) {
			int _target = (int)((float)Constants.NUM_CHARACTERS / i);
			buddyIndices.Add (Random.Range (_target - Constants.BUDDY_INDEX_MARGIN, _target + Constants.BUDDY_INDEX_MARGIN));
		}

		for (float i = (float)Constants.NUM_BUDDIES - 0.5f; i >= 0.0f; --i) {
			int _target = (int)((float)Constants.NUM_CHARACTERS / i);
			nonBuddyIndices.Add (Random.Range (_target - Constants.BUDDY_INDEX_MARGIN, _target + Constants.BUDDY_INDEX_MARGIN));
		}

		for(int i = 0; i < buddyIndices[0]; ++i) {
			Character _char = CharacterManager.Instance.CreateCharacter (_characterPos, _characterScale);
			_char.Index = i;
			addContainer (_char);
		}

		{
			Character _char = CharacterManager.Instance.GetStoredCharacter (0);
			_char.Index = buddyIndices[0];
			_char.transform.localPosition = _characterPos;
			_char.transform.localScale = new Vector3 (_characterScale, _characterScale, _characterScale);
			addContainer (_char);
		}

		for(int i = buddyIndices[0]+1; i < buddyIndices[1]; ++i) {
			Character _char = CharacterManager.Instance.CreateCharacter (_characterPos, _characterScale);
			_char.Index = i;
			addContainer (_char);
		}

		{
			Character _char = CharacterManager.Instance.GetStoredCharacter (1);
			_char.Index = buddyIndices[1];
			_char.transform.localPosition = _characterPos;
			_char.transform.localScale = new Vector3 (_characterScale, _characterScale, _characterScale);
			addContainer (_char);
		}

		for(int i = buddyIndices[1]+1; i < buddyIndices[2]; ++i) {
			Character _char = CharacterManager.Instance.CreateCharacter (_characterPos, _characterScale);
			_char.Index = i;
			addContainer (_char);
		}

		{
			Character _char = CharacterManager.Instance.GetStoredCharacter (2);
			_char.Index = buddyIndices[2];
			_char.transform.localPosition = _characterPos;
			_char.transform.localScale = new Vector3 (_characterScale, _characterScale, _characterScale);
			addContainer (_char);
		}

		for(int i = buddyIndices[2]+1; i < Constants.NUM_CHARACTERS; ++i) {
			Character _char = CharacterManager.Instance.CreateCharacter (_characterPos, _characterScale);
			_char.Index = i;
			addContainer (_char);
		}

		wavingTime = 3.0f;
	}
        

	public void isEndGame () {
        if (this.noMoreFriends()||this.friendCounter == Constants.NUM_BUDDIES)
        {
            prota.fin = true;
        }
    }

	private void playerInteraction () {
		prota.Saluda ();
		if (wavingCharacter != null) {
			if (buddyIndices.Contains (wavingCharacter.Index)) {
				prota.Acertaste ();
				buddyIndices.Remove (wavingCharacter.Index);
                this.friendCounter++;
                isEndGame();
			}
			else if (nonBuddyIndices.Contains (wavingCharacter.Index)) {
				chica.Saluda ();
				prota.Fallaste ();
			}
		}
	}

    public bool noMoreFriends() {
        return buddyIndices.Count == 0;
    }


	// Use this for initialization
	void Start () {
		StartCoroutine (StartMovingCoroutine ());
	}

	void Update () {
		if (Input.touchSupported) {
			if (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Began)
				playerInteraction ();
		} else if (Input.GetButtonDown ("Jump"))
			playerInteraction ();
	}

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
