using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tempTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        GetComponent<TMP_Text>().text = "3";
        yield return new WaitForSeconds(0.5f);
        GetComponent<TMP_Text>().text = "2";
        yield return new WaitForSeconds(0.5f);
        GetComponent<TMP_Text>().text = "1";
        yield return new WaitForSeconds(0.5f);
        GetComponent<TMP_Text>().text = "FIGHT";
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<AudioSource>().Play();
        GameObject.Find("TitleScreen").SetActive(false);
        GameManager.Instance().BeginRound();
    }
}
