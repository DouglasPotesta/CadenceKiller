using UnityEngine;
using System.Collections;

public class MovePosition : MonoBehaviour {

	public Transform mainCharacter;
	public Transform targetPosition;
	void OnTriggerEnter2D(){
		MoveCharacterPosition ();
	}

	void MoveCharacterPosition(){
		mainCharacter.position = new Vector3 (targetPosition.position.x,targetPosition.position.y,targetPosition.position.z);
	}
}
