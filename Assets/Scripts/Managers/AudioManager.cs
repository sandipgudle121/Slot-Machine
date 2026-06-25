using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [Header("SFX")]
    [SerializeField] private AudioClip buttonClickClip;
    [SerializeField] private AudioClip reelSpinClip;
    [SerializeField] private AudioClip winClip;

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClickClip);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winClip);
    }

    public void PlayReelSpin()
    {
        audioSource.clip = reelSpinClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopReelSpin()
    {
        audioSource.Stop();
    }
}
