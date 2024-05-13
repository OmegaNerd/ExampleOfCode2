using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroHole : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject electroWall;
    [SerializeField] private GameObject electro1;
    [SerializeField] private GameObject electro2;
    [SerializeField] private float timeOpen;
    [SerializeField] private float timeClose;
    private float timeCurrent = 0;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    private bool opened = false;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        wall.transform.localPosition = new Vector3(wall.transform.localPosition.x, Random.RandomRange(minY, maxY), wall.transform.localPosition.z);
        timeCurrent = Random.RandomRange(0, timeClose);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            if (_cam.transform.position.x - transform.position.x >= 35f)
            {
                Destroy(this.gameObject);
            }
            timeCurrent += 1 * Time.deltaTime;
            if (opened == true)
            {
                electroWall.SetActive(false);
                if (timeCurrent >= timeOpen)
                {
                    timeCurrent = 0;
                    opened = false;
                }
            }
            else {
                electroWall.SetActive(true);
                if (timeCurrent >= timeClose)
                {
                    timeCurrent = 0;
                    opened = true;
                }
            }
        }
    }
}
