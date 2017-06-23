using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthForPlayer : MonoBehaviour {
	public float healths;
	public bool lost;
	public float ghostimagesize;
	public Image Healthbar;
	public bool Ready =false;
	public bool itsOn = false;
	// Use this for initialization

	void Update(){
		if (Input.anyKeyDown) {
			Ready = true;
		}
		if (Ready == true) {
			ghostimagesize = healths / 100f;
			if (ghostimagesize >= 0.95f) {
			
				Healthbar.color = new Color (Random.Range (.3f, .7f), Random.Range (0.3f, .7f), Random.Range (0.3f, .7f));
				Healthbar.fillAmount = ghostimagesize;

			}
			if (itsOn) {
				Healthbar.fillAmount = ghostimagesize;
				healths = healths - 0.10f;
			}
		}
		if (healths <= 0) {
			
			Application.LoadLevel (Application.loadedLevelName);


		}
	}

	void OnTriggerEnter2D(Collider2D other){
		itsOn = true;
	}


}
