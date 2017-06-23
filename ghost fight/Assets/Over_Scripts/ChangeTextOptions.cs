using UnityEngine;
using System.Collections;

public class ChangeTextOptions : MonoBehaviour {
	public string[] targetText = new string[3];

	public Color targetColor;

	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag == "Player"){
			TextScript scrip = col.GetComponent<TextScript>();
			scrip.stop();
			TextScript.changeColor = targetColor;
			TextScript.possibleText = targetText;
			TextScript.currentTextVal = 0;
			TextScript.previousTextVal = TextScript.currentTextVal + 1;
		}
	}
}
