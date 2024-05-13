using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAdFlag : MonoBehaviour
{
    public GameObject flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flag.SetActive(GameManager.adFlag);
    }
}
