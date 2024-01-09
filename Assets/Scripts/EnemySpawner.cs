using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _point;
    [SerializeField] private Vector3 _target = new Vector3(15, 0, 15);

    private Transform[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new Transform[_point.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = _point.GetChild(i);
        }
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var waitFewSeconds = new WaitForSeconds(_spawnTime);

        for (int i = 1; i < 10; i++)
        {
            var randomPoint = Random.Range(1, _spawnPoints.Length);
            var randomAngle = Random.Range(0, 360);

            var enemy = Instantiate(_enemyPrefab, _spawnPoints[randomPoint].transform.position, Quaternion.identity);

            enemy.Move(_target);

            yield return waitFewSeconds;
        }
    }
}
