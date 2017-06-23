using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

	// Use this for initialization
	public void StartGameNOW () {
		SceneManager.LoadScene("MainScene");
	}
}
