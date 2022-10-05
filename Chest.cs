using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour
{
    [SerializeField] private Text _pressAction;
    [SerializeField] private List<GameObject> _itemsInChest;

    private Animator _animator;
    private bool _playerInTrigger;
    private bool _isOpening;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _pressAction.enabled = false;
        _isOpening = false;
        _animator.SetBool("isOpen", _isOpening);
    }

    private void OnEnable()
    {
        PlayerMovement.onNewState += OpenChest;
    }

    private void OnDisable()
    {
        PlayerMovement.onNewState -= OpenChest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PlayerMovement), out Component component) && _pressAction != null)
        {
            _pressAction.enabled = true;
            _playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PlayerMovement), out Component component) && _pressAction != null)
        {
            _pressAction.enabled = false;
            _playerInTrigger = false;
        }
    }

    private void OpenChest(PlayerMovement.playerState state)
    {
        if (_playerInTrigger && _isOpening  == false && state == PlayerMovement.playerState.Action)
        {
            _isOpening = true;
            _animator.SetBool("isOpen", _isOpening);
            Destroy(_pressAction);

            foreach (var itemInChest in _itemsInChest)
            {
                Instantiate(itemInChest, transform.position, Quaternion.identity);
            }
        }
    }
}
