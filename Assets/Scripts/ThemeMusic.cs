using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    public static ThemeMusic instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {

            DontDestroyOnLoad(this);
            instance = this;
        }
    }
}
