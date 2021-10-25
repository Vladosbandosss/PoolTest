using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] GameObject sphereprefab;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int poolSize = 10;
    List<GameObject> pool;
    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        pool = new List<GameObject>();
        
        for (int i = 0; i <poolSize; i++)
        {
            pool.Add(sphereprefab);
            pool[i] = Instantiate(sphereprefab, transform.position,Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            CreateObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void CreateObjectInPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                pool[i].transform.position = new Vector3(0, 3f, 0f);
                return;
            }
        }
    }


}
