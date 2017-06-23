using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 movementVector;
    float speed;

    public Transform cursorLight;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        speed = 1.7f;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.W))
        {
            movementVector.y = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementVector.y = -speed;
        }
        else
        {
            movementVector.y = 0.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementVector.x = -speed;
        }else if (Input.GetKey(KeyCode.D))
        {
            movementVector.x = speed;
        }
        else
        {
            movementVector.x = 0.0f;
        }

        rb.velocity = movementVector;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        cursorLight.position = mousePos;

    }
}
