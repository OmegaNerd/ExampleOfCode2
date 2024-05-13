using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBlock : MonoBehaviour
{
    [SerializeField] private float timeActive;
    [SerializeField] private float timeDisable;
    private bool active = false;
    private float timeCurrent = 0;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject lazerReady;
    // Start is called before the first frame update
    void Start()
    {
        timeCurrent = Random.RandomRange(0, timeDisable);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            timeCurrent += 1 * Time.deltaTime;
            if (active == true)
            {
                circle1.transform.localScale = new Vector3(1, 1, 1);
                circle2.transform.localScale = new Vector3(1 , 1, 1);
                lazerReady.SetActive(false);
                lazerReady.transform.localScale = new Vector3(1, 1, 1);
                if (timeCurrent >= timeActive)
                {
                    active = false;
                    timeCurrent = 0;
                    lazerReady.SetActive(true);
                }
                
            }
            else {
                circle1.transform.localScale = new Vector3(timeCurrent / timeDisable, timeCurrent / timeDisable, 1);
                circle2.transform.localScale = new Vector3(timeCurrent / timeDisable, timeCurrent / timeDisable, 1);
                if (timeCurrent >= timeDisable)
                {
                    active = true;
                    timeCurrent = 0;
                }
                lazerReady.SetActive(true);
                lazerReady.transform.localScale = new Vector3(1 - timeCurrent / timeDisable, 1, 1);
            }
            block.SetActive(active);
        }
    }
}
