using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHole : MonoBehaviour
{
    [SerializeField] private GameObject hole;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private float moveSpeed;
    private bool movingUp = false;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        hole.transform.localPosition = new Vector3(0, Random.RandomRange(minY, maxY), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            if (_cam.transform.position.x - transform.position.x >= 35f)
            {
                Destroy(this.gameObject);
            }
            if (movingUp == true)
            {
                hole.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
                if (hole.transform.localPosition.y >= maxY)
                {
                    movingUp = false;
                }
            }
            else {
                hole.transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
                if (hole.transform.localPosition.y <= minY)
                {
                    movingUp = true;
                }
            }
        }
    }
}
