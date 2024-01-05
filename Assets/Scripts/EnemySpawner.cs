using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private Enemy _enemyPrefab;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var waitFewSeconds = new WaitForSeconds(_spawnTime);

        for (int i = 1; i < 10; i++)
        {
            var randomPoint = Random.Range(1, _spawnPoints.Length);
            var randomAngle = Random.Range(0, 360);

            Instantiate(_enemyPrefab, _spawnPoints[randomPoint].transform.position, Quaternion.AngleAxis(randomAngle, Vector3.up));

            yield return waitFewSeconds;
        }
    }
}
