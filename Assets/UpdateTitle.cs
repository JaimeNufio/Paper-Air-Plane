using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateTitle : MonoBehaviour {

	public Text Board;
	public Image Wood;
	public GameObject one,two;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!Global_.gameOver) {
			Board.text = Global_.board;
			if (Wood.transform.localPosition.y > 250) {
				Wood.transform.localPosition += new Vector3 (0, -3f, 0);
			}

			if (one.transform.position.x < -2) {
				one.transform.position += new Vector3 (0.05f, 0, 0);
			}

			if (two.transform.position.x < -2) {
				two.transform.position += new Vector3 (0.05f, 0, 0);
			}
		} else {
			Board.text = "Swipe to play again!";
			if (Wood.transform.localPosition.y < 200) {
				Wood.transform.localPosition -= new Vector3 (0, -3f, 0);
			}

			if (one.transform.position.x > -4) {
				one.transform.position -= new Vector3 (0.05f, 0, 0);
			}

			if (two.transform.position.x > -4) {
				two.transform.position -= new Vector3 (0.05f, 0, 0);
			}
		}
	}
}
