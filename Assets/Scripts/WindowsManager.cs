using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    private bool controlsWindowOpened = false;
    private bool commandsWindowOpened = false;

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text controlsText;
    [SerializeField] private TMP_Text commandsText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        manageControlsWindow();
        manageCommandsWindow();
    }

    private void manageControlsWindow()
    {
        if (Input.GetButtonDown("Controls Window"))
        {
            if (!controlsWindowOpened && !commandsWindowOpened)
            {
                controlsWindowOpened = true;
                panel.SetActive(true);
                controlsText.enabled = true;
            }
            else if (controlsWindowOpened)
            {
                controlsWindowOpened = false;
                panel.SetActive(false);
                controlsText.enabled = false;
            }
        }
    }

    private void manageCommandsWindow()
    {
        if (Input.GetButtonDown("Commands Window"))
        {
            if (!commandsWindowOpened && !controlsWindowOpened)
            {
                commandsWindowOpened = true;
                panel.SetActive(true);
                commandsText.enabled = true;
            }
            else if (commandsWindowOpened)
            {
                commandsWindowOpened = false;
                panel.SetActive(false);
                commandsText.enabled = false;
            }
        }
    }
}
