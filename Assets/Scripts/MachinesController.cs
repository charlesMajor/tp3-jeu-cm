using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinesController : MonoBehaviour
{
    private JimmyController controller;
    private GameObject currentUsableMachine = null;
    private GameObject currentUsableTrashcan = null;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<JimmyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentUsableMachine != null)
        {
            if (currentUsableMachine.tag == "Coffee Machine")
            {
                manageCoffeeMachine();
            }
        }

        if (currentUsableTrashcan != null)
        {
            manageTrashcan();
        }
    }

    private void manageCoffeeMachine()
    {
        CoffeeMachineManager manager = currentUsableMachine.GetComponent<CoffeeMachineManager>();

        if (Input.GetButtonDown("Use"))
        {
            controller.setHasCoffee(manager.useCoffeeMachine());
        }
    }

    private void manageTrashcan()
    {
        TrashcanManager manager = currentUsableTrashcan.GetComponent<TrashcanManager>();

        if (Input.GetButtonDown("Use"))
        {
            if (controller.getHasCoffee())
            {
                controller.setHasCoffee(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coffee Machine")
        {
            if (!controller.getHasCoffee())
            {
                if (currentUsableMachine != null)
                {
                    currentUsableMachine.GetComponent<CoffeeMachineManager>().setCoffeeMachineToNotUsable();
                }
                currentUsableMachine = collision.gameObject;
                currentUsableMachine.GetComponent<CoffeeMachineManager>().setCoffeeMachineToUsable();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coffee Machine")
        {
            if (currentUsableMachine != null)
            {
                currentUsableMachine.GetComponent<CoffeeMachineManager>().setCoffeeMachineToNotUsable();
                currentUsableMachine = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trashcan")
        {
            if (currentUsableTrashcan != null)
            {
                currentUsableTrashcan.GetComponent<TrashcanManager>().setTrashcanToNotUsable();
            }
            currentUsableTrashcan = collision.gameObject;
            currentUsableTrashcan.GetComponent<TrashcanManager>().setTrashcanToUsable();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trashcan")
        {
            if (currentUsableTrashcan != null)
            {
                currentUsableTrashcan.GetComponent<TrashcanManager>().setTrashcanToNotUsable();
                currentUsableTrashcan = null;
            }
        }
    }
}
