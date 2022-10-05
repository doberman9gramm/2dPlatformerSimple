using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public static Action<State> onNewState;

    [SerializeField] private float _speed;
    [SerializeField] private List<Target> _targets = new List<Target>();

    private Target _currentTarget;
    private int _targetIndex;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private bool _isFliped;
    private State _currentState;

    public enum State
    {
        Idle,
        Walk,
    }

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        if (_targets.Count != 0)
            _currentTarget = _targets[0];
    }

    private void Update()
    {
        if (_currentTarget != null)
            WalkToTarget();
        else
            Idle();
    }

    private void WalkToTarget()
    {
        CheckToFlip();
        _rigidbody2D.velocity = new Vector2(_speed * Time.fixedDeltaTime, 0); 
        
        if (_currentState != State.Walk)
            onNewState?.Invoke(_currentState = State.Walk);
    }

    private void CheckToFlip()
    {
        if (_currentTarget.transform.position.x > this.transform.position.x && _isFliped == false)
        {
            DoFlip();
            _isFliped = true;
        }
        else if (_currentTarget.transform.position.x < this.transform.position.x && _isFliped == true)
        {
            DoFlip();
            _isFliped = false;
        }
    }

    private void DoFlip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        _speed *= -1;
    }

    private void Idle()
    {
        _rigidbody2D.velocity = Vector2.zero;

        if (_currentState != State.Idle)
            onNewState?.Invoke(_currentState = State.Idle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Target>() && collision.gameObject == _currentTarget.gameObject)
            NextTarget();
    }

    private void NextTarget()
    {
        if (_targets.Count > 1)
            _currentTarget = _targets.Count > _targetIndex + 1 ? _targets[++_targetIndex] : _targets[_targetIndex = 0];
        else
            _currentTarget = null;
    }
}
