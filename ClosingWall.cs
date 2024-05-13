using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingWall : MonoBehaviour
{
    [SerializeField] private GameObject wall1;
    [SerializeField] private GameObject wall2;
    private float moveSpeed = 2f;
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    private bool closing = false;
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject circle3;
    [SerializeField] private GameObject circle4;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        float startY = Random.RandomRange(yMin, yMax);
        wall1.transform.localPosition = new Vector3(0, startY, 0);
        wall2.transform.localPosition = new Vector3(0, -startY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            if (_cam.transform.position.x - transform.position.x >= 35f)
            {
                Destroy(this.gameObject);
            }
            if (closing == true)
            {
                circle1.transform.Rotate(0, 0, 250f * Time.deltaTime);
                circle2.transform.Rotate(0, 0, -250f * Time.deltaTime);
                circle3.transform.Rotate(0, 0, -250f * Time.deltaTime);
                circle4.transform.Rotate(0, 0, 250f * Time.deltaTime);
                if (wall1.transform.localPosition.y > yMin)
                {
                    wall1.transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
                    wall2.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
                }
                else
                {
                    closing = false;
                }
            }
            else {
                circle1.transform.Rotate(0, 0, -250f * Time.deltaTime);
                circle2.transform.Rotate(0, 0, 250f * Time.deltaTime);
                circle3.transform.Rotate(0, 0, 250f * Time.deltaTime);
                circle4.transform.Rotate(0, 0, -250f * Time.deltaTime);
                if (wall1.transform.localPosition.y < yMax)
                {
                    wall1.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
                    wall2.transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
                }
                else
                {
                    closing = true;
                }
            }
        }
    }
}
