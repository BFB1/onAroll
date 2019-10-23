using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispose : MonoBehaviour
{
    // Henda byssukúlum fyrir performance
    
    public float wait = 30f;

    private void Awake()
    {
        StartCoroutine(StartDisposal());
    }

    private IEnumerator StartDisposal()
    {
        yield return new WaitForSeconds(wait);
        Destroy(gameObject);
    }
}
