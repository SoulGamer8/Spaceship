using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void  Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
   
    }

    protected void Initialize(GameObject[] prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefab.Length);
            
            GameObject spawned = Instantiate(prefab[randomIndex], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        int randomIndex = Random.Range(0, _pool.Capacity);
        result = _pool[randomIndex];

        return result != null;
    }
}