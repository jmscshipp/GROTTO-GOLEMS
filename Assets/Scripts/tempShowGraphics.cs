using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class tempShowGraphics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGraphics()
    {
        GetComponent<TMP_Text>().enabled = false;
        foreach(Image img in GetComponentsInChildren<Image>())
        {
            img.enabled = true;
        }
    }
}
