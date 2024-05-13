using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpSpeed = 1f;
    private Camera _cam;
    private bool isJumping = false;
    private bool isDowning = false;
    private float jumpPower = 0;
    [SerializeField] private float jumpPowerPlus;
    private Rigidbody2D rb;
    [SerializeField] private Slider jumpPowerSlider;
    [SerializeField] private float jumpSpeedMin;
    [SerializeField] private float jumpSpeedMax;
    [SerializeField] private float jumpSpeedPlus;
    [SerializeField] private float jumpSpeedMinus;
    private Animator animator;
    [SerializeField] private float moveSpeedMinus;
    [SerializeField] private float moveSpeedPlus;
    [SerializeField] private float moveSpeedMax;
    [SerializeField] private float moveSpeedMin;
    private bool isRunning = false;
    [SerializeField] private AudioSource rideSource;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private float rideSoundPlus;
    private bool leftPressed = false;
    private bool rightPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        _cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        jumpSpeed = jumpSpeedMax;
        animator = GetComponent<Animator>();
        GameManager.playerPos = transform.position + new Vector3(0, 0, 0);
        GameManager.landY = -3f;
        GameManager.landed = true;
        //GameManager.player = this.gameObject;
    }


    private void Update()
    {
        if (GameManager.state == GameState.Ready)
        {
            if (Input.GetKey(KeyCode.Space) || rightPressed == true || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || leftPressed == true)
            {
                if (GameManager.adFlag == false)
                {
                    GameManager.UpdateGameState(GameState.Game);
                }

            }
        }
        if (GameManager.state == GameState.Game)
        {
            if (isJumping == false && isDowning == false)
            {
                if (rideSource.isPlaying == false)
                {
                    rideSource.Play();
                }
            }
            else
            {
                if (rideSource.isPlaying == true)
                {
                    if (rideSource.volume > 0f)
                    {
                        rideSource.volume -= rideSoundPlus * Time.deltaTime;
                    }
                    else
                    {
                        rideSource.Stop();
                        rideSource.volume = 0;
                    }

                }
            }
            GameManager.score = (int)transform.position.x;
            GameManager.isJumping = isJumping;
            GameManager.isDowning = isDowning;
            GameManager.playerSpeed = moveSpeed;
            if (jumpPower > 0 && isJumping == false && isDowning == false)
            {
                jumpPowerSlider.gameObject.SetActive(true);
            }
            else
            {
                jumpPowerSlider.gameObject.SetActive(false);
            }
            jumpPowerSlider.value = jumpPower;
            animator.SetBool("Jumping", isJumping);
            animator.SetBool("Downing", isDowning);
            animator.SetBool("Running", isRunning);
            if (isJumping == false && isDowning == false && jumpPower > 0)
            {
                animator.SetBool("Ready", true);
            }
            else
            {
                animator.SetBool("Ready", false);
            }
        }
        else
        {
            if (rideSource.isPlaying == true)
            {
                if (rideSource.volume > 0f)
                {
                    rideSource.volume -= rideSoundPlus * Time.deltaTime;
                }
                else
                {
                    rideSource.Stop();
                    rideSource.volume = 0;
                }

            }
            if (GameManager.state == GameState.Lose)
            {
                rideSource.Stop();
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.state == GameState.Game)
        {

            GameManager.playerPos = transform.position + new Vector3(0, 0, 0);
            _cam.transform.position = Vector3.Lerp(_cam.transform.position, new Vector3(transform.position.x + 2.5f, _cam.transform.position.y, _cam.transform.position.z), 0.5f);
            if (isJumping == false && isDowning == false)
            {
                _cam.transform.position = Vector3.Lerp(_cam.transform.position, new Vector3(_cam.transform.position.x, GameManager.landY + 2.6f, _cam.transform.position.z), 0.1f);
            }
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            JumpControls();
            SpeedControls();

        }
    }

    public void LeftButDown()
    {
        leftPressed = true;
    }

    public void LeftButUp()
    {
        leftPressed = false;
    }

    public void RightButDown()
    {
        rightPressed = true;
    }

    public void RightButUp()
    {
        rightPressed = false;
    }

    public void SpeedControls()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || leftPressed == true)
        {
            if (isJumping == false && isDowning == false)
            {
                if (rideSource.volume < 0.25f)
                {
                    rideSource.volume += rideSoundPlus * Time.deltaTime;
                }
                else
                {
                    rideSource.volume = 0.25f;
                }
            }
            else
            {

            }
            isRunning = true;
            if (moveSpeed < moveSpeedMax)
            {
                moveSpeed += moveSpeedPlus * Time.deltaTime;
            }
            else
            {
                moveSpeed = moveSpeedMax;
            }
        }
        else
        {
            if (isJumping == false && isDowning == false)
            {
                if (rideSource.volume < 0.05f)
                {
                    rideSource.volume += rideSoundPlus * Time.deltaTime;
                }
                else
                {
                    if (rideSource.volume > 0.1f)
                    {
                        rideSource.volume -= rideSoundPlus * Time.deltaTime;
                    }
                    else
                    {

                        rideSource.volume = 0.1f;

                    }
                }

            }

            isRunning = false;
            if (moveSpeed > moveSpeedMin)
            {
                moveSpeed -= moveSpeedMinus * Time.deltaTime;
            }
            else
            {
                moveSpeed = moveSpeedMin;
            }
        }
    }

    public void JumpControls()
    {
        /*if (transform.position.y < -3.85 && rb.velocity.y <0) {
            isJumping = false;
        }*/

        if (isJumping == true)
        {
            GameManager.landed = false;
            if (jumpSpeed > jumpSpeedMin)
            {
                transform.position += new Vector3(0, jumpSpeed, 0) * Time.deltaTime;
                if (jumpSpeed > jumpSpeedMin)
                {
                    jumpSpeed -= jumpSpeedPlus * Time.deltaTime;
                }
                if (GameManager.landY + jumpPower * 7 - transform.position.y < 0.5f)
                {
                    //jumpSpeed = jumpSpeedMin;
                }
            }
            else
            {
                isJumping = false;
                isDowning = true;
                jumpSpeed = jumpSpeedMin;
            }
        }
        else
        {
            if (GameManager.landed == false)
            {
                isDowning = true;
                GameManager.landY = -10;
            }
        }
        if (isDowning == true)
        {
            if (GameManager.landed == false)
            {
                //GameManager.landY = -10;
            }
            else
            {
                //GameManager.landY = GameManager.landYChanged;
            }
            if (transform.position.y > GameManager.landY)
            {
                transform.position -= new Vector3(0, jumpSpeed, 0) * Time.deltaTime;
                if (jumpSpeed < jumpSpeedMax)
                {
                    jumpSpeed += jumpSpeedMinus * Time.deltaTime;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, GameManager.landY, transform.position.z);
                isDowning = false;
                jumpPower = 0;
                audioSource.PlayOneShot(landSound, 0.25f);
            }
        }
        if (Input.GetKey(KeyCode.Space) || rightPressed == true)
        {
            if (isDowning == false)
            {



                jumpSpeedPlus = 5f;
                if (isJumping == false)
                {
                    audioSource.PlayOneShot(jumpSound, 0.5f);
                    jumpSpeed = jumpSpeedMax;
                    jumpPower = 1;
                }
                isJumping = true;
                //
                //rb.AddForce( new Vector2(0, jumpPower * 600));
                //jumpPower = 0;
            }
        }
        else
        {
            if (isJumping == true)
            {
                //jumpPower = (float)(transform.position.y - GameManager.landY) / 7f;
                if ((transform.position.y - GameManager.landY + jumpPower * 7 > 1))
                {
                    jumpSpeed = jumpSpeedMin;
                }

            }

        }
    }
}
