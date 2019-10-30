using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    public void KillPlayer()
    {
        // Kill the player (use animation, reset the screen, etc...)
    }
}
