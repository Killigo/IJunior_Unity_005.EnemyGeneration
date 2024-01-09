using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _delay = 10f;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        Destroy(gameObject, _delay);
    }

    private void Update()
    {
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Move(Vector3 target)
    {
        _target = target;
    }
}