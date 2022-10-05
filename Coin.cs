using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static Action PickUpCoin;

    [SerializeField] private AudioClip _pickUpCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PlayerMovement), out Component component))
        {
            AudioSource.PlayClipAtPoint(_pickUpCoin, transform.position);
            PickUpCoin?.Invoke();
            Destroy(gameObject);
        }
    }
}
