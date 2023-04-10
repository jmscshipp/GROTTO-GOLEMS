using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLean : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float amountToTravel = 0.144f; // distance to outside limit
    private Vector2 direction;

    private void Start()
    {
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // x axis
        if (playerMovement.inputVector.x > 0.2f)
            direction.x = 1f;
        else if (playerMovement.inputVector.x < -0.2f)
            direction.x = -1f;
        else
            direction.x = 0f;
        // y axis
        if (playerMovement.inputVector.y > 0.2f)
            direction.y = 1f;
        else if (playerMovement.inputVector.y < -0.2f)
            direction.y = -1f;
        else
            direction.y = 0f;

        transform.localPosition = new Vector2(Mathf.MoveTowards(transform.localPosition.x, (direction * amountToTravel).x, Time.deltaTime), 
            Mathf.MoveTowards(transform.localPosition.y, (direction * amountToTravel).y, Time.deltaTime));
    }
}
