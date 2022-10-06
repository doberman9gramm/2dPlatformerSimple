using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(PlayerMovement))]
public class FlipPlayer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerMovement.HorozintalValue < 0)
            _spriteRenderer.flipX = true;

        else if (_playerMovement.HorozintalValue > 0)
            _spriteRenderer.flipX = false;
    }
}
