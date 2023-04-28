using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Room currentRoom;
    private CameraMovement camMovement;
    private int playersReady;

    // singleton
    private static GameManager instance;
    
    public static GameManager Instance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        camMovement = FindObjectOfType<CameraMovement>();
        camMovement.ArrivedAtGoal.AddListener(ReactivateSelectionUI);
        playersReady = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this is all so messy please come back and fix
    public void ReadUP()
    {
        playersReady++;
        if (playersReady > 1)
        {
            BeginRound();
            playersReady = 0;
        }
    }

    public void ResetRoom()
    {
        currentRoom.SetupRoom();
    }

    public void BeginRound()
    {
        //camMovement.ArrivedAtGoal.RemoveListener(BeginRound);
        currentRoom.SetupRoom();

        GameObject hider = GameObject.FindGameObjectWithTag("Hider");
        GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");

        hider.GetComponent<PlayerMovement>().canMove = true;
        seeker.GetComponent<PlayerMovement>().canMove = true;

        hider.GetComponent<PlayerRoleController>().SetToBattleMode();
        seeker.GetComponent<PlayerRoleController>().SetToBattleMode();

        FindObjectOfType<Revealer>().StartShrink();
    }

    private void ReactivateSelectionUI()
    {
        GameObject hider = GameObject.FindGameObjectWithTag("Hider");
        GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");

        hider.GetComponent<PlayerAbility>().ReActiveSelectionUI();
        seeker.GetComponent<PlayerAbility>().ReActiveSelectionUI();
    }

    // called when hider wins a room
    public void NextRoom()
    {
        // MAKE BETTER

        FindObjectOfType<Revealer>().StopShrink();


        GameObject hider = GameObject.FindGameObjectWithTag("Hider");
        GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");

        hider.GetComponent<PlayerMovement>().canMove = false;
        seeker.GetComponent<PlayerMovement>().canMove = false;

        hider.GetComponent<PlayerRoleController>().SetToUIMode();
        seeker.GetComponent<PlayerRoleController>().SetToUIMode();


        PlayerRoleController.Direction dir = GameObject.FindGameObjectWithTag("Hider").GetComponent<PlayerRoleController>().GetGoalDirection();
        if (dir == PlayerRoleController.Direction.Left)
            currentRoom = currentRoom.GetLeftRoom();
        else if (dir == PlayerRoleController.Direction.Right)
            currentRoom = currentRoom.GetRightRoom();


        // one of the players made it to the end!
        if (currentRoom == null)
        {

        }
        else // go to next room
        {

            camMovement.Move(currentRoom.GetCenter());

        }
    }

    // called when seeker wins a room
    public void SwitchRoles()
    {
        // MAKE BETTER
        GameObject hiderf = GameObject.FindGameObjectWithTag("Hider");
        GameObject seekerf = GameObject.FindGameObjectWithTag("Seeker");

        hiderf.GetComponent<PlayerMovement>().canMove = false;
        seekerf.GetComponent<PlayerMovement>().canMove = false;

        hiderf.GetComponent<PlayerAbility>().ReActiveSelectionUI();
        seekerf.GetComponent<PlayerAbility>().ReActiveSelectionUI();

        hiderf.GetComponent<PlayerRoleController>().SetToUIMode();
        seekerf.GetComponent<PlayerRoleController>().SetToUIMode();


        Debug.Log("swith roles being called'");
        GameObject hider = GameObject.FindGameObjectWithTag("Hider");
        GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");

        hider.GetComponent<PlayerRoleController>().SwitchRole();
        seeker.GetComponent<PlayerRoleController>().SwitchRole();

        // this is bad, fix later
        foreach (AbilityUI ui in FindObjectsOfType<AbilityUI>())
        {
            ui.SwapOptions();
        }
    }
}
