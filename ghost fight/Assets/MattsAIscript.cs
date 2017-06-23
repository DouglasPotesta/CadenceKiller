using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MattsAIscript : MonoBehaviour {
	//Distance - The distance from the ai to the player
	private float Distance;
	//Target - usually this is the player, this must be set in the inspector to SOMETHING in order for this to run
	public GameObject target;
	//point_x is a location marker for a direction that the ai will travel towards
	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	public GameObject point4;
	//these distances are just the relative distances from each point the ai is
	private Vector3 point1distance;
	private Vector3 point2distance;
	private Vector3 point3distance;
	private Vector3 point4distance;
	//look at distance allows behaviour such as ai caution to happen
	public float lookatdistance = 25.0f;
	//attack range is the range from the target to the ai
	//-when the target is within this range the ai will simply move to the player and circle the player continuously
	public float attackrange = 15.0f;
	//movespeed - how fast the ai moves
	public float movespeed = 5.0f;
	//damping - determines the turning speed of the ai
	private float damping = 6.0f;
	//direction - which point/target the ai is moving towards
	public string direction;
	//Scared - an audio clip for when damage is inflicted on the ai
	public AudioClip Scared;
	//End through Health - These make up the ai health system, It is based on how long the ai is inside the trigger of a damaging substance
	private float End;
	private float begin;
	private float depleted;
	private float depleting;
	public float TotalDamage;
	//Dying - whether or not the ai is taking damage, determines whether or not a co-behaviour is followed or not
	public bool Dying;
	//Status - the behaviour path the ai should be following (Roaming, scared, or Attacking)
	public string Status;
	public string button;
	public float health = 15;
	public GameObject DaddyorMommy;
	public Canvas ButtonImage;
	public bool successful;
	public AudioClip A;
	public AudioClip B;
	public AudioClip X;
	public AudioClip Y;
	public AudioSource Guitar;
	public AudioClip Wrong;
	bool Inputable;
	public HealthForPlayer healthsystem;



	void Start () {
		if (target == null){
			target = GameObject.Find ("Target");
			ButtonImage = GetComponentInChildren<Canvas> ();
			ButtonImage.gameObject.SetActive (false);
			Guitar = GameObject.Find ("Main Camera (LeftCol)").GetComponent<AudioSource> ();

		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		//Sets Start = to the frame count so that it can be compared to the current framecount (End)
		//begin = Time.frameCount;
		if (other.tag == "Bar")
		{
			healthsystem = other.GetComponent<HealthForPlayer>();
			ButtonImage.gameObject.SetActive (true);
			Inputable = true;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		// depleted is set so that the next time it is hurt it remembers how much damage it has already recieved
		//depleted = TotalDamage;
		//Sets
		//Dying = false;
		if (other.tag == "Bar") {
			Inputable = false;
			ButtonImage.gameObject.SetActive (false);
		}

	}
	

	void Update () {
		//Resets the velocity every frame and calculates distance from the target
		GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, 0f, 0f);
		Distance = Vector3.Distance (target.gameObject.transform.position, transform.position);
		if (Inputable && Input.GetKeyDown (button)) {
			Guitar.GetComponent<AudioSource> ().volume = Guitar.GetComponent<AudioSource> ().volume + 0.05f;

			if (healthsystem.healths < 95) {
				healthsystem.healths = healthsystem.healths + 5f;
			}
			print ("adding");

			Destroy (DaddyorMommy);

		} 
		else if (Inputable && Input.anyKeyDown && Guitar.GetComponent<AudioSource> ().volume >= 0.3f) {
			Guitar.GetComponent<AudioSource> ().volume = Guitar.GetComponent<AudioSource> ().volume - 0.2f;
			Guitar.GetComponent<AudioSource> ().PlayOneShot (Wrong, .7f);

		}

		if (Status == "Roaming") {
			Roam ();

				}
		//Refer to lookAt () for more info on this
	else if (Distance < lookatdistance) 
		{
			//runs the co-bahviour lookat
			lookAt ();
			GetComponent<Collider2D>().isTrigger = false;
		}
		else if (Distance > lookatdistance)
		{

			GetComponent<Collider2D>().isTrigger = false;
		}

		if (Distance > attackrange)
		{
			Status = "Roaming";
		}
		else if (Status == "scared"){
			run ();
		}
		else if (Dying) {


		}
		else if (Distance < attackrange)
		{

			GetComponent<Collider2D>().isTrigger = true;
			attack ();
			Status = "Attacking";
		}

	}
	//currently is not set to do anything. To make this work one has to add more to the Roam if statement. This is another behaviour option where the ai just looks in the direction of the player
	void lookAt () 
	{
		Quaternion rotation = Quaternion.LookRotation (target.gameObject.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void attack ()
	{
		transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		if (Dying)
		{
			GetComponent<Renderer>().material.color = Color.red;
		}
		else {
			GetComponent<Renderer>().material.color = Color.gray;
		}

	}
	void run ()
	{
		transform.Translate (Vector3.back * Time.deltaTime * movespeed);
		GetComponent<Collider2D>().isTrigger = false;
		if (Dying)
		{
			GetComponent<Renderer>().material.color = Color.red;
		}
		else {
			GetComponent<Renderer>().material.color = Color.white;
		}

		
	}
	//Roam:
	//-Ghost moves from point 1 to 2 to 3 to 4
	//-changes direction only after it is within a specified distance to the point
	//-points are specified in the inspector (they are of class game object)
	//	-Place empty game objects along a path and then be sure to attach them to this script in the inspector
	void Roam (){
		point1distance = transform.localPosition - point1.transform.localPosition;
		point2distance = transform.localPosition - point2.transform.localPosition;
		point3distance = transform.localPosition - point3.transform.localPosition;
		point4distance = transform.localPosition - point4.transform.localPosition;
		if (direction == "point2") {
			Quaternion rotation = Quaternion.LookRotation (point2.gameObject.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
				}
		else if (direction == "point3") {
			Quaternion rotation = Quaternion.LookRotation (point3.gameObject.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		}
		else if (direction == "point4") {
			Quaternion rotation = Quaternion.LookRotation (point4.gameObject.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		}
		else if (direction == "point1") {
			Quaternion rotation = Quaternion.LookRotation (point1.gameObject.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		}
		if (point1distance.magnitude < 1) {
			direction = "point2";

				}
		else if (point2distance.magnitude < 1) {
			direction = "point3";

		}
		else if (point3distance.magnitude < 1) {
			direction = "point4";

		}
		else if (point4distance.magnitude < 1) {
			direction = "point1";

			}
		//Simple texture collor change to indicate noticing the player and whether the ai is being damaaged
		if (Dying)
		{
			GetComponent<Renderer>().material.color = Color.red;
		}
		else if (Distance < lookatdistance) 
		{
			GetComponent<Renderer>().material.color = Color.white;

		}
		else if (Distance > lookatdistance)
		{
			GetComponent<Renderer>().material.color = Color.clear;
		}


		}
	void OnDestroy(){
		
	}
}