using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : ObjectPool
{
   [SerializeField] private GameObject[] _enemyTemplate;
   [SerializeField] private Transform[] _spawnPoints;
   [SerializeField] private float _secondsBetweenSpawn;

   private float _elapsedTime=0;

   private void Start()
   {
      for (int i = 0; i < _enemyTemplate.Length; i++)
      {
         Initialize(_enemyTemplate[i]);
      }
      
   }

   private void Update()
   {
      _elapsedTime += Time.deltaTime;

      if (_elapsedTime>=_secondsBetweenSpawn)
      {
         if (TryGetObject(out GameObject enemy))
         {
            _elapsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
         
            SetEnemy(enemy,_spawnPoints[spawnPointNumber].position);
         }
        
      }
   }

   private void SetEnemy(GameObject enemy,Vector3 spawnPoint)
   {
      enemy.SetActive(true);
      enemy.transform.position = spawnPoint;
   }
}
