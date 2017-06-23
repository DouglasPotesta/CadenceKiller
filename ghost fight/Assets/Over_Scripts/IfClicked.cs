using UnityEngine;
using System.Collections;

public class IfClicked : MonoBehaviour {

	void OnMouseDown()
    {
        if(transform.name == "C")
        {
            Debug.Log("Played C");

            if(MetaKeyPuzzle.playedC == false)
            {
                MetaKeyPuzzle.playedC = true;
            }
            //else
            //{
            //    MetaKeyPuzzle.playedE = false;
            //    MetaKeyPuzzle.playedG = false;
            //}

        }
        else if(transform.name == "C#")
        {
            Debug.Log("Played C#");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "D")
        {
            Debug.Log("Played D");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "D#")
        {
            Debug.Log("Played D#");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "E")
        {
            Debug.Log("Played E");
            if (MetaKeyPuzzle.playedE == false)
            {
                MetaKeyPuzzle.playedE = true;
            }
            //else
            //{
            //    MetaKeyPuzzle.playedC = false;
            //    MetaKeyPuzzle.playedG = false;
            //}
        }
        else if (transform.name == "F")
        {
            Debug.Log("Played F");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "F#")
        {
            Debug.Log("Played F#");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "G")
        {
            Debug.Log("Played G");
            if (MetaKeyPuzzle.playedG == false)
            {
                MetaKeyPuzzle.playedG = true;
            } else {
                MetaKeyPuzzle.playedE = false;
                MetaKeyPuzzle.playedC = false;
            }
        }
        else if (transform.name == "G#")
        {
            Debug.Log("Played G#");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "A")
        {
            Debug.Log("Played A");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "A#")
        {
            Debug.Log("Played A#");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
        else if (transform.name == "B")
        {
            Debug.Log("Played B");
            MetaKeyPuzzle.playedC = false;
            MetaKeyPuzzle.playedE = false;
            MetaKeyPuzzle.playedG = false;
        }
    }
}