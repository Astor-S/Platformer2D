using UnityEngine;

public class Patrolling : MonoBehaviour
{
    private const float MinDistanceThreshold = 0.1f;

    [SerializeField] private float _speed = 1f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform[] _positions;

    private int _startPosition = 0;
    private int _currentPosition = 0;

    private void Start()
    {
        _spriteRenderer.flipX = true;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _positions[_currentPosition].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _positions[_currentPosition].position) < MinDistanceThreshold)
        {
            Flip();

            if (_currentPosition < _positions.Length - 1)
                _currentPosition++;
            else
                _currentPosition = _startPosition;
        }
    }

    private void Flip()
    {
        if (_positions[_currentPosition].position.x > transform.position.x)
        {
            _spriteRenderer.flipX = false; 
        }
        else
        {
            _spriteRenderer.flipX = true; 
        }
    }
}