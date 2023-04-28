using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
public class AbilityUI : MonoBehaviour
{
    public GameObject firstSelectedOption1;
    public GameObject firstSelectedOption2;
    public GameObject playerRootOption1;
    public GameObject playerRootOption2;
    public GameObject characterGraphics1;
    public GameObject characterGraphics2;
    private MultiplayerEventSystem uiSystem;

    private enum Options { One, Two };
    private Options currentOption;

    // Start is called before the first frame update
    void Start()
    {
        uiSystem = GetComponent<MultiplayerEventSystem>();
        uiSystem.firstSelectedGameObject = firstSelectedOption1;
        uiSystem.playerRoot = playerRootOption1;
        characterGraphics2.SetActive(false);
        currentOption = Options.One;
        playerRootOption2.SetActive(false);
    }
    
    public void AssignPlayerToButtons(PlayerAbility thisPlayer)
    {
        foreach (abilitySelect abilityButton in playerRootOption1.GetComponentsInChildren<abilitySelect>())
            abilityButton.player = thisPlayer;
        foreach (abilitySelect abilityButton in playerRootOption2.GetComponentsInChildren<abilitySelect>())
            abilityButton.player = thisPlayer;
    }

    public void SwapOptions()
    {
        if (currentOption == Options.One)
        {
            playerRootOption1.SetActive(false);
            playerRootOption2.SetActive(true);
            uiSystem.firstSelectedGameObject = firstSelectedOption2;
            uiSystem.playerRoot = playerRootOption2;
            characterGraphics1.SetActive(false);
            characterGraphics2.SetActive(true);
            uiSystem.SetSelectedGameObject(uiSystem.firstSelectedGameObject);
            currentOption = Options.Two;
        }
        else if (currentOption == Options.Two)
        {
            playerRootOption1.SetActive(true);
            playerRootOption2.SetActive(false);
            uiSystem.firstSelectedGameObject = firstSelectedOption1;
            uiSystem.playerRoot = playerRootOption1;
            characterGraphics1.SetActive(true);
            characterGraphics2.SetActive(false);
            uiSystem.SetSelectedGameObject(uiSystem.firstSelectedGameObject);
            currentOption = Options.One;
        }
    }
}
