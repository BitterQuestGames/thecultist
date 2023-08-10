using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRockAttack : MonoBehaviour
{
    // enemy SPECIAL ABILITY sample
    //Drop rock from above at players x/y position
    public GameObject ceilingRockPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(ceilingRockPrefab, new Vector3(collision.transform.position.x, collision.transform.position.y + 10, collision.transform.position.z), gameObject.transform.rotation);

        }
    }
}
