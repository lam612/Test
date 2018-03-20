using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Enter
}

public class MouseClick : MonoBehaviour {

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

        if (Input.touchCount > 0)
            foreach (Touch touch in Input.touches)
                if (touch.phase == TouchPhase.Began)
                {
                    float gestureDist = (touch.position - (Vector2)transform.position).magnitude;
                    if (gestureDist < maxSwipeDist)
                        OT.Move(TheTouchTile.indRow, TheTouchTile.indCol);
                }
    }
}
