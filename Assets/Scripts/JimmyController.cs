using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JimmyController : MonoBehaviour
{
    private Vector3 inputsVector;
    private Vector3 moveVector;
    private float jimmySpeed = 5f;
    private Rigidbody2D rb;

    [SerializeField] private bool hasCoffee = false;
    private JimmyAnimator animator;

    private bool canRoll;
    private float timeBetweenRolls = 1.5f;
    private float timeSinceLastRoll = 0;
    private bool isInRollingAnimation = false;
    private Vector3 directionInRoll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<JimmyAnimator>();
        timeSinceLastRoll = timeBetweenRolls;
    }

    // Update is called once per frame
    void Update()
    {
        buildMovement();
        invert();
    }

    private void buildMovement()
    {
        timeSinceLastRoll += Time.deltaTime;
        if (timeSinceLastRoll >= timeBetweenRolls && !hasCoffee)
        {
            canRoll = true;
        }
        else
        {
            canRoll = false;
        }

        inputsVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (isInRollingAnimation)
        {
            moveVector =  directionInRoll * 2.5f;
        }
        else
        {
            moveVector = inputsVector;
        }
        rb.velocity = moveVector * jimmySpeed;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetAxisRaw("Roll") != 0 && canRoll)
            {
                isInRollingAnimation = true;
                timeSinceLastRoll = 0;
                directionInRoll = inputsVector;
            }

            if (!isInRollingAnimation)
            {
                animator.animateRun(hasCoffee);
            }

        }
        else if (!isInRollingAnimation)
        {
            animator.stopped(hasCoffee);
        }

        if (isInRollingAnimation)
        {
            isInRollingAnimation = animator.animateRoll();
        }
    }

    private void invert()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal < 0)
        {
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            sprite.flipX = false;
        }
    }

    public float getTimeUntilNextRoll()
    {
        float timeUntilNextRoll = timeBetweenRolls - timeSinceLastRoll;
        if (timeUntilNextRoll < 0)
        {
            timeUntilNextRoll = 0;
        }

        if (hasCoffee)
        {
            timeUntilNextRoll = timeBetweenRolls;
        }

        return timeUntilNextRoll;
    }

    public float getTimeBetweenRolls()
    {
        return timeBetweenRolls;
    }

    public bool getHasCoffee()
    {
        return this.hasCoffee;
    }

    public void setHasCoffee(bool hasCoffee)
    {
        this.hasCoffee = hasCoffee;
    }
}
