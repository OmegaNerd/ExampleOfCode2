using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnim : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    private float timeCurrent = 0;
    private float timeToChangeFire = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true) {
            timeCurrent += 1 * Time.deltaTime;
            if (timeCurrent >= timeToChangeFire)
            {
                timeCurrent = 0;
                fire.transform.Rotate(0, 180, 0);
            }
        }
    }
}
