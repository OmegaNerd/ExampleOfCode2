using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWithHole : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject upWall;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        float wallY = Random.RandomRange(yMin, yMax);
        wall.transform.localPosition = new Vector3(0, wallY, 0);
        upWall.transform.position += new Vector3(0, Random.RandomRange(0.2f,0.5f), 0);
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
