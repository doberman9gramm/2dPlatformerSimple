using UnityEngine;

public class CloudsFloating : MonoBehaviour
{
    [SerializeField] private float _speedX = 0.01f;

    private void FixedUpdate() => transform.position += new Vector3(_speedX, 0, 0);
}
