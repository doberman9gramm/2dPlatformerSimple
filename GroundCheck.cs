using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float _distancetoGround;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void Update()
    {
        _isGrounded = CheckGround();
    }

    private bool CheckGround()
    {
        var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, _distancetoGround, LayerMask.GetMask("Ground"));
        return groundCheck.collider != null && groundCheck.transform.gameObject.TryGetComponent(typeof(Ground), out Component component);
    }
}
