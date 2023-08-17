using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    public void Init(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
