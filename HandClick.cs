using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClick : MonoBehaviour {

    private float maxSwipeDist = 18.0f;
    private OneTouch OT;

    // Use this for initialization
    void Start()
    {
        OT = OneTouch.FindObjectOfType<OneTouch>();
    }

    // Update is called once per frame
    void Update()
    {
        Tile TheTouchTile = gameObject.GetComponent<Tile>();

        if (Input.GetMouseButtonDown(0))
        {
            float MousegestureDist = ((Vector2)Input.mousePosition - (Vector2)transform.position).magnitude;
            if (MousegestureDist < maxSwipeDist)
            {
                OT.Move(TheTouchTile.indRow, TheTouchTile.indCol);
            }
        }
    }
}
