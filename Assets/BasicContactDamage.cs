using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicContactDamage : MonoBehaviour
{

    public GameObject _particleSystemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-2);
            CameraShake.Instance.ShakeCamera(1.5f, 1f);
            GameObject blood = Instantiate(_particleSystemPrefab, transform.position, Quaternion.identity);
            blood.GetComponent<ParticleSystem>().Play();

        }
    }
}
