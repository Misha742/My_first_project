﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public float FillSpeed = 0.5f;
    private float targetProgress = 0;
    public float FinishBar = 0f;
    private float full;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        full = slider.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != targetProgress)
            slider.value = targetProgress;
    
        if (slider.value == full) 
            slider.value = 0;
    }
    public void IncrementProgress( float newProgress)
    {
        targetProgress = newProgress;
    }
}
