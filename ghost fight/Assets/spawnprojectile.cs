using UnityEngine;
using System.Collections;

public class spawnprojectile : MonoBehaviour {

	public bool throwing;
	public bool started;
	public Object projectile;
	public Transform[] transforms;




	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (throwing) {
			if (!started) {
				started = true;
				StartCoroutine (WaitAndPrint (2.0f));
			}
		} 
		else {
			if (!started) {
				started = true;
				StartCoroutine (WaitAndChange (2.0f));
			}


		}

			


	
	}
	IEnumerator WaitAndChange(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		print("WaitAndPrint " + Time.time);
		throwing = true;
		started = false;
	}
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		int randomnumber;
		randomnumber = Random.Range (0, 4);



		print("WaitAndPrint " + Time.time);
		throwing = false;
		started = false;
		Instantiate (projectile, transforms [randomnumber].transform.position, new Quaternion (0,0,0,0));
	}
}
