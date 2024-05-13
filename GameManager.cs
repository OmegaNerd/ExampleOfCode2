using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameState state;
    public static float landY = -3f;
    public static float landYChanged;
    public static bool landed = true;
    public static Vector3 playerPos;
    public static bool isJumping = false;
    public static bool isDowning = false;
    public static float playerSpeed;
    public static int score = 0;
    public static bool musicOn = true;
    public static bool adShowing = false;
    public static bool adFlag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void UpdateGameState (GameState newState) {
        state = newState;
        switch (newState)
        {
            case GameState.Game:
                Time.timeScale = 1;
                break;
            case GameState.Pause:
                Time.timeScale = 1;
                break;
            case GameState.Ready:
                Time.timeScale = 1;
                break;
            case GameState.Lose:
                Time.timeScale = 1;
                if (score > PlayerPrefs.GetInt("Record")) {
                    PlayerPrefs.SetInt("Record", score);
                }
                break;
        }
    }
}

public enum GameState { 
    Game,
    Lose,
    Pause,
    Ready
}
