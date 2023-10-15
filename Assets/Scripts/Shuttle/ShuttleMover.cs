using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShuttleMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private Camera _tracker;
    
    private Vector3 _startPosition;
    private Rigidbody2D _rigidBody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _startPosition = new Vector3(0, 0, 0);  
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetShuttle();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody2D.velocity = new Vector2(_speed, 0);
            _rigidBody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            transform.rotation = _maxRotation; 
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetShuttle()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0,0,0);
        _rigidBody2D.velocity = Vector2.zero;
        _tracker.transform.position = new Vector3(0, 0, -1);
    }
}
