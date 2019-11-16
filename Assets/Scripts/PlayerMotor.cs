using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor Instance { get; set; }

    private const float LANE_DISTANCE = 4.0f;
    private const float TURN_SPEED = 0.05f;

    public GameObject mainPanel, gameUI;
    //
    public bool isRun = false;

    // Animation
    private Animator anim;

    // Movement
    private CharacterController controller;
    private float jumpforce = 8.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;

    private int desiredLane = 1; //0 = Left, 1 = Middle, 2 = Right

    // Speed Modifier
    private float originalSpeed = 14.0f;
    private float speed;
    private float speedIncreaseLastTick;
    public float speedIncreaseTime = 2.5f;
    private float speedIncreaseAmount = 0.1f;

    private Vector3 moveVector;
    public float gameTime = 60f;

    public TextMeshProUGUI gameTimeText;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        speed = originalSpeed;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //Debug.Log(isRunning);


    }

    private void FixedUpdate()
    {
            gameTime -= Time.deltaTime;
            gameTimeText.text = (gameTime).ToString("00.00");
            if (gameTime <= 0)
            {
                isRun = false;
                Crash();
            }       

            if (Time.time - speedIncreaseLastTick > speedIncreaseTime)
            {
                speedIncreaseLastTick = Time.time;
                speed += speedIncreaseAmount;
                GameManager.Instance.UpdateModifier(speed - originalSpeed);
            }


            anim.SetBool("Running", true);
            // Gather the inputs on which we should be
            if (MobileInput.Instance.SwipeLeft)
                MoveLane(false);
            if (MobileInput.Instance.SwipeRight)
                MoveLane(true);


            // Calculate where we should be in the future
            Vector3 targetPosition = transform.position.z * Vector3.forward;
            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * LANE_DISTANCE;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * LANE_DISTANCE;
            }

            // Lets Calculate our move delta
            moveVector = Vector3.zero;

            moveVector.x = (targetPosition - transform.position).normalized.x * speed;

            bool isGrounded = IsGrounded();
            anim.SetBool("Grounded", isGrounded);

            // Calculate Y
            if (isGrounded) // if Grounded
            {
                verticalVelocity = -0.1f;
                if (MobileInput.Instance.SwipeUp)
                {
                    
                    // Jump
                    anim.SetTrigger("Jump");
                    verticalVelocity = jumpforce;
                    //moveVector.y = 20.0f;
                }
                else if (MobileInput.Instance.SwipeDown)
                {
                    // Slide
                    StartSlidng();
                    Invoke("StopSliding", 1.0f);
                }
            }
            else
            {
                verticalVelocity -= (gravity * Time.deltaTime);


                // Fast Falling Mechanic
                if (MobileInput.Instance.SwipeDown)
                {
                    verticalVelocity = -jumpforce;
                }
            }

            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            // Move the Player
            controller.Move(moveVector * Time.deltaTime);

            // Rotate the player
            Vector3 dir = controller.velocity;
            if (dir != Vector3.zero)
            {
                dir.y = 0;
                transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
            }

        

    }

    private void StartSlidng()
    {
        anim.SetBool("Sliding", true);
        controller.height /= 2;
        controller.center = new Vector3(controller.center.x, controller.center.y / 2, controller.center.z);

    }

    private void StopSliding()
    {
        anim.SetBool("Sliding", false);
        controller.height *= 2;
        controller.center = new Vector3(controller.center.x, controller.center.y * 2, controller.center.z);
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(
            new Vector3(controller.bounds.center.x,
            (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,
            controller.bounds.center.z),
            Vector3.down);

        

        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f);

        return (Physics.Raycast(groundRay, 0.2f + 0.1f));

    }

    public void Crash()
    {
        gameObject.SetActive(false);

        anim.SetTrigger("Death");
        mainPanel.SetActive(true);
        GameManager.Instance.IsDead = true;
        
        //DeadMenu.Instance.ToggleEndMenu();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Obstacle":
                Crash();
                break;
        }
    }
}
