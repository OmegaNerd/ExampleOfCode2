using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject musicOffObj;
    [SerializeField] private AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        musicOffObj.SetActive(!GameManager.musicOn);
        if (GameManager.musicOn == true)
        {
            if (musicSource.isPlaying == false)
            {
                //musicSource.Play();
            }
        }
        else
        {
            if (musicSource.isPlaying == true)
            {
                //musicSource.Stop();
            }
        }
    }

    public void PlayButton() {
        SceneManager.LoadScene("ModesScene");
    }


    public void MusicButton() { 
        GameManager.musicOn = !GameManager.musicOn;
    }
}
