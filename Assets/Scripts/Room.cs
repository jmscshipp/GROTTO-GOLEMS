using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform leftSpawnPos, rightSpawnPos;
    public Room leftRoom, rightRoom;
    private Vector3 center;
    //private GameObject playerLeft, playerRight;


    // Start is called before the first frame update
    void Start()
    {
        // calculate room's center for camera
        Vector3 avg = Vector3.zero;
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
            avg += child.position;
        center = avg / children.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetCenter()
    {
        return center;
    }

    public Room GetRightRoom()
    {
        return rightRoom;
    }

    public Room GetLeftRoom()
    {
        return leftRoom;
    }

    public void SetupRoom()
    {
        // set player positions
        Debug.Log("placing hider");
        GameObject hider = GameObject.FindGameObjectWithTag("Hider");
        if (hider != null)
            PlacePlayer(hider, hider.GetComponent<PlayerRoleController>().GetGoalDirection());
        Debug.Log("placing seeker");
        GameObject seeker = GameObject.FindGameObjectWithTag("Seeker");
        if (seeker != null)
            PlacePlayer(seeker, seeker.GetComponent<PlayerRoleController>().GetGoalDirection());
    }

    private void PlacePlayer(GameObject player, PlayerRoleController.Direction goalDir)
    {
        if (goalDir == PlayerRoleController.Direction.Left)
        {
            Debug.Log("right");

            player.transform.position = rightSpawnPos.position;
        }
        else
        {
            Debug.Log("left");

            player.transform.position = leftSpawnPos.position;
        }
    }
}
