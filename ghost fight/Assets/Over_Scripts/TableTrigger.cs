using UnityEngine;
using System.Collections;

public class TableTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == "Table")
        {
            MovePuzzle.tablePlaced = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.name == "Table")
        {
            MovePuzzle.tablePlaced = false;
        }
    }
}
