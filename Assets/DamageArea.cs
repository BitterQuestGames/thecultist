using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{

    public GameObject _particleSystemPrefab;
    AudioSource audio;
    public AudioClip swordHit;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            //Debug.Log("Test Before Damage" + collision.GetComponent<EnemyController>().healthPoints);
            collision.GetComponent<EnemyController>().TakeDamage(1);
            //Debug.Log("Test After Damage" + collision.GetComponent<EnemyController>().healthPoints);
            CameraShake.Instance.ShakeCamera(1.5f, 1.5f);
            GameObject blood = Instantiate(_particleSystemPrefab, transform.position, Quaternion.identity);
            blood.GetComponent<ParticleSystem>().Play();
            audio.PlayOneShot(swordHit, .75f);


        }
    }
}
