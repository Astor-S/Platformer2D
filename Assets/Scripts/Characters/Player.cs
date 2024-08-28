using UnityEngine;

[RequireComponent(typeof(Fliper))]
public class Player : CombatCharacter
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;

    private Fliper _fliper;

    protected override void Awake()
    {
        base.Awake();
        _fliper = GetComponent<Fliper>();
    }

    private void FixedUpdate()
    {
        _fliper.Flip(_inputReader.Direction);
        _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();

        _animator.SetFloat(Speed, Mathf.Abs(_inputReader.Direction));
    }
}