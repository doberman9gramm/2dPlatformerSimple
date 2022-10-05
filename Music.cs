using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    [SerializeField] private bool _isMusicOn;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SwitchOnOff()
    {
        _isMusicOn = !_isMusicOn;
        _audioSource.enabled = _isMusicOn;
    }
}
