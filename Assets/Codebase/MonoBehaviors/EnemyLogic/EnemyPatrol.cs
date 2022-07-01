using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    [Space]

    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private Transform _transform;

    private Transform _currentPoint;

    private void Update()
    {
        UpdatePoint();
    }

    private void OnValidate()
    {
        if (_navMesh == null)
        {
            _navMesh = GetComponent<NavMeshAgent>();
        }

        if (_transform == null)
        {
            _transform = transform;
        }
    }

    private void UpdatePoint()
    {
        if (_navMesh.transform.position == _navMesh.pathEndPosition)
        {
            SetRandomPoint();
        }

        _navMesh.SetDestination(_currentPoint.position);
    }

    private void SetRandomPoint()
    {
        _currentPoint = _points[Random.Range(0, _points.Length)];
    }
}
