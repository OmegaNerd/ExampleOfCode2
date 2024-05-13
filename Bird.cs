using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Camera _cam;
    [SerializeField] private GameObject wing;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime; 
            if (_cam.transform.position.x - transform.position.x >= 30) {
                Destroy(this.gameObject);
            }

        }
    }
}
