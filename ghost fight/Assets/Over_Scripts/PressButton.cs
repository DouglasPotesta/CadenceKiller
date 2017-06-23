using UnityEngine;
using System.Collections;

public class PressButton : MonoBehaviour {
    Sprite currentSprite;
    public Sprite up;
    public Sprite down;
	// Use this for initialization
	void Start () {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = down;
        }
        
    }
    void OnTriggerExit2D()
    {
        GetComponent<SpriteRenderer>().sprite = up;
    }
}
