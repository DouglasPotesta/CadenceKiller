using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyClass : MonoBehaviour {

	public enum Difficulty{Easy,Medium,Hard};
	public Difficulty diff = Difficulty.Easy;
	public float fireRate = .333333333333333333333333333333f;
	public float[] allSpeeds = new float [4] {0.5f,1.0f,1.5f,2.0f};
	public Transform[] allLocations;
	string[] allButtons;
	int notecount = 0;
	public AudioClip[] songFiles;
	public int [] song1;
	public int [] song2;
	public int [] song3;
	public int [] song4;
	public int [][] songs;
	public int songChoice;
	public float waitLength = 0;

	float[] speeds;
	Vector2 [] locations;
	string[] buttons;
	public Sprite[] buttonImages;
	bool ready = false;


	public GameObject projectile;
	public bool battleStartTimer =false;
	public float delayTime = 6.4f;





	// Initializes
	void Start () {
		songs = new int[][] {song1, song2, song3, song4};

		allButtons = new string [4] {"a","s","k","l"};
		if (diff == Difficulty.Easy) {
			for(int i = 0; i < songs[songChoice].Length; i++){
				songs [songChoice] [i] = (int) ((float)songs [songChoice] [i]/ 2.1f);
			}
			//int rando = Random.Range (0, Speeds.Length - 1);
			speeds = new float [2] {allSpeeds [0], allSpeeds [1]};
			locations = new Vector2 [2] {allLocations [0].position, allLocations [1].position};
			// 
			buttons = new string [2] {allButtons [0], allButtons [1]};
		}	
		else if (diff == Difficulty.Medium) {
			for(int i = 0; i < songs[songChoice].Length; i++){
				songs [songChoice] [i] =(int) ((float)songs [songChoice] [i]/ 1.33333f);
			}
			speeds = new float [3] {allSpeeds [0], allSpeeds [1], allSpeeds[2]};
			locations = new Vector2 [3] {allLocations [0].position, allLocations [1].position, allLocations [2].position};
			// 
			buttons = new string [3] {allButtons [0], allButtons [1], allButtons [2]};
		}
		else if (diff == Difficulty.Hard) {
			speeds = new float [3] {allSpeeds [1], allSpeeds[2], allSpeeds[3]};
			locations = new Vector2 [4] {allLocations [0].position, allLocations [1].position,  allLocations [2].position,  allLocations [3].position};
			// 
			buttons = new string [4] {allButtons [0], allButtons [1], allButtons [2], allButtons [3]};
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			ready = true;

		}
		if (ready == true && notecount < songs [songChoice].Length) {
			if (battleStartTimer == false) {
				StartCoroutine (Battlelengthtimer ());
				StartCoroutine (SpawnNote ());

				battleStartTimer = true;
			
			}
		}
	}

	IEnumerator Battlelengthtimer (){
		yield return new WaitForSeconds(delayTime);
		AudioSource keyboard = GetComponent<AudioSource> ();
		keyboard.clip = songFiles [songChoice];
		keyboard.Play();


	}
	IEnumerator Battlelengthender (){
		yield return new WaitForSeconds(delayTime + 5);
		Application.LoadLevel ("MainScene");


	}
	IEnumerator SpawnNote() {
		yield return new WaitForSeconds (waitLength-3.2f);


		while (notecount < songs [songChoice].Length) {
			if (songs [songChoice] [notecount] < 4) {
				GameObject projectileClone = (GameObject)Instantiate (projectile, locations [songs [songChoice] [notecount]], new Quaternion (0, 0, 0, 0));
				projectileClone.GetComponentInChildren<MattsAIscript> ().movespeed = speeds [Random.Range (0, speeds.Length)];
				projectileClone.GetComponentInChildren<MattsAIscript> ().button = buttons [songs [songChoice] [notecount]];
				projectileClone.GetComponentInChildren<Image> ().sprite = buttonImages [songs [songChoice] [notecount]];
				Destroy (projectileClone, 15f);
			}
			notecount++;
			yield return new WaitForSeconds(fireRate);
		}
		StartCoroutine (Battlelengthender ());
	}
}
