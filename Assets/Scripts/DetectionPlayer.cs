using UnityEngine;

public class DetectionPlayer : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 1.5f;
    private bool _isPlayerDetected = false;
    private Transform _playerTransform;
    private LayerMask _playerLayerMask;

    public Transform PlayerTransform => _playerTransform;
    public bool IsPlayerDetected => _isPlayerDetected;

    private void Start()
    {
        _playerLayerMask = LayerMask.GetMask("Player");
    }

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
        }
    }
}