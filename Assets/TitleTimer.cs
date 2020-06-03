using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTimer : timer
{
    [SerializeField] public GameObject clickAnywhere;
    [SerializeField] public float appearTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        if (currentTime > appearTime)
        {
            clickAnywhere.SetActive(true);
        }
    }
}
