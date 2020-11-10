using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshairHandler : MonoBehaviour
{
    public enum crosshairTypes
    {
        dot, hand
    };
    public crosshairTypes crosshairType;

    public Image crosshair;
    public Sprite hand;

    public Text FPS_Counter;

    public lightHandler lh;

    int m_frameCounter = 0;
    float m_timeCounter = 0.0f;
    float m_lastFramerate = 0.0f;
    public float m_refreshTime = 0.5f;

    void Start()
    {
        crosshairType = crosshairTypes.dot;
    }

    void Update()
    {
        if (m_timeCounter < m_refreshTime)
        {
            m_timeCounter += Time.deltaTime;
            m_frameCounter++;
        }
        else
        {
            m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            m_frameCounter = 0;
            m_timeCounter = 0.0f;
        }
        FPS_Counter.text = (int)m_lastFramerate + " FPS";
        switch(crosshairType)
        {
            case crosshairTypes.dot:
                crosshair.sprite = null;
                crosshair.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
                break;

            case crosshairTypes.hand:
                crosshair.sprite = hand;
                crosshair.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
    }
}
