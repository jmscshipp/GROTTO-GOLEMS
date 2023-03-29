using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public mapNode[] nodes = new mapNode[9];
    private mapNode centralNode;
    private int centralNodeNum = 4;
    private LineRenderer mapSpine;
    public mapSelector selector;

    private bool swap = false;
    private float mapSavedRot;
    private float nodeSavedRot;
    private float swapCounter = 0f;

    private void Start()
    {
        mapSpine = GetComponent<LineRenderer>();
        centralNode = nodes[4];
        SetNodes();
    }

    private void Update()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            mapSpine.SetPosition(i, nodes[i].transform.position);
        }
        if (swap)
        {
            swapCounter += Time.deltaTime; // NEEDS MORE TWEAKING
            float mapRot = Mathf.Lerp(mapSavedRot, mapSavedRot - 180f, swapCounter);
            transform.localRotation = Quaternion.Euler(0f, 0f, mapRot);
            foreach(mapNode node in nodes)
            {
                float nodeRot = Mathf.Lerp(nodeSavedRot, nodeSavedRot + 180f, swapCounter);
                node.transform.localRotation = Quaternion.Euler(0f, 0f, nodeRot);
            }
            if (swapCounter >= 1f)
            {
                SetNodes();
                swap = false;
            }
        }
    }

    public void Swap() // rotates map when roles switch
    {
        FreezeNodes();
        swapCounter = 0f;
        mapSavedRot = transform.localRotation.z;
        nodeSavedRot = nodes[0].transform.localRotation.z;
        swap = true;
        Debug.Log(mapSavedRot);
    }

    private void FreezeNodes()
    {
        foreach (mapNode node in nodes)
        {
            node.ResetPos();
            node.power = 0f;
        }
    }
    
    public void Move(bool direction) // left = false, right = true
    {
        FreezeNodes();
        StartCoroutine(moveSelector(direction));
    }
    
    private IEnumerator moveSelector(bool direction)
    {
        int newCentralNode;
        if (direction == true)
            newCentralNode = centralNodeNum - 1;
        else
            newCentralNode = centralNodeNum + 1;

        selector.Move(centralNode.transform.localPosition, nodes[newCentralNode].transform.localPosition);
        yield return new WaitForSeconds(1.2f);
        centralNodeNum = newCentralNode;
        centralNode = nodes[centralNodeNum];
        SetNodes();
    }

    private Vector3 GenerateNewPoint()
    {
        return new Vector3(Random.Range(-30f, 30f), Random.Range(-15f, 15f), 0);
    }

    private void SetNodes()
    {
        foreach (mapNode node in nodes)
        {
            int multiplyer = 10;
            if (node.transform.localPosition.y < centralNode.transform.localPosition.y)
                multiplyer *= -1;
            node.power = NodeDistance(node) * multiplyer;
        }
    }

    private int NodeDistance(mapNode node) // calculates distance of this node from central node
    {
        return Mathf.Abs(System.Array.IndexOf(nodes, centralNode) - System.Array.IndexOf(nodes, node));
    }
}
