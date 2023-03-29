using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapNode : MonoBehaviour
{
    public float power = 0f; // should go from 0 to 80 in the most extreme case
    private float moveTime = 0f;
    private Vector2 pos;

    // Start is called before the first frame update
    void Awake()
    {
        pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        moveTime += Time.deltaTime;
        pos.x = Mathf.Sin(moveTime + power/20f) * power;
        transform.localPosition = pos;
    }

    public void ResetPos()
    {
        transform.localPosition = new Vector2(0f, pos.y);
    }
}
