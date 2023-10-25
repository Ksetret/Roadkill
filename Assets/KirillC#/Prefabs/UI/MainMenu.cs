using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject _scoreWindow;
    [SerializeField] private GameObject _autorWinfow;
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private AudioSource _fonSounde;
    [SerializeField] private GameObject _stopWindow;
    [SerializeField] private GameObject _fon;

    static public MainMenu instance;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0f;
    }
    public void StartGameButton()
    {
        Time.timeScale = 1f;
       // RoadGenerator.instanse.StartLevel();
        _menuWindow.SetActive(false);
        _fon.SetActive(false);
        _fonSounde.Play();
    }

    public void AutorButton()
    {
        _scoreWindow.SetActive(false);
        _autorWinfow.SetActive(true);
        _menuWindow.SetActive(false);
    }

    public void ScoreButton()
    {
        _scoreWindow.SetActive(true);
        _autorWinfow.SetActive(false);
        _menuWindow.SetActive(false);
    }

    public void MainMenuButton()
    {
        _scoreWindow.SetActive(false);
        _autorWinfow.SetActive(false);
        _fon.SetActive(true);
        _stopWindow.SetActive(false);
        _menuWindow.SetActive(true);
    }

    public void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        
        _stopWindow.SetActive(false);
        _fon.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        _stopWindow.SetActive(true);
        _fon.SetActive(true);
        Time.timeScale = 0;

    }

    public void AnayTelegram() { Application.OpenURL("https://web.telegram.org/k/#@anialavik"); }
    public void TimkekichTelegram() { Application.OpenURL("https://web.telegram.org/k/#@timkekich"); }
    public void BigimanButtonTelegram() { Application.OpenURL("https://web.telegram.org/k/#@BigimanBatton"); }
    public void BaufgtTelegram() { Application.OpenURL("https://web.telegram.org/k/#@Baufgt"); }
    public void FlametlTelegram() { Application.OpenURL("https://web.telegram.org/k/#@flametl"); }

    public void KeniuoTelegram() { Application.OpenURL("https://web.telegram.org/k/#@keniuo"); }
}


    