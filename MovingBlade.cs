using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlade : MonoBehaviour
{
    [SerializeField] private GameObject blade;
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    [SerializeField] private GameObject circle;
    [SerializeField] private float moveSpeed;
    private bool movingUp = false;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        blade.transform.localPosition = new Vector3(0, Random.RandomRange(yMin, yMax), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            if (_cam.transform.position.x - transform.position.x >= 35f)
            {
                Destroy(this.gameObject);
            }
            circle.transform.Rotate(0,0,250f * Time.deltaTime);
            if (movingUp == true)
            {
                blade.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
                if (blade.transform.localPosition.y >= yMax)
                {
                    movingUp = false;
                }
            }
            else {
                blade.transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
                if (blade.transform.localPosition.y <= yMin)
                {
                    movingUp = true;
                }
            }
        }
    }
}
