using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class abilityManager : MonoBehaviour
{
    [HideInInspector]
    public bool player = false; // false = first player, true = second player
    private ability currentAbility;
    private GameObject abilityObj;
    [HideInInspector]
    public static bool onMenu = false;
    private eventsManager eventManager;

    private void Awake()
    {
        eventManager = GameObject.Find("_EVENTSMANAGER").GetComponent<eventsManager>();
    }
    public void OnAction(InputAction.CallbackContext secondContext)
    {
        Debug.Log("onMenu = " + onMenu);
        if (onMenu == false)
        {
            Debug.Log("use ability");
            currentAbility.Use();
        }
    }
    public void SetAbility(GameObject abilityPrefab)
    {
        Destroy(abilityObj);
        abilityObj = Instantiate(abilityPrefab.gameObject, gameObject.transform);
        currentAbility = abilityObj.GetComponent<ability>();
        if (player == false)
            eventManager.P1Ready = true;
        else
            eventManager.P2Ready = true;
    }
}
