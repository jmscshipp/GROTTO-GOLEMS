using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public Ability currentAbility;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            currentAbility.Activate();
    }

    //public void OnAction(InputAction.CallbackContext secondContext)
    //{
    //    Debug.Log("onMenu = " + onMenu);
    //    if (onMenu == false)
    //    {
    //        Debug.Log("use ability");
    //        currentAbility.Use();
    //    }
    //}
}
