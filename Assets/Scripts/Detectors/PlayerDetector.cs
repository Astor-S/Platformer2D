using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private float _detectionRadius = 1.5f;
    private Transform _playerTransform;
    private bool _isPlayerDetected = false;
    
    public Transform PlayerTransform => _playerTransform;
    public bool IsPlayerDetected => _isPlayerDetected;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _detectionRadius, Vector2.up, 0f, _playerLayerMask);

        if (hit.collider != null)
        {
            _playerTransform = hit.transform;
            _isPlayerDetected = true;
        }
        else
        {
            _isPlayerDetected = false;
            _playerTransform = null;
        }
    }
}