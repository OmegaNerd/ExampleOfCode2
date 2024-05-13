using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArrow2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private GameObject rotatingPart;
    private Camera _cam;
    [SerializeField]private float speedDown;
    [SerializeField]private float speedPlus;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game)
        {
            if (_cam.transform.position.x - transform.position.x >= 35f || _cam.transform.position.y - transform.position.y >= 35f)
            {
                Destroy(this.gameObject);
            }
            transform.position += transform.up.normalized * moveSpeed * Time.deltaTime;
            rotatingPart.transform.Rotate(0, 0, 250f * Time.deltaTime);
            transform.position += new Vector3(0, -speedDown * Time.deltaTime, 0);
            speedDown += speedPlus * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Player"))
        {
            GameManager.UpdateGameState(GameState.Lose);
        }
    }
}
