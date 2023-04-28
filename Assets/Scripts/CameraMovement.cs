using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMovement : MonoBehaviour
{
    private Vector3 currentPos;
    private Vector3 goalPos;
    private bool moving;
    private float lerpAmount;

    public float camMoveSpeed = 0.7f;
    public UnityEvent ArrivedAtGoal;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
        moving = false;
        lerpAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            lerpAmount += Time.deltaTime / (1.0f / camMoveSpeed);
            transform.position = Vector3.Lerp(currentPos, goalPos, lerpAmount);

            // made it to goal pos
            if (lerpAmount >= 1.0f)
            {
                currentPos = transform.position;
                moving = false;
                ArrivedAtGoal.Invoke();
            }
        }
    }

    public void Move(Vector2 roomPos)
    {
        lerpAmount = 0.0f;
        goalPos = new Vector3(roomPos.x, roomPos.y, -10f);
        moving = true;
    }
}
