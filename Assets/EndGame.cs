using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject pauseScreen;
    private void Start()
    {
        endScreen.SetActive(false);
    }
    public void EndRound()
    {
        this.GetComponent<SnakeMovementScript>().enabled = false;
        pauseScreen.GetComponent<PauseMenu>().enabled = false;
        endScreen.SetActive(true);
    }
    public void RestartRound()
    {
        this.GetComponent<SnakeMovementScript>().Restart();
        endScreen.SetActive(false);
        this.GetComponent<SnakeMovementScript>().enabled = true;
        pauseScreen.GetComponent<PauseMenu>().enabled = true;
    }
}
