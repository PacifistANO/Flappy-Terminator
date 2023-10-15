using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Pool
{
    [SerializeField] private RedLazer _lazer;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeBeforeShoot;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_lazer.gameObject);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBeforeShoot)
        {
            if (TryGetObstacle(out GameObject obstacle))
            {
                _elapsedTime = 0;

                obstacle.gameObject.SetActive(true);
                obstacle.transform.position = transform.position;
            }
        }

        DisableObstaclesAbroadView();
    }

}
