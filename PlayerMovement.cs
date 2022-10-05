using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundCheck))]
public class PlayerMovement : MonoBehaviour
{
    public static Action<playerState> onNewState;

    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    
    private GroundCheck _groundCheck;
    private Rigidbody2D _playerRigidbody;
    private playerState _playerState;
    private static float _horozintalValue;

    public enum playerState
    {
        Idle,
        Run,
        Jump,
        Fall,
        Action,
    }

    public float HorozintalValue => _horozintalValue;

    private void Start()
    {
        _groundCheck = GetComponent<GroundCheck>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Idle();
        Fall();
        Action();
    }

    private void Move()
    {
        _horozintalValue = Input.GetAxisRaw("Horizontal");

        if (_horozintalValue != 0)
        {
            _playerRigidbody.velocity = new Vector2(_horozintalValue * playerSpeed, _playerRigidbody.velocity.y);

            if (_groundCheck.IsGrounded)
                onNewState?.Invoke(_playerState = playerState.Run);
        }
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && _groundCheck.IsGrounded)
        {
            _playerRigidbody.velocity = new Vector2(0, jumpPower);
            onNewState?.Invoke(_playerState = playerState.Jump);
        }
    }

    private void Idle()
    {
        if (Input.anyKey == false && _groundCheck.IsGrounded)
        {
            _playerRigidbody.velocity = Vector2.zero;
            onNewState?.Invoke(_playerState = playerState.Idle);
        }
    }

    private void Fall()
    {
        if (_groundCheck.IsGrounded == false && _playerState != playerState.Jump)
        {
            onNewState?.Invoke(_playerState = playerState.Fall);
        }
    }

    private void Action()
    {
        if (Input.GetKey("e") && _groundCheck.IsGrounded)
            onNewState?.Invoke(_playerState = playerState.Action);
    }
}