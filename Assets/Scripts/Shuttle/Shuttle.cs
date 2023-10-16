using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ShuttleMover))]
public class Shuttle : MonoBehaviour
{
    private ShuttleMover _shuttleMover;
    private float _invokeTime;

    public event UnityAction GameOver;

    private void Start()
    {
        _invokeTime = 0.3f;
        _shuttleMover = GetComponent<ShuttleMover>();
    }

    private void InvokeDie()
    {
        GameOver?.Invoke();
    }

    public void ResetPlayer()
    {
        _shuttleMover.ResetShuttle();
    }

    public void Die()
    {
        Invoke(nameof(InvokeDie), _invokeTime);
    }
}
