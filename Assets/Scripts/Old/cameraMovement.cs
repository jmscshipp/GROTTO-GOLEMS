using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public eventsManager eventManager;
    public Transform[] levels;
    public int currentLevel = 4; // index of the center neutral zone level, 
    private bool moveNow = false;
    private float lerpAmount = 0f;
    private Vector3 nextPos;
    public map mapUI;

    // Update is called once per frame
    void Update()
    {
        if (moveNow == true)
        {
            lerpAmount += Time.deltaTime / 3f;
            transform.position = Vector3.Lerp(transform.position, nextPos, lerpAmount);
            if (lerpAmount >= 1)
                moveNow = false;
        }
    }

    public void Move(bool direction) // false = left, true = right, call different function for final level
    {
        // NEED TO CHECK HERE IF THEY'VE REACHED THE END OF THE MAP AND NEED TO DO WIN SEQUENCCE INSTEAD OF MOVE
        if (direction)
        {
            nextPos = levels[++currentLevel].position;
        }       
        else
        {
            nextPos = levels[--currentLevel].position;
        } 
        lerpAmount = 0;
        moveNow = true; 
        ResetRoom(true);
        mapUI.Move(direction);
    }

    public void ResetRoom(bool forMove) // called in Move and also when saw kills character, no room change
    {
        //levels[currentLevel].GetComponent<levelMarker>().thisRoom.StartCoroutine("ResetRoom", forMove);
        eventManager.BeforeLevel();
        if (!forMove)
            mapUI.Swap();
    }
}
