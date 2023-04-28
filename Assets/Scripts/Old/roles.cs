using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
public class roles : MonoBehaviour
{
    private static bool characterSpawned = false; // determines if this is the first or second character in awake
    [HideInInspector]
    public bool role = false; // false if saw, true if character
    [HideInInspector]
    public bool direction = false; // first player goes right (true), second player goes left (false)
    public GameObject sawGraphics;
    public GameObject characterGraphics;
    private movement moveScript;
    // for switching ability select UI on role switch!
    private MultiplayerEventSystem thisEventSystem;
    private GameObject charAbilitiesParent;
    private GameObject sawAbilitiesParent;
    private BackgroundUIAnims playerImageUI;

    private void Awake()
    {
        moveScript = GetComponent<movement>();
        playerImageUI = GameObject.Find("BackgroundCanvas").GetComponent<BackgroundUIAnims>();
        transform.position = new Vector3(Random.Range(-3, 3f), Random.Range(-3f, 3f), transform.position.z);
        abilityManager.onMenu = true;
        if (!characterSpawned) // p1
        {
            direction = true;
            moveScript.speed = 50f;
            role = true;
            gameObject.tag = "Character";
            gameObject.layer = 13;
            GetComponent<CircleCollider2D>().radius = 0.5f;
            characterGraphics.SetActive(true);
            sawGraphics.SetActive(false);
            thisEventSystem = GameObject.Find("P1EventSystem").GetComponent<MultiplayerEventSystem>();
            Transform UISelection = GameObject.Find("P1SelectionUI").transform; // setting up multiple ability uis
            charAbilitiesParent = UISelection.Find("CharAbilities").gameObject;
            sawAbilitiesParent = UISelection.Find("SawAbilities").gameObject;
            // references for ability select buttons in UI
            foreach (GameObject button in GameObject.FindGameObjectsWithTag("P1UI"))
                //button.GetComponent<abilitySelect>().player = gameObject.GetComponent<abilityManager>();
            sawAbilitiesParent.SetActive(false);
            // setting active interactable UI to char abilities
            thisEventSystem.playerRoot = charAbilitiesParent;
            thisEventSystem.firstSelectedGameObject = charAbilitiesParent.transform.GetChild(0).gameObject;
            thisEventSystem.SetSelectedGameObject(thisEventSystem.firstSelectedGameObject);
            characterSpawned = true;
        }
        else // p2
        {
            // other references already set by default
            thisEventSystem = GameObject.Find("P2EventSystem").GetComponent<MultiplayerEventSystem>();
            GetComponent<abilityManager>().player = true; // set player to p2, default is p1
            Transform UISelection = GameObject.Find("P2SelectionUI").transform; // setting up multiple ability uis
            charAbilitiesParent = UISelection.Find("CharAbilities").gameObject;
            sawAbilitiesParent = UISelection.Find("SawAbilities").gameObject;
            // references for ability select buttons in UI
            foreach (GameObject button in GameObject.FindGameObjectsWithTag("P2UI"))
                //button.GetComponent<abilitySelect>().player = gameObject.GetComponent<abilityManager>();
            charAbilitiesParent.SetActive(false);
            // setting interactable UI to saw abilities
            thisEventSystem.playerRoot = sawAbilitiesParent;
            thisEventSystem.firstSelectedGameObject = sawAbilitiesParent.transform.GetChild(0).gameObject;
            thisEventSystem.SetSelectedGameObject(thisEventSystem.firstSelectedGameObject);
        }
        GetComponent<PlayerInput>().uiInputModule = thisEventSystem.gameObject.GetComponent<InputSystemUIInputModule>();
    }

    public void roleSwitch()
    {
        if (role) // turn into saw
        {
            moveScript.speed = 48f;
            sawGraphics.SetActive(true);
            characterGraphics.SetActive(false);
            gameObject.tag = "Saw";
            gameObject.layer = 8;
            GetComponent<CircleCollider2D>().radius = 0.69f;
            thisEventSystem.playerRoot = sawAbilitiesParent;
            thisEventSystem.firstSelectedGameObject = sawAbilitiesParent.transform.GetChild(0).gameObject;
            thisEventSystem.SetSelectedGameObject(thisEventSystem.firstSelectedGameObject);
            sawAbilitiesParent.SetActive(true);
            charAbilitiesParent.SetActive(false);
            playerImageUI.Switch(); // only in saw so it won't be called twice
            role = false;
        }
        else // or turn into character
        {
            moveScript.speed = 50f;
            characterGraphics.SetActive(true);
            sawGraphics.SetActive(false);
            gameObject.tag = "Character";
            gameObject.layer = 13;
            GetComponent<CircleCollider2D>().radius = 0.5f;
            thisEventSystem.playerRoot = charAbilitiesParent;
            thisEventSystem.firstSelectedGameObject = charAbilitiesParent.transform.GetChild(0).gameObject;
            thisEventSystem.SetSelectedGameObject(thisEventSystem.firstSelectedGameObject);
            sawAbilitiesParent.SetActive(false);
            charAbilitiesParent.SetActive(true);
            role = true;
        }
    }
}
