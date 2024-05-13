using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pauseBut;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text scoreTextLose;
    [SerializeField] private GameObject recordText;
    [SerializeField] private GameObject musicOffObj;
    [SerializeField] private GameObject readyPanel;
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip loseSound;
    private bool loseSounded = false;
    private float timeToStop = 2f;
    private float timeCurrent = 0;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started == false) {
            GameManager.UpdateGameState(GameState.Ready);
            started = true;
        }
        if (GameManager.state == GameState.Lose) {
            timeCurrent += 1 * Time.deltaTime;
            if (timeCurrent >= timeToStop) {
                //Time.timeScale = 0;
            }
        }
        if (GameManager.state == GameState.Pause)
        {
            timeCurrent += 1 * Time.deltaTime;
            if (timeCurrent >= timeToStop)
            {
                //Time.timeScale = 0;
            }
        }
        if (GameManager.state == GameState.Ready)
        {
            readyPanel.SetActive(true);
            if (GameManager.adShowing == false) {
                
            }
            
        }
        else {
            readyPanel.SetActive(false);
        }
        
        scoreText.text = GameManager.score.ToString();
        scoreTextLose.text = GameManager.score.ToString();
        musicOffObj.SetActive(!GameManager.musicOn);
        if (GameManager.score >= PlayerPrefs.GetInt("Record"))
        {
            recordText.SetActive(true);
        }
        else {
            recordText.SetActive(false);
        }
        if (GameManager.state == GameState.Pause)
        {
            pausePanel.SetActive(true);
        }
        else {
            pausePanel.SetActive(false);
        }
        if (GameManager.state == GameState.Lose)
        {
            losePanel.SetActive(true);
            if (loseSounded == false) {
                loseSounded = true;
                audioSource.PlayOneShot(loseSound, 0.2f);
            }
        }
        else
        {
            losePanel.SetActive(false);
        }
        if (GameManager.state == GameState.Game)
        {
            timeCurrent = 0;
            pauseBut.SetActive(true);
            if (GameManager.musicOn == true)
            {
                if (musicSource.isPlaying == false)
                {
                    musicSource.Play();
                }

            }
            else
            {
                if (musicSource.isPlaying == true)
                {
                    musicSource.Stop();
                }
            }
        }
        else {
            pauseBut.SetActive(false);
            if (musicSource.isPlaying == true)
            {
                musicSource.Stop();
            }
        }
    }

    public void PauseButton() {
        GameManager.UpdateGameState(GameState.Pause);
    }

    public void ResumeButton() {
        GameManager.UpdateGameState(GameState.Game);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void MusicButton() {
        GameManager.musicOn = !GameManager.musicOn;
    }
}
