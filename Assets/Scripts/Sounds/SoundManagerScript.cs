using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip laserShotSound;
    public static AudioClip gameOverSound;

    static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        laserShotSound = Resources.Load<AudioClip>("LaserShot");
        gameOverSound = Resources.Load<AudioClip>("gameOver");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Plays the sound with the given name.
    public static void PlaySound(string clipName)
    {
        switch(clipName)
        {
            case "LaserShot":
                audioSrc.PlayOneShot(laserShotSound);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
        }
    }
}
