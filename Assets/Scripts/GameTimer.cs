using UnityEngine;
using TMPro;
public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 300f;
    public AudioSource audioSource;
    public AudioClip clip;
    private bool timerEnded = false;
    
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