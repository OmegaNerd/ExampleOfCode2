using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazer : MonoBehaviour
{
    [SerializeField] private GameObject deathObj;
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject readyLazer;
    private float timeActive = 0.1f;
    private float timeDeactive = 2f;
    private float timeCurrent;
    private bool activated = false;
    private float circleScale;
    // Start is called before the first frame update
    void Start()
    {
        timeCurrent = Random.RandomRange(0, timeDeactive);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            circle1.transform.localScale = new Vector3(circleScale, circleScale, 1);
            circle2.transform.localScale = new Vector3(circleScale, circleScale, 1);
            timeCurrent += 1 * Time.deltaTime;
            if (activated == false)
            {
                deathObj.SetActive(false);
                readyLazer.SetActive(true);
                circleScale = timeCurrent / timeDeactive;
                readyLazer.transform.localScale = new Vector3(1, 1 - circleScale, 1);
                if (timeCurrent >= timeDeactive)
                {
                    activated = true;
                    timeCurrent = 0;
                }
            }
            else {
                deathObj.SetActive(true);
                readyLazer.transform.localScale = new Vector3(1, 1, 1);
                readyLazer.SetActive(false);
                circleScale = 1;
                if (timeCurrent >= timeActive)
                {
                    activated = false;
                    timeCurrent = 0;
                }
            }
        }
    }
}
