using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private AudioClip heyListen;
    private void Start()
    {
        audio = FindObjectOfType<AudioSource>();
    }
    public void PlaySound()
    {
        audio.PlayOneShot(heyListen);
    }
    public void PlayBarGraph()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayGoldenRatioGraph()
    {
        SceneManager.LoadScene(2);

    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
