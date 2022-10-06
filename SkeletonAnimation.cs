using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SkeletonAnimation : MonoBehaviour
{
    [SerializeField] private Skeleton _skeleton; 

    private Animator _animator;

    private const string Idle = nameof(Idle);
    private const string Walk = nameof(Walk);

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _skeleton.OnCurrentState += ChangeAnimation;
    }

    private void OnDisable()
    {
        _skeleton.OnCurrentState -= ChangeAnimation;
    }

    private void ChangeAnimation(Skeleton.State newState)
    {
        switch (newState)
        {
            case Skeleton.State.Idle:
                _animator.Play(Idle);
                break;

            case Skeleton.State.Walk:
                _animator.Play(Walk);
                break;
        }
    }
}
