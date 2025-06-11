using UnityEngine;

public static class SoundManager
{
    public static void PlayWrongSound()
    {
        AudioClip clip = Resources.Load<AudioClip>("WrongSound");
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }
    }

    public static void PlaySuccessSound()
    {
        AudioClip clip = Resources.Load<AudioClip>("Success");
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }
    }
}
