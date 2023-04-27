using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform leftSpawnPos, rightSpawnPos;
    public Room leftRoom, rightRoom;
    //private GameObject playerLeft, playerRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Room GetRightRoom()
    {
        return rightRoom;
    }

    public Room GetLeftRoom()
    {
        return leftRoom;
    }

    public void ResetRoom()
    {
        // reset player positions
        GameObject hider = GameObject.FindGameObjectWithTag("Hider");
        PlacePlayer(hider, hider.GetComponent<PlayerRoleController>().GetGoalDirection());

        GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");
        PlacePlayer(seeker, seeker.GetComponent<PlayerRoleController>().GetGoalDirection());
    }

    private void PlacePlayer(GameObject player, PlayerRoleController.Direction goalDir)
    {
        if (goalDir == PlayerRoleController.Direction.Left)
        {
            player.transform.position = rightSpawnPos.position;
        }
        else
        {
            player.transform.position = leftSpawnPos.position;

        }
    }
}
