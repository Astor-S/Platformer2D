using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private const float RotationParameter = 180f;

    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private float _detectionRadius = 1.5f;
    private bool _isPlayerDetected = false;
    private Transform _playerTransform;

    public Transform PlayerTransform => _playerTransform;
    public bool IsPlayerDetected => _isPlayerDetected;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _detectionRadius, Vector2.up, 0f, _playerLayerMask);

        if (hit.collider != null)
        {
            _playerTransform = hit.transform;
            _isPlayerDetected = true;
            Flip();
        }
        else
        {
            _isPlayerDetected = false;
        }
    }

    private void Flip()
    {
        Vector2 direction = _playerTransform.position - transform.position;

        if (direction.x > 0)
            transform.rotation = Quaternion.identity;
        else
            transform.rotation = Quaternion.Euler(0, RotationParameter, 0);
    }
}