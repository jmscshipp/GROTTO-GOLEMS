using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lean : MonoBehaviour
{
    public movement playerMovement;
    public float amountToTravel; // set in inspector for each sprite to reach limit of outside\
    private Vector2 direction = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.inputVector.x > 0.2f)
            direction.x = 1f;
        else if (playerMovement.inputVector.x < -0.2f)
            direction.x = -1f;
        else
            direction.x = 0f;
        if (playerMovement.inputVector.y > 0.2f)
            direction.y = 1f;
        else if (playerMovement.inputVector.y < -0.2f)
            direction.y = -1f;
        else
            direction.y = 0f;

        transform.localPosition = new Vector2(Mathf.MoveTowards(transform.localPosition.x, (direction * amountToTravel).x, Time.deltaTime), Mathf.MoveTowards(transform.localPosition.y, (direction * amountToTravel).y, Time.deltaTime));
    }
}
