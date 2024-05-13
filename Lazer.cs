using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public bool activated;
    public bool show;
    [SerializeField] private GameObject leftObj;
    [SerializeField] private GameObject rightObj;
    [SerializeField] private GameObject deathObj;
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject readyLazer;
    private float moveSpeed = 5f;
    public float circleScale;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip lazerSound;
    private bool sounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            if (activated == true)
            {
                if (sounded == false) {
                    sounded = true;
                    audioSource.PlayOneShot(lazerSound, 0.25f);
                }
                deathObj.SetActive(true);
                circle1.transform.localScale = new Vector3(circleScale, circleScale, 1);
                circle2.transform.localScale = new Vector3(circleScale, circleScale, 1);
                readyLazer.transform.localScale = new Vector3(1, 0, 1);
            }
            else {
                sounded = false;
                deathObj.SetActive(false);
                circle1.transform.localScale = new Vector3(circleScale, circleScale, 1);
                circle2.transform.localScale = new Vector3(circleScale, circleScale, 1);
                readyLazer.transform.localScale = new Vector3(1, 1 - circleScale, 1);
            }
            if (show == true)
            {
                readyLazer.SetActive(true);
                if (leftObj.transform.localPosition.x < -8f)
                {
                    leftObj.transform.localPosition += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    leftObj.transform.localPosition = new Vector3(-8f, leftObj.transform.localPosition.y, leftObj.transform.localPosition.z);
                }
                if (rightObj.transform.localPosition.x > 8f)
                {
                    rightObj.transform.localPosition += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    rightObj.transform.localPosition = new Vector3(8f, rightObj.transform.localPosition.y, rightObj.transform.localPosition.z);
                }
            }
            else {
                readyLazer.SetActive(false);
                if (leftObj.transform.localPosition.x > -10f)
                {
                    leftObj.transform.localPosition += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    leftObj.transform.localPosition = new Vector3(-10f, leftObj.transform.localPosition.y, leftObj.transform.localPosition.z);
                }
                if (rightObj.transform.localPosition.x < 10f)
                {
                    rightObj.transform.localPosition += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                }
                else
                {
                    rightObj.transform.localPosition = new Vector3(10f, rightObj.transform.localPosition.y, rightObj.transform.localPosition.z);
                }
            }
        }
    }
}
