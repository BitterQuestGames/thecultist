using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    AudioSource audio;
    public AudioClip clip;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();

        if (controller != null)
        {
            if(controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(DestroyObject());

            }
           
        }
    }

    IEnumerator DestroyObject()
    {
        // Will destroy objct after sound has been played.
        audio.PlayOneShot(clip);
        yield return new WaitForSeconds(2);
        //Destroy(gameObject);
        gameObject.SetActive(false);

    }
}
