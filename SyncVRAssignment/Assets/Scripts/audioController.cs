using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    [SerializeField] private AudioClip heyListen;
    private AudioSource _audioSource;
     
    private static audioController instance = null;
    public static audioController Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
