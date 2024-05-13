using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float upPosY;
    [SerializeField] private GameObject fire;
    private float timeCurrent = 0;
    private float timeToChangeFire = 0.25f;
    [SerializeField] private bool falling = true;
    private float fallingTimeCurrent = 0;
    private float fallingTime = 1f;
    private bool activated = false;
    private float fallSpeed = 10f;
    [SerializeField] private GameObject energyObj;
    [SerializeField] private GameObject greenObj;
    [SerializeField] private GameObject upBlock;
    [SerializeField] private GameObject platformBlock;
    [SerializeField] private bool floor = false;
    public bool shouldPlatformBlock = false;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        if (floor == false) {
            if (falling == true)
            {
                
                upBlock.SetActive(true);
                
            }
            else
            {
                //upBlock.SetActive(false);
                /*int dice = Random.Range(1, 3);
                if (dice == 1)
                {
                    platformBlock.SetActive(true);
                }
                else
                {
                    platformBlock.SetActive(false);
                }*/
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCurrent += 1 * Time.deltaTime;
        if (timeCurrent >= timeToChangeFire)
        {
            timeCurrent = 0;
            fire.transform.Rotate(0, 180, 0);
        }
        if (GameManager.state == GameState.Game) {
            if (_cam.transform.position.x - transform.position.x >= 35f && floor == false) {
                Destroy(this.gameObject);
            }
            if (floor == false) {
                if (shouldPlatformBlock == true)
                {
                    platformBlock.SetActive(true);
                }
                else {
                    platformBlock.SetActive(false);
                }
            }
            timeCurrent += 1 * Time.deltaTime;
            if (timeCurrent >= timeToChangeFire) {
                timeCurrent = 0;
                fire.transform.Rotate(0, 180, 0);
            }
            if (falling == true) {
                if (activated == true)
                {
                    greenObj.SetActive(false);
                    fallingTimeCurrent += 1 * Time.deltaTime;
                    if (fallingTimeCurrent >= fallingTime)
                    {
                        transform.position += new Vector3(0, -fallSpeed, 0) * Time.deltaTime;
                        energyObj.transform.localScale = new Vector3(0, 1, 1);
                        fire.SetActive(false);
                    }
                    else {
                        energyObj.transform.localScale = new Vector3(1 - (fallingTimeCurrent / fallingTime), 1, 1);
                    }
                    
                }
                else {
                    greenObj.SetActive(true);
                    energyObj.transform.localScale = new Vector3(1,1,1);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Skate")) {
            if (GameManager.isDowning == true) {
                GameManager.landed = true;
                GameManager.landYChanged = transform.position.y + upPosY;
                GameManager.landY = GameManager.landYChanged;
                activated = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Skate"))
        {
            if (GameManager.isDowning == false && GameManager.isJumping == false) {
                GameManager.landed = false;
            }
            
        }
    }
}
