using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota: MonoBehaviour {
    GameLogic gameLogic;
    public bool fin;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void Saluda(){
		this.GetComponent<Animator> ().SetBool ("finSaludo", false);
        this.GetComponent<Animator>().SetBool("Saludando", true);
        transform.Find ("brazoprota").GetComponent<Animator> ().SetBool ("Saludando", true);
	}

	public void FinSaludo(){
		transform.Find ("brazoprota").GetComponent<Animator> ().SetBool ("Saludando", false);
		this.GetComponent<Animator> ().SetBool ("finSaludo", true);
        this.GetComponent<Animator>().SetBool("Saludando", false);
    }

	public void Fallaste(){
		this.GetComponent<Animator>().SetInteger ("Acertaste", 1);
	}

	public void Acertaste(){
        this.GetComponent<Animator>().SetInteger ("Acertaste", 2);
    }

	public void FinAnimacion(){
        this.GetComponent<Animator>().SetInteger ("Acertaste", 0);
	}
  
    public void finJuego()
    {
        if (fin)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverWin");
        }
    }

    public void acertasteSound()
    {
    }

    public void fallasteSound(){
	}
}
