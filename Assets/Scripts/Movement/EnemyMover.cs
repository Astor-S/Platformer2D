using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(Patroller))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private PlayerDetector _playerDetection;
    private Patroller _patrolling;
    private Quaternion _rightRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion _leftRotation = Quaternion.identity;

    private void Awake()
    {
        _playerDetection = GetComponent<PlayerDetector>();
        _patrolling = GetComponent<Patroller>();
    }

    public void Move()
    {
        Vector2 targetPoint;

        if (_playerDetection.IsPlayerDetected)
        {
            _patrolling.StopPatrol();
            targetPoint = _playerDetection.PlayerTransform.position;
            Flip(_playerDetection.PlayerTransform.position);
        }
        else
        {
            targetPoint = _patrolling.GetCurrentPoint();
            Flip(targetPoint);
        }
       
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, _speed * Time.deltaTime);
    }

    private void Flip(Vector2 target)
    {
        if (transform.position.x < target.x)
            transform.rotation = _rightRotation;
        else
            transform.rotation = _leftRotation;
    }
}