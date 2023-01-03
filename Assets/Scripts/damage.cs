using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public GameObject deathParticlesPrefab;
    public GameObject collisionImpact;
    private bool canCollide = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Saw" && collision.gameObject.tag == "Character" && canCollide)
        {
            // put in cooler switch effect here      
            StartCoroutine(Impact(collision.GetContact(0).point, collision.gameObject));
            canCollide = false;
        }
        else if (gameObject.tag == "Character" && collision.gameObject.tag == "Saw" && canCollide)
            StartCoroutine(CharImpact());
        
    }

    private IEnumerator Impact(Vector2 impactLocation, GameObject player) // called by enemy
    {
        GameObject impact = Instantiate(collisionImpact, impactLocation, Quaternion.identity);
        Time.timeScale = 0.001f;
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 1f;
        StartCoroutine(ScreenShake());
        Destroy(impact);
        Vector3 dir = -(transform.position - player.transform.position).normalized;
        player.GetComponent<Rigidbody2D>().AddForce(dir * 10000f);
        abilityManager.onMenu = true; // prevents players from moving
        GameObject.Find("revealer").GetComponent<revealer>().StopShrink();
        yield return new WaitForSeconds(2f);
        Camera.main.GetComponent<cameraMovement>().ResetRoom(false); // RESET
    }

    private IEnumerator CharImpact() // called by player for same impact
    {
        SpriteRenderer charRenderer = transform.Find("charGraphics").Find("charWhites").GetComponent<SpriteRenderer>();
        charRenderer.enabled = true;
        yield return new WaitForSecondsRealtime(0.3f);
        charRenderer.enabled = false;
        GameObject deathparticles = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity, gameObject.transform);
        yield return new WaitForSeconds(2f);
        Destroy(deathparticles);
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


    private void OnCollisionExit2D(Collision2D collision)
    {
        canCollide = true;
    }
}
