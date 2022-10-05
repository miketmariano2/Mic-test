using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    public Vector3  minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 50;
    public float threshold = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        threshold *=10;
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        if(loudness < threshold)
        {
            loudness = 0;
            Debug.Log("caught");
        }else{
            Debug.Log(loudness);
        }
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness/10);
    }
}
