using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArrow : MonoBehaviour
{
    private float moveSpeed = 2f;
    [SerializeField] private GameObject rotatingPart;
    private Camera _cam;
    [SerializeField] private GameObject fire;
    private float timeCurrent = 0;
    private float timeToChangeFire = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            if (_cam.transform.position.x - transform.position.x >= 35f)
            {
                Destroy(this.gameObject);
            }
            transform.position += transform.up.normalized * moveSpeed * Time.deltaTime;
            rotatingPart.transform.Rotate(0, 0, 250f * Time.deltaTime);
            timeCurrent += 1 * Time.deltaTime;
            if (timeCurrent >= timeToChangeFire)
            {
                timeCurrent = 0;
                fire.transform.Rotate(0, 180, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Player")) {
            GameManager.UpdateGameState(GameState.Lose);
        }
    }
}
