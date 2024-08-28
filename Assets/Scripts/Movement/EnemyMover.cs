using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Fliper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private PlayerDetector _playerDetection;
    private Patroller _patrolling;
    private Fliper _fliper;

    private void Awake()
    {
        _playerDetection = GetComponent<PlayerDetector>();
        _patrolling = GetComponent<Patroller>();
        _fliper = GetComponent<Fliper>();
    }

    public void Move()
    {
        Vector2 targetPoint;

        if (_playerDetection.IsPlayerDetected)
        {
            targetPoint = _playerDetection.PlayerTransform.position;
            _fliper.Flip(_playerDetection.PlayerTransform.position);
        }
        else
        {
            targetPoint = _patrolling.GetCurrentPoint();
            _fliper.Flip(targetPoint);
        }
       
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, _speed * Time.deltaTime);
    }
}