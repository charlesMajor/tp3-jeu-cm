using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image rollImage;
    private float rollImageBaseHeight;
    [SerializeField] private GameObject jimmy;
    private JimmyController jimmyController;

    // Start is called before the first frame update
    void Start()
    {
        jimmyController = jimmy.GetComponent<JimmyController>();
        rollImageBaseHeight = rollImage.preferredHeight;
    }

    // Update is called once per frame
    void Update()
    {
        updateRollIcon();
        freezeTime();
        unfreezeTime();
    }

    private void updateRollIcon()
    {
        float newHeight = rollImageBaseHeight - (rollImageBaseHeight * jimmyController.getTimeUntilNextRoll() / jimmyController.getTimeBetweenRolls());
        RectTransform rectTransform = rollImage.rectTransform;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, newHeight);

        
        Color iconColor;

        if (jimmyController.getTimeUntilNextRoll() != 0)
        {
            iconColor = Color.white;
            iconColor.a = 1 - (1 * jimmyController.getTimeUntilNextRoll() / jimmyController.getTimeBetweenRolls());
        }
        else
        {
            iconColor = Color.green;
        }

        rollImage.color = iconColor;
    }

    public void freezeTime()
    {

    }

    public void unfreezeTime()
    {

    }
}
