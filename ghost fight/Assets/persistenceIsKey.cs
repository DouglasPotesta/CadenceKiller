using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class persistenceIsKey : MonoBehaviour {

	public static persistenceIsKey saveSystem;

	//puzzle booleans
	public static bool hasPuzzle1Key = false;
	public static bool hasPuzzle2Key = false;
	public static bool hasPuzzle3Key = false;

	public static bool puzzle1Complete = false;
	public static bool puzzle2Complete = false;
	public static bool puzzle3Complete = false;

	//boss booleans
	public static bool beatBoss1 = false;
	public static bool boss1Dead = false;

	public static bool beatBoss2 = false;
	public static bool boss2Dead = false;

	public static bool beatBoss3 = false;
	public static bool boss3Dead = false;

	//player data tracking
	//public GameObject player;

	public static Vector3 playerPos;

	public bool LoadScene = false;
	public string scenetoload;


	//fadeOut
	public Image blackScreen;
	public Color editingColor;

	public bool fadeOut = false;
	public bool fadeIn = false;

	void Awake() {
		if (saveSystem == null) {
			DontDestroyOnLoad (gameObject);
			saveSystem = this;
		} else if (saveSystem != this) {
			Destroy (gameObject);
		}
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.O)) {
			scenetoload = "MainScene";
			fadeIn = true;
			//ceneManager.LoadScene("MainScene");
			//FadeIn ();
		}
		if (fadeOut) {
			FadeOut ();
		}
		if (fadeIn) {
			FadeIn ();
		}
		if (Input.GetKeyDown(KeyCode.P)) {
			scenetoload = "Pianist";
			fadeIn = true;
			//SceneManager.LoadScene("Pianist");
		}

		if(LoadScene){
			SceneManager.LoadScene("MainScene");
			LoadScene = false;
		}
		blackScreen.color = editingColor;
	}
		

	public void FadeIn(){

		editingColor.a += Time.deltaTime;

		if (editingColor.a >= 1.0f) {
			//StoreInfo (true);

			SceneManager.LoadScene (scenetoload);

			fadeIn = false;
			fadeOut = true;

		}
	}

	public void FadeOut(){
		editingColor.a -= Time.deltaTime;

		if (editingColor.a <= 0.0f) {
			//StoreInfo (false);
			fadeOut = false;
		}
	}

	public IEnumerator fadeToScene(string sceneName){
		bool loop = true;

		while (loop) {



			yield return new WaitForSeconds (0.01f);
		}



		//StartCoroutine (fadeIn());
		LoadScene = true;
		yield return null;
	}

	/*public IEnumerator fadeIn(){
		while (true) {

			editingColor.a -= Time.deltaTime;

			if (editingColor.a == 0.0f) {
				yield return null;
			}

			yield return new WaitForSeconds (0.01f);
		}
	}*/

	public void StoreInfo(bool goingToMainScene){
		if (goingToMainScene) {
			//player.transform.position = new Vector3 (playerPos.x, playerPos.y, playerPos.z);
		} else if (goingToMainScene == false) {
			//playerPos = player.transform.position;
		}
	}
}
