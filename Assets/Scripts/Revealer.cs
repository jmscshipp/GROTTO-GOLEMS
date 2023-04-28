using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revealer : MonoBehaviour
{
    private Vector3 startScale;
    public bool shrinking;
    private float shrinkAmount;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        startScale = transform.localScale;
        shrinkAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shrinking)
        {
            //Debug.Log("shrink amount: " + shrinkAmount);
            shrinkAmount += Time.deltaTime / 15f;
            transform.localScale = Vector3.one * -Mathf.Log(shrinkAmount);

            if (transform.localScale.x <= 0.2f)
            {
                StartCoroutine(Death());
                shrinkAmount = 0.0f;
                shrinking = false;
            }
        }

    }

    public void StartShrink()
    {
        Debug.Log("starting shrink");

        shrinkAmount = 0.0f;
        transform.localScale = startScale;
        shrinking = true;
    }

    public void StopShrink()
    {
        shrinking = false;
    }

    //public void ResetRevealer()
    //{
    //    shrinkAmount = 0.0f;
    //    transform.localScale = startScale;
    //}

    private IEnumerator Death()
    {
        Debug.Log("revealer killed seeker");
        yield return new WaitForSeconds(0.0f);
        GameManager.Instance().NextRoom();
    }
}
