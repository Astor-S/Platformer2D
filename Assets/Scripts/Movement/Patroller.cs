using UnityEngine;

public class Patroller : MonoBehaviour
{
    private const float MinDistanceThreshold = 0.1f;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform[] _positions;

    private int _startPosition = 0;
    private int _currentPosition = 0;
    
    public Vector2 GetCurrentPoint()
    {
        if ((transform.position - _positions[_currentPosition].position).sqrMagnitude < MinDistanceThreshold * MinDistanceThreshold)
            _currentPosition = _startPosition++ % _positions.Length;
        
        return _positions[_currentPosition].position;
    }

    public void StopPatrol(bool isPatrolling) {}
}