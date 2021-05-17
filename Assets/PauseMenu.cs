using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject snake;
    [SerializeField] GameObject pauseCanvas;
    bool enable = true;
    private void Start()
    {
        pauseCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) PauseGame();
    }
    private void PauseGame()
    {
        if (enable == true)
        {
            enable = false;
            pauseCanvas.SetActive(true);
        }
        else 
        {
            enable = true;
            pauseCanvas.SetActive(false);
        }
        snake.GetComponent<SnakeMovementScript>().enabled = enable;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
