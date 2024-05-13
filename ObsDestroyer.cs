using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsDestroyer : MonoBehaviour
{
    private Camera _cam;
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
        }
    }
}
