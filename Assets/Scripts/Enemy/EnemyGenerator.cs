using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : Pool
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_prefab.gameObject);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _secondsBetweenSpawn)
        {
            if(TryGetObstacle(out GameObject obstacle))
            {
                _elapsedTime = 0;

                float spawnPosition = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPosition, 0);
                obstacle.gameObject.SetActive(true);
                obstacle.transform.position = spawnPoint;
            }
        }

        DisableObstaclesAbroadView();
    }
}
