using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSelector : MonoBehaviour
{
    private float moveTimer = 0f;
    private bool moving = false;

    private Vector2 startPoint, dest;

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            moveTimer += Time.deltaTime;
            transform.localPosition = Vector2.Lerp(startPoint, dest, moveTimer);
            if (moveTimer >= 1f)
                moving = false;
        }
    }

    public void Move(Vector2 startPoint, Vector2 dest)
    {
        Debug.Log(startPoint + " to " + dest);
        moveTimer = 0f;
        this.startPoint = startPoint;
        this.dest = dest;
        moving = true;
    }
}
