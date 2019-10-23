using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // Sjórnar ui hlutum
    
    public GameObject wavePanel;
    public TextMeshProUGUI waveCounter;
    public TextMeshProUGUI killCounter;

    private int m_WaveNumber;

    public int WaveNumber => m_WaveNumber;

    public static UiManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        killCounter.text = GameManager.instance.Score.ToString();
    }

    public void DisplayNextWaveUi()
    {
        waveCounter.text = "Wave " + ++m_WaveNumber;
        wavePanel.SetActive(true);
    }
}
