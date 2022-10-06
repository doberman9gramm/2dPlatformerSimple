using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;

    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Jump = nameof(Jump);
    private const string Fall = nameof(Fall);

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerMovement.OnState += ChangeAnimation;
    }

    private void OnDisable()
    {
        _playerMovement.OnState -= ChangeAnimation;
    }

    private void ChangeAnimation(PlayerMovement.PlayerState state)
    {
        switch (state)
        {
            case PlayerMovement.PlayerState.Idle:
                _animator.Play(Idle);
                break;

            case PlayerMovement.PlayerState.Run:
                _animator.Play(Run);
                break;

            case PlayerMovement.PlayerState.Jump:
                _animator.Play(Jump);
                break;

            case PlayerMovement.PlayerState.Fall:
                _animator.Play(Fall);
                break; 
        }
    }
}