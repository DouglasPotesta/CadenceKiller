using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public bool random = false;

	public string targetLevel;

	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag == "Player"){
			Application.LoadLevel(targetLevel);
		}
		if(random){

		}
	}

	void OnTriggerExit2D(){
		if(random){
				
		}
	}
}
