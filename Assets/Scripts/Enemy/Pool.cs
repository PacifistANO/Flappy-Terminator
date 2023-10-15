using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;

    protected List<GameObject> ItemPool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for(int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.transform.localRotation = _container.transform.localRotation;
            spawned.gameObject.SetActive(false);

            ItemPool.Add(spawned);
        }
    }

    protected void DisableObstaclesAbroadView()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f));

        foreach(GameObject obstacle in ItemPool)
        {
            if(obstacle.gameObject.activeSelf == true)
            {
                if(obstacle.transform.position.x < disablePoint.x)
                    obstacle.gameObject.SetActive(false);
            }
        }
    }

    protected void DisableObstaclesAbroadView(Vector3 point)
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(point);

        foreach (GameObject obstacle in ItemPool)
        {
            if (obstacle.gameObject.activeSelf == true)
            {
                if (obstacle.transform.position.x > disablePoint.x)
                    obstacle.gameObject.SetActive(false);
            }
        }
    }

    protected bool TryGetObstacle(out GameObject result)
    {
        result = ItemPool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
