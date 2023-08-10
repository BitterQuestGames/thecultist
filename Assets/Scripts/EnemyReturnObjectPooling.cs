using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReturnObjectPooling : MonoBehaviour
{
    private EnemyObjectPooling objectPool;

    private void Start()
    {
        objectPool = FindObjectOfType<EnemyObjectPooling>();
    }

    private void OnDisable()
    {
        if (objectPool != null)
            objectPool.ReturnGameObject(this.gameObject);
    }
}