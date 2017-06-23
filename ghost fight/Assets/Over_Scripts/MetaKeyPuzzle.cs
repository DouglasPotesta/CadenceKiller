using UnityEngine;
using System.Collections;

public class MetaKeyPuzzle : MonoBehaviour {
    public static bool playedC = false;

    public static bool playedE = false;

    public static bool playedG = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(playedC && playedE && playedG)
        {
            Debug.Log("You Win!!");
        }
	}
}
