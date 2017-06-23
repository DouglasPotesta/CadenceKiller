using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {
    Vector3 targetVector;
    public Transform player;
    public Camera cam;

    float reqRef = 0.0f;

    public bool isColLeft;
    public bool isColRight;
    public bool isColUp;
    public bool isColDown;

    bool moveCam;

    void Update()
    {
        if (moveCam)
        {
            if (isColUp) {
                if (Input.GetKey(KeyCode.W)) {
                    targetVector = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.04f, cam.transform.position.z);
                    cam.transform.position = new Vector3(targetVector.x, targetVector.y, targetVector.z);
                }
                else
                {
                    moveCam = false;
                }
            }
            else if (isColDown)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    targetVector = new Vector3(cam.transform.position.x, cam.transform.position.y - 0.04f, cam.transform.position.z);
                    cam.transform.position = new Vector3(targetVector.x, targetVector.y, targetVector.z);
                }
                else
                {
                    moveCam = false;
                }
            }
            else if (isColRight)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    targetVector = new Vector3(cam.transform.position.x + 0.04f, cam.transform.position.y, cam.transform.position.z);
                    cam.transform.position = new Vector3(targetVector.x, targetVector.y, targetVector.z);
                }
                else
                {
                    moveCam = false;
                }
            }
            else if (isColLeft)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    targetVector = new Vector3(cam.transform.position.x - 0.04f, cam.transform.position.y, cam.transform.position.z);
                    cam.transform.position = new Vector3(targetVector.x, targetVector.y, targetVector.z);
                }
                else
                {
                    moveCam = false;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            moveCam = true;
        }
        if(col.transform.tag == "RoomEdge")
        {
            moveCam = false;
        }
    }
}
