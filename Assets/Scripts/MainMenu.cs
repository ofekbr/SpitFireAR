using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;
    
    void Start()
    {
        var sound = player.GetComponentInChildren<AudioSource>();
        sound.enabled = false;
        Time.timeScale = 0f;
    }
    
    public void StartSinglePlayer() {
        Time.timeScale = 1f;
        player.GetComponent<CharacterControll>().PlaceCharacter();
        panel.SetActive(false);
    }

    public void ExitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
