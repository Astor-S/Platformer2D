using UnityEngine;

public class Patroller : MonoBehaviour
{
    private const float MinDistanceThreshold = 0.1f;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform[] _positions;

    private int _startPosition = 0;
    private int _currentPosition = 0;
    
    private bool _isPatrolling = true;

    public Vector2 GetCurrentPoint()
    {
        if (Vector2.Distance(transform.position, _positions[_currentPosition].position) < MinDistanceThreshold)
        {

            if (_currentPosition < _positions.Length - 1)
                _currentPosition++;
            else
                _currentPosition = _startPosition;
        }

        return _positions[_currentPosition].position;
    }

    public void StopPatrol()
    {
        _isPatrolling = false;
    }

    public void ResumePatrol()
    {
        _isPatrolling = true;
    }
}