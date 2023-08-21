using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _enemyTargetPosition;
    [SerializeField] private float _spawnTime;

    private Vector3[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>().Select(child => child.position).ToArray();
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        bool isOn = true;

        while (isOn)
        {
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)], Quaternion.identity);
            enemy.Init(_enemyTargetPosition);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
