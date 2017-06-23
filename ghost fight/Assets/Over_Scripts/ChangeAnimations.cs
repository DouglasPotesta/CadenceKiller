using UnityEngine;
using System.Collections;

public class ChangeAnimations : MonoBehaviour {

	Animator animator;

	public Light ghostLight;
	public Gradient lightColor;
	public float gradientPercent;
	float timer = 0f;
	float targetTime = 1.0f;


	void Start () {
		animator = GetComponent<Animator>();
	}


	void Update () {
		//activates animations in relation to movement
		if(Input.GetKey(KeyCode.W)){
			animator.SetInteger("Vertical", -1);

		}else if(Input.GetKey(KeyCode.D)){
			animator.SetInteger("Horizontal", 1);

		}else if(Input.GetKey(KeyCode.S)){
			animator.SetInteger("Vertical", 1);

		}else if(Input.GetKey(KeyCode.A)){
			animator.SetInteger("Horizontal", -1);

		}

		//deactivates transitions when done going a direction
		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){
			animator.SetInteger("Vertical", 0);

		}
		if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
			animator.SetInteger("Horizontal", 0);

		}

		//makes it so you don't transition to multiple animations at once
		if(animator.GetInteger("Horizontal") == 1 || animator.GetInteger("Horizontal") == -1){
			animator.SetInteger("Vertical", 0);
		}else if(animator.GetInteger("Vertical") == 1 || animator.GetInteger("Vertical") == -1){
			animator.SetInteger("Horizontal", 0);
		}

		//Light Animating

		if(timer < targetTime){
			timer += Time.deltaTime * 0.7f;
		}else{
			timer = 0f;
		}
		gradientPercent = timer;
		ghostLight.color = lightColor.Evaluate(gradientPercent);
	}
}
