using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerSpitfire;
    public GameObject panel;
    
    void Start()
    {
        var sound = playerSpitfire.GetComponent<AudioSource>();
        sound.enabled = false;
        Time.timeScale = 0f;
    }
    
    public void StartSinglePlayer() {
        Time.timeScale = 1f;
        playerSpitfire.GetComponent<CharacterControll>().PlaceCharacter();
        panel.SetActive(false);
    }

    public void ExitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
