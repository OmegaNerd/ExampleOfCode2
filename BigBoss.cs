using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour
{
    public bool show;
    [SerializeField] private float xHide;
    [SerializeField] private float xShow;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject pushka;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject shootPos;
    private float timeCurrent = 0;
    [SerializeField]private float timeToShoot = 2f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            if (show == true)
            {
                circle1.transform.localScale = new Vector3(timeCurrent/timeToShoot, timeCurrent/timeToShoot, 1);
                if (transform.localPosition.x > xShow)
                {
                    transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
                    DifficultyChanger();
                }
                else {
                    transform.localPosition = new Vector3(xShow, transform.localPosition.y, transform.localPosition.z);
                    timeCurrent += 1 * Time.deltaTime;
                    pushka.transform.up = Vector3.Lerp(pushka.transform.up.normalized, (GameManager.playerPos - pushka.transform.position + new Vector3(0, -2f, 0)).normalized, 0.2f);
                    if (timeCurrent >= timeToShoot)
                    {
                        Instantiate(arrow, shootPos.transform.position, pushka.transform.rotation);
                        audioSource.PlayOneShot(shootSound, 0.25f);
                        timeCurrent = 0;
                    }
                }
                
            }
            else {
                timeCurrent = 0;
                circle1.transform.localScale = new Vector3(0, 0, 1);
                if (transform.localPosition.x < xHide)
                {
                    transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
                }
                else
                {
                    transform.localPosition = new Vector3(xHide, transform.localPosition.y, transform.localPosition.z);
                }
            }
        }
    }

    public void DifficultyChanger() {
        if (GameManager.score < 500)
        {
            timeToShoot = 2.5f;
        }
        else if (GameManager.score < 1000)
        {
            timeToShoot = 2.25f;
        }
        else if (GameManager.score < 1500)
        {
            timeToShoot = 2f;
        }
        else if (GameManager.score < 2000)
        {
            timeToShoot = 1.75f;
        }
        else if (GameManager.score < 2500)
        {
            timeToShoot = 1.5f;
        }
        else if (GameManager.score < 3000)
        {
            timeToShoot = 1.25f;
        }
        else if (GameManager.score < 3500)
        {
            timeToShoot = 1f;
        }
        else if (GameManager.score < 4000)
        {
            timeToShoot = 1f;
        }
        else
        {
            timeToShoot = 1f;
        }
    }
}
