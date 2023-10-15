using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooter : Pool
{
    [SerializeField] private BlueLazer _prefab;

    private void Start()
    {
        Initialize(_prefab.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (TryGetObstacle(out GameObject lazer))
            {
                lazer.gameObject.SetActive(true);
                lazer.transform.position = transform.position;
                lazer.transform.localRotation = transform.localRotation;
            }

            DisableObstaclesAbroadView(new Vector3(1, 0.5f));
        }
    }
}
