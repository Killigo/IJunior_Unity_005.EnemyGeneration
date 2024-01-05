using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _delay = 10f;

    private void Start()
    {
        Destroy(gameObject, _delay);
    }
}