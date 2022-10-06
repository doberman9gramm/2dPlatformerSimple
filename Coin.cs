using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static Action CoinCollecting;

    [SerializeField] private AudioClip _pickUpCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PlayerMovement), out Component component))
        {
            AudioSource.PlayClipAtPoint(_pickUpCoin, transform.position);
            CoinCollecting?.Invoke();
            Destroy(gameObject);
        }
    }
}
