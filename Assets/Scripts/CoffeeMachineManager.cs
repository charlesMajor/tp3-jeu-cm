using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineManager : MonoBehaviour
{
    [SerializeField] private bool isMakingCoffee = false;
    private bool hasCoffeeReady = false;
    private float timeToMakeCoffee = 2f;
    private float timeSinceCoffeeStarted = 0f;

    private float coffeeMachineBaseHeight;
    private float coffeeMachineMaxHeight;
    private float currentCoffeeMachineHeight;
    private bool isGrowing = true;
    private Color baseMachineColor;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        coffeeMachineBaseHeight = transform.lossyScale.y;
        coffeeMachineMaxHeight = coffeeMachineBaseHeight + 0.05f;
        currentCoffeeMachineHeight = coffeeMachineBaseHeight;

        baseMachineColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        manageMakingCoffeeAnimation();
    }

    private void manageMakingCoffeeAnimation()
    {
        if (isMakingCoffee)
        {
            setCoffeeMachineToNotUsable();
            if (isGrowing)
            {
                currentCoffeeMachineHeight += 0.0005f;
            }
            else
            {
                currentCoffeeMachineHeight -= 0.0005f;
            }

            if (currentCoffeeMachineHeight >= coffeeMachineMaxHeight)
            {
                isGrowing = false;
            }
            else if (currentCoffeeMachineHeight <= coffeeMachineBaseHeight)
            {
                isGrowing = true;
            }

            timeSinceCoffeeStarted += Time.deltaTime;
            if (timeSinceCoffeeStarted >= timeToMakeCoffee)
            {
                isMakingCoffee = false;
                sr.color = Color.green;
                timeSinceCoffeeStarted = 0f;
                hasCoffeeReady = true;
            }
        }
        else
        {
            currentCoffeeMachineHeight = coffeeMachineBaseHeight;
        }

        transform.localScale = new Vector3(transform.lossyScale.x, currentCoffeeMachineHeight);
    }

    public void setCoffeeMachineToUsable()
    {
        if (!hasCoffeeReady)
        {
            sr.color = Color.yellow;
        }
    }

    public void setCoffeeMachineToNotUsable()
    {
        if (!hasCoffeeReady)
        {
            sr.color = baseMachineColor;
        }
    }

    public bool useCoffeeMachine()
    {
        if (hasCoffeeReady)
        {
            hasCoffeeReady = false;
            setCoffeeMachineToNotUsable();
            return true;
        }
        else
        {
            isMakingCoffee = true;
            return false;
        }
    }
}
