using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	public GameObject canny;
	public bool paused = false;

	public GameObject controls;
	public GameObject credits;


	
	// Update is called once per frame
	void Update () {
		if(paused == true){
			canny.SetActive(true);
			Time.timeScale = 0.0f;
			Cursor.visible = true;
		}else{
			canny.SetActive(false);
			Time.timeScale = 1.0f;
			Cursor.visible = false;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			if(paused == true){
				paused = false;
			}else{
				paused = true;
			}
		}
	}

	public void Controls(){
		if(controls.activeSelf == false){
			controls.SetActive(true);
	
		}else{
			controls.SetActive(false);
		}
	}
	public void Credits(){
		if(credits.activeSelf == false){
			credits.SetActive(true);

		}else{
			credits.SetActive(false);
		}
	}
	public void Quit(){
		Application.Quit();
	}
}
