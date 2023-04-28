using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilitySelect : MonoBehaviour
{
    // this script should be on the button that is for each ability!
    [HideInInspector]
    public PlayerAbility player;
    public GameObject abilityPrefab;
    // Start is called before the first frame update
    public void AbilitySelect()
    {
        player.SetAbility(abilityPrefab); // if there's an error from this line it might be because some of the UI was disabled on start, should all be enabled
    }
}
