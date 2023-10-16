using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Pool
{
    [SerializeField] private RedLazer _lazer;
    [SerializeField] private float _timeBeforeShoot;

    private bool _isShooting;

    private void OnEnable()
    {
        StartCoroutine(BulletShooting());
    }

    private void OnDisable()
    {
        StopCoroutine(BulletShooting());
    }

    private void Awake()
    {
        _isShooting = true;
        Initialize(_lazer.gameObject);
        StartCoroutine(BulletShooting());
    }

    private IEnumerator BulletShooting()
    {
        var waitingTime = new WaitForSeconds(_timeBeforeShoot);

        while (_isShooting)
        {
            if (TryGetObstacle(out GameObject obstacle))
            {
                obstacle.gameObject.SetActive(true);
                obstacle.transform.position = transform.position;

                yield return waitingTime;
            }

            DisableObstaclesAbroadView();
        }
    }

    public void EndShooting()
    {
        Debug.Log("EndShooting");
        _isShooting = false;
    }

}
