using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventsManager : MonoBehaviour
{
    private bool levelInProgress = false;
    public GameObject selectionUI;
    [HideInInspector]
    public bool P1Ready = false;
    [HideInInspector]
    public bool P2Ready = false;

    private void Update()
    {
        if (levelInProgress == false && (P1Ready && P2Ready))
        {
            BeginLevel();
            levelInProgress = true;
        }
    }

    public void BeforeLevel()
    {

        selectionUI.SetActive(true);
        levelInProgress = false;
    }

    public void BeginLevel() // when both players have selected an ability
    {
        P1Ready = false;
        P2Ready = false;
        selectionUI.SetActive(false);
        abilityManager.onMenu = false;
        GameObject.Find("revealer").GetComponent<revealer>().StartShrink();
    }
}
