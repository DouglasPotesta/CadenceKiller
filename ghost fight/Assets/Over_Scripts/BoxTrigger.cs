using UnityEngine;
using System.Collections;

public class BoxTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == "Box")
        {
            MovePuzzle.boxPlaced = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.name == "Box")
        {
            MovePuzzle.boxPlaced = false;
        }
    }
}
