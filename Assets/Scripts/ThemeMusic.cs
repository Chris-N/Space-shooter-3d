using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    public static ThemeMusic instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
