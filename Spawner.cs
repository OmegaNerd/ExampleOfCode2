using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int modeIndex = 1;
    [SerializeField] private GameObject blade;
    [SerializeField] private GameObject floor;
    [SerializeField] private float floorMaxLeftX;
    [SerializeField] private float floorReplaceX;
    [SerializeField] private float floorReplaceY;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject platform2;
    private GameObject lastPlatform;
    [SerializeField] private GameObject obs1;
    [SerializeField] private GameObject obs2;
    [SerializeField] private GameObject obs3;
    [SerializeField] private GameObject obs4;
    [SerializeField] private GameObject obs5;
    private Camera _cam;
    private float lastDistanceObs;
    private float currentDistanceObs = 0;
    private GameObject lastObs;
    private int obsCount = 0;
    [SerializeField] GameObject lazer1;
    [SerializeField] GameObject lazer2;
    private float timeLazerCurrent = 0;
    private float timeLazerReady = 3f;
    private float timeLazerActive = 3.5f;
    [SerializeField] private GameObject bigBoss;
    [SerializeField] private GameObject bigBoss2;
    [SerializeField] private GameObject bossLazer;
    private float lastDistancePlatform;
    private float currentDistancePlatform = 0;
    private int platformCount;
    [SerializeField] private GameObject perila;
    [SerializeField] private float perilaYmax;
    [SerializeField] private float perilaYmin;
    [SerializeField] private float perilaShowSpeed;
    [SerializeField] private float perilaHideSpeed;
    private bool firstPlatformUsed = false;
    private int lastObsIndex = 2;
    private int bossIndex = 2;
    private float boss2StartPosX;
    private float modesWithoutBossCount = 0;
    private float modesWithoutPlatformsCount = 0;
    private float modesWithoutLazersCount = 0;
    private float modesWithoutDefaultCount = 0;
    //Difficulty
    private float spawnDistanceMin = 14;
    private float spawnDistanceMax = 15;
    private int obsToEndBoss1 = 5;
    private float distanceToEndBoss2 = 75;
    private int platform1Freq = 3;
    private int platform2Freq = 3;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        lastObs = Instantiate(obs3, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(0, 4.65f, 0), new Quaternion());
        lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
        obsCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Game) {
            switch (modeIndex) {
                case 1:
                    if (_cam.transform.position.x - floor.transform.position.x >= floorMaxLeftX) {
                        floor.transform.position = new Vector3(_cam.transform.position.x, floor.transform.position.y, floor.transform.position.z);

                    }
                    if (lastPlatform == null)
                    {
                        Mode1Spawn();
                        ShowPerila();
                    }
                    else
                    {
                        if (transform.position.x - lastPlatform.transform.position.x >= 30f)
                        {
                            Mode1Spawn();
                            ShowPerila();
                        }
                    }

                    break;

                case 2:
                    if (_cam.transform.position.x - floor.transform.position.x >= floorMaxLeftX)
                    {
                        floor.transform.position = new Vector3(_cam.transform.position.x, floor.transform.position.y, floor.transform.position.z);

                    }
                    if (lastPlatform == null)
                    {
                        Mode2Spawn();
                        ShowPerila();
                    }
                    else {
                        if (transform.position.x - lastPlatform.transform.position.x >= 30f) {
                            Mode2Spawn();
                            ShowPerila();
                        }
                    }

                    break;
                case 3:
                    if (_cam.transform.position.x - floor.transform.position.x >= floorMaxLeftX)
                    {
                        floor.transform.position = new Vector3(_cam.transform.position.x, floor.transform.position.y, floor.transform.position.z);

                    }
                    if (lastPlatform == null)
                    {
                        Mode3Spawn();
                        ShowPerila();
                    }
                    else
                    {
                        if (transform.position.x - lastPlatform.transform.position.x >= 30f)
                        {
                            Mode3Spawn();
                            ShowPerila();
                        }
                    }
                    break;
                case 4:
                    Mode4Spawn();
                    HidePerila();
                    break;
                case 5:
                    Mode5Spawn();
                    HidePerila();
                    break;
            }
        }
    }

    public void DifficultyChanger() {
        if (GameManager.score < 500)
        {
            spawnDistanceMin = 14f;
            spawnDistanceMax = 15f;
            obsToEndBoss1 = 6;
            distanceToEndBoss2 = 100f;
            platform1Freq = 3;
            platform2Freq = 3;
        }
        else if (GameManager.score < 1000)
        {
            spawnDistanceMin = 13f;
            spawnDistanceMax = 14f;
            obsToEndBoss1 = 6;
            distanceToEndBoss2 = 105f;
            platform1Freq = 3;
            platform2Freq = 3;
        }
        else if (GameManager.score < 1500)
        {
            spawnDistanceMin = 12f;
            spawnDistanceMax = 13f;
            obsToEndBoss1 = 7;
            distanceToEndBoss2 = 110f;
            platform1Freq = 2;
            platform2Freq = 2;
        }
        else if (GameManager.score < 2000)
        {
            spawnDistanceMin = 11f;
            spawnDistanceMax = 12f;
            obsToEndBoss1 = 7;
            distanceToEndBoss2 = 115f;
            platform1Freq = 2;
            platform2Freq = 2;
        }
        else if (GameManager.score < 2500)
        {
            spawnDistanceMin = 10f;
            spawnDistanceMax = 11f;
            obsToEndBoss1 = 8;
            distanceToEndBoss2 = 120f;
            platform1Freq = 2;
            platform2Freq = 1;
        }
        else if (GameManager.score < 3000)
        {
            spawnDistanceMin = 10f;
            spawnDistanceMax = 11f;
            obsToEndBoss1 = 8;
            distanceToEndBoss2 = 125f;
            platform1Freq = 2;
            platform2Freq = 1;
        }
        else if (GameManager.score < 3500)
        {
            spawnDistanceMin = 10f;
            spawnDistanceMax = 11f;
            obsToEndBoss1 = 9;
            distanceToEndBoss2 = 130f;
            platform1Freq = 1;
            platform2Freq = 1;
        }
        else if (GameManager.score < 4000)
        {
            spawnDistanceMin = 10f;
            spawnDistanceMax = 11f;
            obsToEndBoss1 = 9;
            distanceToEndBoss2 = 140f;
            platform1Freq = 1;
            platform2Freq = 1;
        }
        else {
            spawnDistanceMin = 10f;
            spawnDistanceMax = 11f;
            obsToEndBoss1 = 10;
            distanceToEndBoss2 = 150f;
            platform1Freq = 1;
            platform2Freq = 1;
        }
    }

    public void ShowPerila() {

        perila.SetActive(true);
        if (perila.transform.localPosition.y < perilaYmax)
        {
            perila.transform.position += new Vector3(0, perilaShowSpeed, 0) * Time.deltaTime;
            
        }
        else {
            perila.transform.localPosition = new Vector3(perila.transform.localPosition.x, perilaYmax, perila.transform.localPosition.z) ;
        }
    }

    public void HidePerila() {
        if (perila.transform.localPosition.y > perilaYmin)
        {
            perila.transform.position += new Vector3(0, -perilaHideSpeed, 0) * Time.deltaTime;

        }
        else
        {
            perila.transform.localPosition = new Vector3(perila.transform.localPosition.x, perilaYmin, perila.transform.localPosition.z);
            perila.SetActive(false);
        }
    }

    public void ChangeMode() {
        DifficultyChanger();
        if (modeIndex == 4 || modeIndex == 5)
        {
            floor.transform.position = new Vector3(_cam.transform.position.x + floorReplaceX, lastPlatform.transform.position.y, 0);
            modeIndex = Random.Range(1, 4);
            //Убать if
            
        }
        else {
            int newModeIndex = Random.Range(1, 6);
            //Убать newModeIndex == 3
            if (modeIndex == newModeIndex)
            {
                newModeIndex += 1;

            }
            modeIndex = newModeIndex;
            
        }
        
        if (modesWithoutBossCount >= 5) {
            modeIndex = 3;
        }
        if (modesWithoutPlatformsCount >= 4)
        {
            modeIndex = 4;
        }
        if (modesWithoutLazersCount >= 5)
        {
            modeIndex = 2;
        }
        if (modesWithoutDefaultCount >= 2) {
            modeIndex = 1;
        }
        modesWithoutBossCount += 1;
        modesWithoutPlatformsCount += 1;
        modesWithoutLazersCount += 1;
        switch (modeIndex)
        {
            case 1:
                modesWithoutPlatformsCount = 0;
                lastObs = Instantiate(obs3, new Vector3(transform.position.x + 10, floor.transform.position.y, transform.position.z) + new Vector3(0, 0, 0), new Quaternion());
                lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                obsCount = 1;
                break;
            case 2:
                modesWithoutLazersCount = 0;
                float lazerRandomPlus = Random.RandomRange(0, 0.75f);
                lazer1.transform.localPosition = new Vector3(0, -2.75f + lazerRandomPlus, 10);
                lazer2.transform.localPosition = new Vector3(0, 3.25f + lazerRandomPlus, 10);
                break;
            case 3:
                modesWithoutBossCount = 0;
                if (bossIndex == 2)
                {
                    bigBoss.GetComponent<BigBoss>().show = true;
                    lastObs = Instantiate(blade, new Vector3(transform.position.x + 10, floor.transform.position.y, transform.position.z) + new Vector3(0, 1.1f, 0), new Quaternion());
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    obsCount = 1;
                    bossIndex = 1;
                }
                else {
                    bigBoss2.GetComponent<BigBoss2>().show = true;
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    boss2StartPosX = transform.position.x;
                    bossIndex = 2;
                }
                break;
            case 4:
                modesWithoutPlatformsCount = 0;
                if (firstPlatformUsed == false)
                {
                    lastPlatform = Instantiate(platform, floor.transform.position  + new Vector3(20, 2.65f, 0), new Quaternion());
                    lastDistancePlatform = Random.RandomRange(8f, 10f);
                    platformCount = 1;
                    firstPlatformUsed = true;
                    modeIndex = 4;
                }
                else {
                    lastPlatform = Instantiate(platform2, floor.transform.position + new Vector3(20, 2.65f, 0), new Quaternion());
                    lastDistancePlatform = Random.RandomRange(7.5f, 10f);
                    platformCount = 1;
                    firstPlatformUsed = false;
                    modeIndex = 5;
                }
                break;
            case 5:
                modesWithoutPlatformsCount = 0;
                if (firstPlatformUsed == false)
                {
                    lastPlatform = Instantiate(platform, floor.transform.position + new Vector3(20, 2.65f, 0), new Quaternion());
                    lastDistancePlatform = Random.RandomRange(8f, 10f);
                    platformCount = 1;
                    firstPlatformUsed = true;
                    modeIndex = 4;
                }
                else
                {
                    lastPlatform = Instantiate(platform2, floor.transform.position + new Vector3(20, 2.65f, 0), new Quaternion());
                    lastDistancePlatform = Random.RandomRange(7.5f, 10f);
                    platformCount = 1;
                    firstPlatformUsed = false;
                    modeIndex = 5;
                }
                break;
        }
    }

    public void Mode1Spawn() {
        currentDistanceObs = transform.position.x - lastObs.transform.position.x;
        if (currentDistanceObs >= lastDistanceObs && obsCount < 10) {
            int obsDice = Random.Range(2, 7);
            if (obsDice == lastObsIndex) {
                if (obsDice < 6)
                {
                    obsDice += 1;
                }
                else {
                    obsDice = 2;
                }
            }
            lastObsIndex = obsDice;
            switch (obsDice) {
                case 1:
                    int countDice = Random.Range(2,6);
                    
                    for (int i = 0; i < countDice; i++) {
                        lastObs = Instantiate(blade, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(i, 1.1f, 0), new Quaternion());
                    }
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    break;
                case 2:
                    lastObs = Instantiate(obs1, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(0, 4.65f, 0), new Quaternion());
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    break;
                case 3:
                    lastObs = Instantiate(obs2, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(0, 4.65f, 0), new Quaternion());
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    break;
                case 4:
                    lastObs = Instantiate(obs3, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(0, 4.65f, 0), new Quaternion());
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    break;
                case 5:
                    lastObs = Instantiate(obs4, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(0, 4.65f, 0), new Quaternion());
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    break;
                case 6:
                    lastObs = Instantiate(obs5, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(0, 4.65f, 0), new Quaternion());
                    lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                    break;
            }
            obsCount += 1;
            
        }
        if (obsCount >= 10 && currentDistanceObs >= 20)
        {
            ChangeMode();
            obsCount = 0;
            currentDistanceObs = 0;
        }
    }

    public void Mode2Spawn() {
        lazer1.GetComponent<Lazer>().show = true;
        lazer2.GetComponent<Lazer>().show = true;
        timeLazerCurrent += 1 * Time.deltaTime;
        if (timeLazerCurrent < timeLazerReady) {
            lazer1.GetComponent<Lazer>().circleScale = (timeLazerCurrent / timeLazerReady);
            lazer2.GetComponent<Lazer>().circleScale = (timeLazerCurrent / timeLazerReady);
        }
        
        if (timeLazerCurrent >= timeLazerReady && timeLazerCurrent < timeLazerActive) { 
            lazer1.GetComponent<Lazer>().activated = true;
            lazer2.GetComponent<Lazer>().activated = true;
            lazer1.GetComponent<Lazer>().circleScale = (1 );
            lazer2.GetComponent<Lazer>().circleScale = (1 );
        }
        if (timeLazerCurrent >= timeLazerActive) {
            lazer1.GetComponent<Lazer>().activated = false;
            lazer2.GetComponent<Lazer>().activated = false;
            lazer1.GetComponent<Lazer>().show = false;
            lazer2.GetComponent<Lazer>().show = false;
            timeLazerCurrent = 0;
            ChangeMode();
        }
    }

    public void Mode3Spawn() {
        if (bossIndex == 1)
        {
            currentDistanceObs = transform.position.x - lastObs.transform.position.x;
            if (currentDistanceObs >= lastDistanceObs && obsCount < obsToEndBoss1)
            {
                int countDice = Random.Range(1, 4);

                for (int i = 0; i < countDice; i++)
                {
                    lastObs = Instantiate(blade, new Vector3(transform.position.x, floor.transform.position.y, transform.position.z) + new Vector3(i * 1.1f, 1.1f, 0), new Quaternion());
                }
                lastDistanceObs = Random.RandomRange(spawnDistanceMin, spawnDistanceMax);
                obsCount += 1;
                currentDistanceObs = transform.position.x - lastObs.transform.position.x;
            }
            if (currentDistanceObs >= 10 && obsCount >= obsToEndBoss1)
            {
                bigBoss.GetComponent<BigBoss>().show = false;
                bigBoss2.GetComponent<BigBoss2>().show = false;
                if (currentDistanceObs >= 20)
                {
                    obsCount = 0;
                    currentDistanceObs = 0;
                    ChangeMode();
                }
            }
        }
        else {
            currentDistanceObs = transform.position.x - boss2StartPosX;
            if (currentDistanceObs >= distanceToEndBoss2)
            {
                bigBoss.GetComponent<BigBoss>().show = false;
                bigBoss2.GetComponent<BigBoss2>().show = false;
                if (currentDistanceObs >= distanceToEndBoss2 + 10)
                {
                    obsCount = 0;
                    currentDistanceObs = 0;
                    ChangeMode();
                }
            }
        }
    }

    public void Mode4Spawn() {
        currentDistancePlatform = transform.position.x - lastPlatform.transform.position.x;
        if (currentDistancePlatform >= lastDistancePlatform && platformCount < 12) {
            if (platformCount > 0)
            {
                lastPlatform = Instantiate(platform, new Vector3(transform.position.x, lastPlatform.transform.position.y + Random.RandomRange(1, 2f)), new Quaternion());
            }
            else {
                lastPlatform = Instantiate(platform, transform.position + new Vector3(0, Random.RandomRange(-2, -1f), 0), new Quaternion());
            }
            
            lastDistancePlatform = Random.RandomRange(8f, 10f);
            platformCount += 1;
            currentDistancePlatform = transform.position.x - lastPlatform.transform.position.x;
            if (platformCount % platform1Freq == 0)
            {
                lastPlatform.GetComponent<Platform>().shouldPlatformBlock = true;
            }
        }
        if (platformCount >= 12 && currentDistancePlatform >= 10) {
            platformCount = 0;
            currentDistancePlatform = 0;
            ChangeMode();
        }
    }

    public void Mode5Spawn()
    {
        currentDistancePlatform = transform.position.x - lastPlatform.transform.position.x;
        if (currentDistancePlatform >= lastDistancePlatform && platformCount < 12)
        {
            if (platformCount > 0)
            {
                lastPlatform = Instantiate(platform2, new Vector3(transform.position.x, lastPlatform.transform.position.y + Random.RandomRange(1f, 4f)), new Quaternion());
            }
            else
            {
                lastPlatform = Instantiate(platform2, transform.position + new Vector3(0, Random.RandomRange(-2, -1f), 0), new Quaternion());
            }
            lastDistancePlatform = Random.RandomRange(7.5f, 10f);
            platformCount += 1;
            currentDistancePlatform = transform.position.x - lastPlatform.transform.position.x;
            if (platformCount % platform2Freq == 0)
            {
                lastPlatform.GetComponent<Platform>().shouldPlatformBlock = true;
            }
        }
        if (platformCount >= 12 && currentDistancePlatform >= 10)
        {
            platformCount = 0;
            currentDistancePlatform = 0;
            ChangeMode();
        }
    }
}
