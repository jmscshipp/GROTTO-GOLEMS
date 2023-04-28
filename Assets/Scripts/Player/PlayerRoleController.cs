using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoleController : MonoBehaviour
{
    public GameObject seekerGraphics;
    public GameObject hiderGraphics;

    public enum Direction { Left, Right };
    private Direction goalDirection;
    private enum Role { Hider, Seeker };
    private Role currentRole;
    private GameObject currentGraphics;

    private static int spawnNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        // TEMPORARY, COME BACK AND MAKE RANDOMIZED SYSTEM TO SET THIS
        spawnNum++;
        if (spawnNum > 1)
        {
            SetToHider();
            goalDirection = Direction.Right;
            gameObject.tag = "Hider";
        }
        else
        {
            SetToSeeker();
            goalDirection = Direction.Left;
            gameObject.tag = "Seeker";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchRole()
    {
        if (currentRole == Role.Hider)
            SetToSeeker();
        else
            SetToHider();
    }

    public void SetToHider()
    {
        currentRole = Role.Hider;
        Destroy(currentGraphics);
        currentGraphics = Instantiate(hiderGraphics, transform);
    }

    public void SetToSeeker()
    {
        currentRole = Role.Seeker;
        Destroy(currentGraphics);
        currentGraphics = Instantiate(seekerGraphics, transform);

    }

    public Direction GetGoalDirection()
    {
        return goalDirection;
    }
}
