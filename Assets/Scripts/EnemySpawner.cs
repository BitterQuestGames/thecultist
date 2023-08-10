using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    //private float timeToSpawn = 5f;
    //private float timeSinceSpawn;
    //private EnemyObjectPooling objectPool;
    //[SerializeField]
    //private GameObject prefab;
    //[SerializeField]
    //private GameObject spawnLocation;
    //EnemyController[] enemyType1;
    ////EnemyType2[] enemyType2;
    //public bool hasEnteredThisCollider;
    ////DisableChildForAFewSeconds disable;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    objectPool = FindObjectOfType<EnemyObjectPooling>();
    //    enemyType1 = (EnemyController[])FindObjectsOfType(typeof(EnemyController));
    //    //enemyType2 = (EnemyController[])FindObjectsOfType(typeof(EnemyController));
    //    //disable = GetComponentInParent<DisableChildForAFewSeconds>();





    //}

    //// Update is called once per frame
    //void Update()
    //{



    //    //if (disable.okToSpawn)
    //    //{
    //        GameObject newCritter = objectPool.GetObject(prefab);
    //        newCritter.transform.position = spawnLocation.transform.position;
    //        //timeSinceSpawn = 0f;
    //        hasEnteredThisCollider = false;
    //        //disable.okToSpawn = false;

    //    //}
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (objectPool != null)
    //    {
    //        if (collision.CompareTag("Player"))
    //        {

    //            // Send to Parent COllider as true
    //            hasEnteredThisCollider = true;


    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //hasEnteredThisCollider = false;
    //    }
    //}
}