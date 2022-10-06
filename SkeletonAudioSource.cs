using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Skeleton))]
public class SkeletonAudioSource : MonoBehaviour
{
    [SerializeField] private AudioClip _skeletonWalk;

    private Skeleton _skeleton;
    private AudioSource _audioSource;

    private void Awake()
    {
        _skeleton = GetComponent<Skeleton>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        _audioSource.clip = _skeletonWalk;
        _audioSource.loop = true;
    }

    private void OnEnable()
    {
        _skeleton.OnCurrentState += ChangeAudio; 
    }

    private void OnDisable()
    {
        _skeleton.OnCurrentState -= ChangeAudio;
    }
    
    private void ChangeAudio(Skeleton.State newState)
    {
        switch (newState)
        {
            case Skeleton.State.Idle:
                _audioSource.Stop();
                break;

            case Skeleton.State.Walk:
                _audioSource.Play();
                break;
        }
    }
}
