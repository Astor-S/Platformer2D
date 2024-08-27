using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private float _detectionRadius = 1.5f;
 
    public Transform PlayerTransform {get; private set;}
    public bool IsPlayerDetected {get; private set;}

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _detectionRadius, Vector2.up, 0f, _playerLayerMask);

        if (hit.collider != null)
        {
            PlayerTransform = hit.transform;
            IsPlayerDetected = true;
        }
        else
        {
            IsPlayerDetected = false;
            PlayerTransform = null;
        }
    }
}