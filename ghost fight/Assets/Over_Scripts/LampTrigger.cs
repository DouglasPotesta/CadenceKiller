using UnityEngine;
using System.Collections;

public class LampTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == "Lamp")
        {
            MovePuzzle.lampPlaced = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.name == "Lamp")
        {
            MovePuzzle.lampPlaced = false;
        }
    }
}
