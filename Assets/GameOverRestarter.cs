using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverRestarter : MonoBehaviour {

	public Image sign;
	public Text words;

	string textToWrite;
	bool textAssinged = false;

	//Vector3 originalPos;

	string[] endingWords =  {"Congrats!","Wanna play again?","Excellent!","Super!","Good Job!"};

	// Use this for initialization
	void Start () {
		//originalPos = sign.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Global_.gameOver){
			if (sign.transform.localPosition.y < -520) {
				if (!textAssinged) {
					textToWrite = endingWords[Random.Range(0,endingWords.Length)];
					textAssinged = true;
				}
				words.transform.SetSiblingIndex (5);
				sign.transform.localPosition += new Vector3 (0,5,0);
				words.text = "\n"+textToWrite+"\n\nYou flew "+Global_.distance+"ft!";

			}
			if (Global_.tryToRest) {
				Global_.gameOver = false;
				Global_.tryToRest = false;
				SceneManager.LoadScene ("mainGame");
			}
		}
	}
}
