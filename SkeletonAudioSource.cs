using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SkeletonAudioSource : MonoBehaviour
{
    [SerializeField] private AudioClip _skeletonWalk;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _skeletonWalk;
        _audioSource.loop = true;
    }

    private void OnEnable()
    {
        Enemy.onNewState += ChangeAudio;
    }

    private void OnDisable()
    {
        Enemy.onNewState -= ChangeAudio;
    }

    private void ChangeAudio(Enemy.State newState)
    {
        switch (newState)
        {
            case Enemy.State.Idle:
                _audioSource.Stop();
                break;

            case Enemy.State.Walk:
                _audioSource.Play();
                break;
        }
    }
}
