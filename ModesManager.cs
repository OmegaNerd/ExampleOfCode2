using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModesManager : MonoBehaviour
{
    [SerializeField] private GameObject musicOffObj;
    [SerializeField] private TMP_Text recordText;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject circle2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        circle1.transform.Rotate(0, 0, -15f * Time.deltaTime);
        circle2.transform.Rotate(0, 0, 15f * Time.deltaTime);
        musicOffObj.SetActive(!GameManager.musicOn);
        recordText.text = PlayerPrefs.GetInt("Record").ToString();
        if (GameManager.musicOn == true)
        {
            if (musicSource.isPlaying == false)
            {
                //musicSource.Play();
            }
        }
        else {
            if (musicSource.isPlaying == true) {
                //musicSource.Stop();
            }
        }
    }

    public void MusicButton()
    {
        GameManager.musicOn = !GameManager.musicOn;
    }

    public void DayButton() {
        SceneManager.LoadScene("PlayScene");
    }

    public void NightButton() {
        SceneManager.LoadScene("PlayScene2");
    }

    public void BackButton() {
        SceneManager.LoadScene("MenuScene");
    }
}
