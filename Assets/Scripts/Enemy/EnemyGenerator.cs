using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : Pool
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private EnemyShooter _shooter;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private bool _isPlayed;

    private void OnEnable()
    {
        StartCoroutine(EnemyGenerating());
    }

    private void OnDisable()
    {
        StopCoroutine(EnemyGenerating());
    }

    private void Awake()
    {
        _isPlayed = true;
        Initialize(_prefab.gameObject);
    }

    private IEnumerator EnemyGenerating()
    {
        var waitingTime = new WaitForSeconds(_secondsBetweenSpawn);

        while (_isPlayed)
        {
            if(TryGetObstacle(out GameObject obstacle))
            {
                float spawnPosition = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPosition, 0);
                obstacle.gameObject.SetActive(true);
                obstacle.transform.position = spawnPoint;
                yield return waitingTime;
            }

            DisableObstaclesAbroadView();
        }

        _shooter.EndShooting();
    }

    public void EndGenerate()
    {
        _isPlayed = false;
    }
}
