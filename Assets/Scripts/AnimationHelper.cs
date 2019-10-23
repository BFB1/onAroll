using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    public void DisableGameObject()
    {
        // Þurfti skriftu til að geta notað þetta úr animation :(
        gameObject.SetActive(false);
    }
}
