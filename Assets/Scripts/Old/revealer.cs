using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealer : MonoBehaviour
{
    public Material effectForeground;
    public Material effectBackground;
    public GameObject enemDeathParticles;
    private cameraMovement cam;
    private Vector3 originalSettings;
    private bool shrink = false;
    private bool charDirection = false;
    private static float decreaseAmount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        effectForeground.SetFloat("Vector1_2F71339F", 10);
        effectBackground.SetFloat("Vector1_2F71339F", 11);
        cam = Camera.main.GetComponent<cameraMovement>();
        charDirection = transform.parent.parent.GetComponent<roles>().direction;
        originalSettings = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (shrink)
        {
            decreaseAmount += Time.deltaTime / 15f;
            transform.localScale = Vector3.one * -Mathf.Log(decreaseAmount);

            if (transform.localScale.x <= 0.6f)
            {
                effectForeground.SetFloat("Vector1_2F71339F", 100);
                effectBackground.SetFloat("Vector1_2F71339F", 110);
            }
            if (transform.localScale.x <= 0.2f)
            {
                StartCoroutine(Death());
                effectForeground.SetFloat("Vector1_2F71339F", 10);
                effectBackground.SetFloat("Vector1_2F71339F", 11);
                decreaseAmount = 0f;
                shrink = false;
            }
        }
    }

    public void StartShrink() // to be called from room or some other object when gameplay for next room starts
    {
        transform.localScale = originalSettings;
        shrink = true;
    }

    public void StopShrink()
    {
        shrink = false;
        decreaseAmount = 0f;
        effectForeground.SetFloat("Vector1_2F71339F", 10);
        effectBackground.SetFloat("Vector1_2F71339F", 11);
    }

    private IEnumerator Death()
    {
        StopShrink();
        StartCoroutine(ScreenShake());
        abilityManager.onMenu = true;
        GameObject particles = Instantiate(enemDeathParticles, transform.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(2f);
        Destroy(particles);
        cam.Move(charDirection);
    }

    private IEnumerator ScreenShake()
    {
        Vector3 camPos = Camera.main.transform.position;
        for (int i = 0; i < 5; i++)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + Random.insideUnitCircle.x * 0.1f, Camera.main.transform.position.y + Random.insideUnitCircle.y * 0.1f, camPos.z);
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position = camPos;
        }
    }
}
