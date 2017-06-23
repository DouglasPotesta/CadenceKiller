using UnityEngine;
using System.Collections;

public class TurnLightOn : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            GetComponent<Light>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            GetComponent<Light>().enabled = false;
        }
    }
}
