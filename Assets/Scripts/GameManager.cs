using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Room currentRoom;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginRoom()
    {

    }

    public void NextRoom(PlayerRoleController.Direction dir)
    {

    }

    public void SwitchRoles()
    {
        Debug.Log("swith roles being called'");
        GameObject hider = GameObject.FindGameObjectWithTag("Hider");
        GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");

        hider.GetComponent<PlayerRoleController>().SwitchRole();
        seeker.GetComponent<PlayerRoleController>().SwitchRole();

        currentRoom.ResetRoom();
    }
}
