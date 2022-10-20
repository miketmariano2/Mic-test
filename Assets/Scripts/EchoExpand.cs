using System.Collections;
using UnityEngine;

public class EchoExpand : MonoBehaviour
{
    [SerializeField] static float initSize = 1f;
    private Vector3 maxSize;
    [SerializeField] float sonarSpeed = .4f;
    private void Start()
    {
        transform.localScale = new Vector3(initSize, initSize, initSize);
        StartCoroutine(Expand());
        // print(maxSize);
    }

    //contnineus to expand echolocation wave till reached the sound capacity, and promptly deletes self for time management
    IEnumerator Expand()
    {
        while (transform.localScale.x <= maxSize.x)
        {
            transform.localScale += new Vector3(sonarSpeed, sonarSpeed, sonarSpeed) * Time.deltaTime;
            // print("expanding");
            yield return null;
        }
        Destroy(this.gameObject);
    }

    public void SetMaxScale(float m)
    {
        //print("set size to " + m);
        maxSize = new Vector3(m,m,m);
    }

}

