using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject victory;
    public GameObject Boss;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void StartBoss(){
        Boss.SetActive(true);
    }

    public void ShowVictory()
    {
        victory.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);

    }

    public void QuitGame(){
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
