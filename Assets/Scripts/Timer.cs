using UnityEngine;
using TMPro;

public class Timer
{
    public TextMeshProUGUI timerText;
    public float timer = 5;
    public AudioSource audioSource;
    public AudioClip clip;
    
    //update
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if (timer <= 0)
        { 
            audioSource.PlayOneShot(clip);
            timer = 5;
        }
    }
}