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
            //eventsystem.GetComponent<InputSystemUIInputModule>().actionsAsset = GetComponent<PlayerInput>().actions;
            GetComponent<PlayerAbility>().SetSelectionUI(GameObject.Find("P2SelectionUI"));
            //GetComponent<PlayerAbility>().SetAbility(null);
            GameObject.Find("P2Join").GetComponent<tempShowGraphics>().ShowGraphics();
            GameObject.Find("TimerText").GetComponent<tempTimer>().Begin();
            GetComponent<PlayerAbility>().DisableUI();
            SetToBattleMode();
            //GameManager.Instance().BeginRound();
        }
        else
        {
            SetToSeeker();
            goalDirection = Direction.Left;
            gameObject.tag = "Seeker";
            // HARD CODING. BAd
            eventsystem = GameObject.Find("P1EventSystem");
            //GetComponent<PlayerInput>().uiInputModule = eventsystem.GetComponent<InputSystemUIInputModule>();
            eventsystem.GetComponent<AbilityUI>().AssignPlayerToButtons(GetComponent<PlayerAbility>());
            //eventsystem.GetComponent<InputSystemUIInputModule>().actionsAsset = GetComponent<PlayerInput>().actions;
            GetComponent<PlayerAbility>().SetSelectionUI(GameObject.Find("P1SelectionUI"));
            //GetComponent<PlayerAbility>().SetAbility(null);
            GameObject.Find("P1Join").GetComponent<tempShowGraphics>().ShowGraphics();

            GetComponent<PlayerAbility>().DisableUI();
            SetToBattleMode();
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchRole()
    {
        Debug.Log("switching role in player role controls");
        if (currentRole == Role.Hider)
        {
            //Debug.Log("was hider");
            SetToSeeker();
        }
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
        //Debug.Log("setting to seeke");
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
        //GetComponent<PlayerInput>().currentActionMap = GetComponent<PlayerInput>().actions.actionMaps[1];
        //GetComponent<PlayerInput>().defaultActionMap = GetComponent<PlayerInput>().actions.actionMaps[1].name;
        //Debug.Log("current action map: " + GetComponent<PlayerInput>().currentActionMap.name);
        //GetComponent<PlayerInput>().uiInputModule = eventsystem.GetComponent<InputSystemUIInputModule>();
    }

    public void SetToBattleMode()
    {
        //GetComponent<PlayerInput>().currentActionMap = GetComponent<PlayerInput>().actions.actionMaps[0];
        //GetComponent<PlayerInput>().defaultActionMap = GetComponent<PlayerInput>().actions.actionMaps[0].name;
        // Debug.Log("current action map: " + GetComponent<PlayerInput>().currentActionMap.name);

        //GetComponent<PlayerInput>().uiInputModule = null;
        GetComponent<CircleCollider2D>().enabled = true;

    }

}
