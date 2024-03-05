using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool canMove = true;

    public float panSpeed;

    public float edgeRercent = 0.05f;

    public float zoomSpeed;

    public float minY, maxY;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }
        if (!canMove)
        {
                return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > Screen.height - (Screen.height * edgeRercent)) //pan cam like moba
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < Screen.height * edgeRercent)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x > Screen.width - (Screen.height * edgeRercent))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < Screen.width * edgeRercent)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if(mouseWheel != 0f)
        {
            Vector3 pos = transform.position;
            pos.y -= mouseWheel*zoomSpeed;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
    }
}
