using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimmyAnimator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private Sprite baseSpriteCoffee;
    [SerializeField] private Sprite[] runAnimation;
    [SerializeField] private Sprite[] runAnimationCoffee;
    [SerializeField] private Sprite[] rollAnimation;
    private int currentRunSpriteIndex = -1;
    private int currentRollSpriteIndex = -1;
    private float timeBetweenSpriteChange = 0.2f;
    private float timeBetweenRollSpriteChange = 0.05f;
    private float timeSinceLastSpriteChange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animateRun(bool hasCoffee)
    {
        timeSinceLastSpriteChange += Time.deltaTime;
        if (timeSinceLastSpriteChange >= timeBetweenSpriteChange)
        {
            if (currentRunSpriteIndex == -1)
            {
                currentRunSpriteIndex = 0;
            }
            else if (currentRunSpriteIndex == runAnimation.Length - 1)
            {
                currentRunSpriteIndex = 0;
            }
            else
            {
                currentRunSpriteIndex++;
            }

            if (hasCoffee)
            {
                spriteRenderer.sprite = runAnimationCoffee[currentRunSpriteIndex];
            }
            else
            {
                spriteRenderer.sprite = runAnimation[currentRunSpriteIndex];
            }
            timeSinceLastSpriteChange = 0;
        }
    }

    public bool animateRoll()
    {
        timeSinceLastSpriteChange += Time.deltaTime;
        if (timeSinceLastSpriteChange >= timeBetweenRollSpriteChange)
        {
            if (currentRollSpriteIndex == -1)
            {
                currentRollSpriteIndex = 0;
            }
            else if (currentRollSpriteIndex == rollAnimation.Length - 1)
            {
                currentRollSpriteIndex = -1;
                return false;
            }
            else
            {
                currentRollSpriteIndex++;
            }
            spriteRenderer.sprite = rollAnimation[currentRollSpriteIndex];
            timeSinceLastSpriteChange = 0;
        }  
        return true;
    }

    public void stopped(bool hasCoffee)
    {
        if (hasCoffee)
        {
            spriteRenderer.sprite = baseSpriteCoffee;
        }
        else
        {
            spriteRenderer.sprite = baseSprite;
        }
        
        timeSinceLastSpriteChange = 0;
        currentRunSpriteIndex = -1;
    }
}
