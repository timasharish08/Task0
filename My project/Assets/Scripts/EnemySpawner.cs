using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _enemyTargetPosition;

    [SerializeField] private float _spawnTime;
    private float _timer;

    private Vector3[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>().Select(child => child.position).ToArray();
    }

    private void Update()
    {
        if (_timer <= 0)
        {
            Spawn();
            _timer = _spawnTime;
        }

        _timer -= Time.deltaTime;
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)], Quaternion.identity);
        enemy.Init(_enemyTargetPosition);
    }
}
