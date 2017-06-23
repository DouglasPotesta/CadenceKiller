using UnityEngine;
using System.Collections;

public class MovePuzzle : MonoBehaviour {
    public static bool chairPlaced = false;
    public static bool lampPlaced = false;
    public static bool boxPlaced = false;
    public static bool tablePlaced = false;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if(chairPlaced || lampPlaced || boxPlaced || tablePlaced)
        {
            Debug.Log("Placed it!");
        }

        if(chairPlaced && lampPlaced && boxPlaced && tablePlaced)
        {
            Debug.Log("Puzzle Complete!");
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.name == "Chair")
        {
            chairPlaced = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.name == "Chair")
        {
            chairPlaced = false;
        }
    }
}
