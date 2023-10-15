using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shuttle))]
public class ShuttleCollisionHandler : MonoBehaviour
{
    [SerializeField] private Animator _cameraAnimator;

    private Shuttle _shuttle;

    private void Start()
    {
        _shuttle = GetComponent<Shuttle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out BlueLazer Laser))
        {
            _cameraAnimator.SetTrigger("Crashed");
            _shuttle.Die();
        }
    }
}
