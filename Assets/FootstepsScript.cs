using UnityEngine;

public class FootstepsScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip runningSound;
    public bool played = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = runningSound;
    }

    // Update is called once per frame
    void Update()
    {
        // running sounds
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !played)// || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //PlaySoundEffect(runningSound);
            audioSource.Play();
            played = true;
        } else if (played && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            audioSource.Stop();
            played = false;
        }
    }
    void PlaySoundEffect(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
