using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject startButton;
    public GameObject replayButton;
    public void Start()
    {
        Time.timeScale = 0;
    }
	
    public void StartGame()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
    }
    public void ShowreplayButton()
    {
        replayButton.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
