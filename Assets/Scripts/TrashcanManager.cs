using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanManager : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color baseTrashcanColor;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        baseTrashcanColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTrashcanToUsable()
    {
        sr.color = Color.yellow;
    }

    public void setTrashcanToNotUsable()
    {
        sr.color = baseTrashcanColor;
    }
}
