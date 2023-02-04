using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customCursor : MonoBehaviour
{
    Vector2 cursorSpot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        cursorSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorSpot;
    }
}
