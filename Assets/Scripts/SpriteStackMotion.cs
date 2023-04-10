using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// thanks to LiterallyJeff for this one!
// https://forum.unity.com/threads/gameobject-follow-parent-rotation-with-delay.483369/

public class SpriteStackMotion : MonoBehaviour
{
    public float delay;
    public float moveSpeed;

    private Vector3 targetPos;
    private Vector3 pendingTargetPos;
    private Vector3 lastPos;

    private IEnumerator SetTargetPosition(Vector3 pos)
    {
        pendingTargetPos = pos;
        yield return new WaitForSeconds(delay);
        targetPos = pendingTargetPos;
    }

    private void LateUpdate()
    {
        // overwrite any changes due to external pos
        //transform.position = lastPos;

        // move towards the target pos
        transform.position = Vector2.Lerp(lastPos, targetPos, moveSpeed * Time.deltaTime);

        // store new current pos for next frame
        lastPos = transform.position;

        // if the parent has a new pos, set it as the new target pos
        if (transform.parent.localPosition != targetPos && transform.parent.localPosition != pendingTargetPos)
        {
            StartCoroutine(SetTargetPosition(transform.parent.localPosition));
        }
    }
}
