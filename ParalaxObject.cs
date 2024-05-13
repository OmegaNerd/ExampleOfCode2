using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxObject : MonoBehaviour
{
    [SerializeField] private float paralaxMultiply;
    [SerializeField] private float minX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            transform.position += new Vector3(-GameManager.playerSpeed * paralaxMultiply, 0, 0) * Time.deltaTime;
            if (transform.localPosition.x <= minX) {
                transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}
