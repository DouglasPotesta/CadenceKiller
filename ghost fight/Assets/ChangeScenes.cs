using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour {
	public string levelTarget;
	//public GameObject afterBattleText;
	void OnTriggerEnter2D(){
		LoadLevel ();
	}

	void LoadLevel (){
		//afterBattleText.SetActive (true);
		SceneManager.LoadScene (levelTarget);
	}
}
