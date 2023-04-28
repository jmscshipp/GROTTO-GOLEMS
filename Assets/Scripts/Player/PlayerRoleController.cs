using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

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

    private GameObject eventsystem;

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
            // HARD CODING. BAD
            eventsystem = GameObject.Find("P2EventSystem");
            GetComponent<PlayerInput>().uiInputModule = eventsystem.GetComponent<InputSystemUIInputModule>();
            eventsystem.GetComponent<AbilityUI>().AssignPlayerToButtons(GetComponent<PlayerAbility>());
            GetComponent<PlayerAbility>().SetSelectionUI(GameObject.Find("P2SelectionUI"));
        }
        else
        {
            SetToSeeker();
            goalDirection = Direction.Left;
            gameObject.tag = "Seeker";
            // HARD CODING. BAd
            eventsystem = GameObject.Find("P1EventSystem");
            GetComponent<PlayerInput>().uiInputModule = eventsystem.GetComponent<InputSystemUIInputModule>();
            eventsystem.GetComponent<AbilityUI>().AssignPlayerToButtons(GetComponent<PlayerAbility>());
            GetComponent<PlayerAbility>().SetSelectionUI(GameObject.Find("P1SelectionUI"));
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
        gameObject.tag = "Hider";
    }

    public void SetToSeeker()
    {
        currentRole = Role.Seeker;
        Destroy(currentGraphics);
        currentGraphics = Instantiate(seekerGraphics, transform);
        gameObject.tag = "Seeker";
    }

    public Direction GetGoalDirection()
    {
        return goalDirection;
    }

    public void SetToUIMode()
    {
        GetComponent<PlayerInput>().uiInputModule = eventsystem.GetComponent<InputSystemUIInputModule>();
    }

    public void SetToBattleMode()
    {
        GetComponent<PlayerInput>().uiInputModule = null;
    }

}
