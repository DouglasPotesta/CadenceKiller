using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
	public static string[] possibleText = new string[3];

	public Text shownText;

	public static int previousTextVal = 0;
	public static int currentTextVal = 0;

	public Text currentPage;
	public Text totalPages;

	public static bool typingText = true;

	public float textRate = 0.0001f;


	public Color textColor;

	public static Color changeColor;

	// Use this for initialization
	void Start () {
		possibleText[0] = "Bitch";
		possibleText[1] = "Bitches";
		possibleText[2] = "Bitchezzz";

		StartCoroutine(TypeOutText(0));

		changeColor = textColor;
	}
	
	// Update is called once per frame
	void Update () {
		//TypeOutText(0, 1.0f);
		//shownText.text = possibleText[currentTextVal];


		if(Input.GetKeyDown(KeyCode.E) && typingText == false){
			if(currentTextVal < possibleText.Length - 1){
				previousTextVal = currentTextVal;
				currentTextVal += 1;
			}
		}
		if(Input.GetKeyDown(KeyCode.Q) && typingText == false){
			if(currentTextVal > 0){
				previousTextVal = currentTextVal;
				currentTextVal -= 1;
			}
		}

		if(currentTextVal != previousTextVal){
			StartCoroutine("TypeOutText", currentTextVal);
			previousTextVal = currentTextVal;
		}

		//if(textColor != changeColor){
		//	textColor = changeColor;
		//}

		shownText.color = changeColor;
		currentPage.text = "" + (currentTextVal + 1);
		totalPages.text = "" + possibleText.Length;

	}

	//public void TypeOutText(int index, float rate){
	//	
	//}

	public IEnumerator TypeOutText(int index){
		typingText = true;
		shownText.text = "";
		for (int x = 0; x < possibleText[index].Length; x++){
			shownText.text += possibleText[index][x];
			yield return new WaitForSeconds(textRate);

		}
		typingText = false;
		yield break;
	}

	public void stop(){
		StopCoroutine("TypeOutText");
	}
}
