using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleTracker : MonoBehaviour
{
    [SerializeField] private Shuttle _shuttle;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_shuttle.transform.position.x - _xOffset, 
            transform.position.y, transform.position.z);   
    }
}
