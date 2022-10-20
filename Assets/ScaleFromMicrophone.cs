using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaleFromMicrophone : MonoBehaviour
{
    // public AudioSource source;
    // public Vector3  minScale;
    // public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 50;
    public float threshold = 1.0f;
    private float total = 0;
    private int counter = 1;
    private static GameObject prefab;
    private bool expanding = false;
    // Start is called before the first frame update
    void Start()
    {
        threshold *=10;
        prefab = Resources.Load<GameObject>("EchoRing");
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        int sound = (int)loudness;
        loudness = (float)sound;
        if(loudness < threshold)
        {
            loudness = 0;
            // Debug.Log("caught");
        }else{
            // Debug.Log(loudness);
        }
        total += loudness;
        counter +=1;
        // if(counter == 30){
        //     loudness = total/30;
        //     Debug.Log("loudness");
        //     // transform.localScale = Vector3.Lerp(minScale, maxScale, loudness/10);
        //     if(loudness > 0){
        //         Instantiate(prefab, gameObject.transform.position, Quaternion.identity).GetComponent<EchoExpand>().SetMaxScale(loudness);
        //     }
        //     counter = 1;
        //     total = 0;
        // }else{
        //     Debug.Log("pass");
        // }
        if(loudness > 0 && !expanding){
            expanding = true;
            if(loudness > 20){
                Debug.Log("20");
                StartCoroutine(echo(0));
                StartCoroutine(echo(1));
                StartCoroutine(echo(2));
                StartCoroutine(setExpanding(3));
            }
            else if(loudness > 10){
                Debug.Log("10");
                StartCoroutine(echo(0));
                StartCoroutine(echo(1));
                StartCoroutine(setExpanding(2));
            }
            else{
                Debug.Log("00");
                StartCoroutine(echo(0));
                StartCoroutine(setExpanding(1));
            }
        }
    }

    IEnumerator echo(int secs){
        yield return new WaitForSeconds(secs);
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity).GetComponent<EchoExpand>().SetMaxScale(20);
    }

    IEnumerator setExpanding(int level){
        yield return new WaitForSeconds(19 + level);
        expanding = false;
    }
}
