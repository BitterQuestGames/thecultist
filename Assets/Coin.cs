using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private int collectedValue;
    AudioSource audio;
    public AudioClip clip;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerController>();
            if(player != null)
            {
                audio.PlayOneShot(clip);

                player.PickUpCoins(collectedValue);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;

                //Destroy(this.gameObject);

                StartCoroutine(DestroyObject());
            }
        }
    }


    public void SetCollectedValue(int newCollectedValue)
    {
        collectedValue = newCollectedValue;
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
