using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Jump = nameof(Jump);
    private const string Fall = nameof(Fall);

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerMovement.onNewState += ChangeAnimation;
    }

    private void OnDisable()
    {
        PlayerMovement.onNewState -= ChangeAnimation;
    }

    private void ChangeAnimation(PlayerMovement.playerState state)
    {
        switch (state)
        {
            case PlayerMovement.playerState.Idle:
                _animator.Play(Idle);
                break;

            case PlayerMovement.playerState.Run:
                _animator.Play(Run);
                break;

            case PlayerMovement.playerState.Jump:
                _animator.Play(Jump);
                break;

            case PlayerMovement.playerState.Fall:
                _animator.Play(Fall);
                break; 
        }
    }
}