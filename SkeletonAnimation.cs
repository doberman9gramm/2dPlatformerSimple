using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SkeletonAnimation : MonoBehaviour
{
    private Animator _animator;

    private const string Idle = nameof(Idle);
    private const string Walk = nameof(Walk);

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Enemy.onNewState += ChangeAnimation;
    }

    private void OnDisable()
    {
        Enemy.onNewState -= ChangeAnimation;
    }

    private void ChangeAnimation(Enemy.State newState)
    {
        switch (newState)
        {
            case Enemy.State.Idle:
                _animator.Play(Idle);
                break;

            case Enemy.State.Walk:
                _animator.Play(Walk);
                break;
        }
    }
}
