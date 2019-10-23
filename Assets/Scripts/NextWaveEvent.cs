using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveEvent : MonoBehaviour
{
    public void NextWave()
    {
        GameManager.instance.SpawnNewWave();
        GameManager.instance.waveActive = true;
    }
}
