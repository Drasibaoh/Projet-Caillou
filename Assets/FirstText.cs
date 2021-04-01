using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstText : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0f;
    }
    public void Click()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
