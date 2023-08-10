using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int storedKeys;
    public TextMeshProUGUI keysUI;

    AudioSource audio;
    public AudioClip clip;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Keys"))
        {
            storedKeys = PlayerPrefs.GetInt("Keys");
        }
            


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            audio.PlayOneShot(clip, 1f);
            PlayerPrefs.SetInt("Keys", storedKeys++);
            //PlayerPrefs.SetInt("Coins", 0);
            Debug.Log("Trigger Keys: " + storedKeys);
            keysUI.SetText("Keys" + storedKeys);

            PlayerPrefs.Save();
            StartCoroutine(DestroyObject());
           
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


