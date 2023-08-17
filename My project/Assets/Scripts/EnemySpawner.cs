using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _enemyTargetPosition;

    [SerializeField] private float _spawnTime;
    private float _currentTime;

    private Vector3[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>().Select(child => child.position).ToArray();
    }

    private void Update()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
        }
        else
        {
            Spawn();
            _currentTime = _spawnTime;
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)], Quaternion.identity);
        enemy.Init(_enemyTargetPosition);
    }
}
