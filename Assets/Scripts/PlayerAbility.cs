using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public Ability currentAbility;
    private GameObject selectionUI;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance().ResetRoom();
    }

    public void SetSelectionUI(GameObject ui)
    {
        selectionUI = ui;
    }

    public void ReActiveSelectionUI()
    {
        selectionUI.SetActive(true);
    }

    public void DisableUI()
    {
        selectionUI.SetActive(false);

    }

    public void SetAbility(GameObject abilityPrefab)
    {
        if (currentAbility != null)
            Destroy(currentAbility.gameObject);
        if (abilityPrefab != null)
        {
            GameObject abilityObj = Instantiate(abilityPrefab, transform);
            currentAbility = abilityObj.GetComponent<Ability>();
        }

        
        selectionUI.SetActive(false);
        GameManager.Instance().ReadUP();
    }

    public void OnAction(InputAction.CallbackContext secondContext)
    {
        //Debug.Log("onMenu = " + onMenu);
        //if (onMenu == false)
        //{
        //    Debug.Log("use ability");
        //    currentAbility.Use();
        //}
        if (currentAbility != null)
        {
            currentAbility.Activate();
            //Debug.Log("activating ability!");
        }
    }
}
