using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour
{
    [SerializeField] private Text _pressAction;
    [SerializeField] private List<GameObject> _itemsInChest;

    private Animator _animator;
    private bool _isOpening;

    private const string isOpen = nameof(isOpen);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _pressAction.enabled = false;
        _isOpening = false;
        _animator.SetBool(isOpen, _isOpening);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PlayerMovement), out Component component) && _pressAction != null)
            _pressAction.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PlayerMovement), out Component component) && _pressAction != null)
            if (Input.GetKey("e"))
                OpenChest();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PlayerMovement), out Component component) && _pressAction != null)
            _pressAction.enabled = false;
    }

    private void OpenChest()
    {
        if (_isOpening  == false)
        {
            _isOpening = true;
            _animator.SetBool(isOpen, _isOpening);
            Destroy(_pressAction);

            foreach (var itemInChest in _itemsInChest)
            {
                Instantiate(itemInChest, transform.position, Quaternion.identity);
            }
        }
    }
}
