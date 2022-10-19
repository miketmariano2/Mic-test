using UnityEngine;


//attaches to the point of contact that generates sound
//can have player -in game be a subclass of GenEcho with overriding the CalculateDecibel function
public class GenEcho : MonoBehaviour
{
    private static GameObject prefab;
    public float defDecible; //needs to be public in case player has collected an object that generates sound
    //public AudioClip associatedSound; //for an audioManager to play

    private void Awake()
    {
        prefab = Resources.Load<GameObject>("EchoRing");
    }
    void Update()
    {
        //some kind of trigger state, space for now, but dependent more on if an object has been interacted with etc.
        if (Input.GetKeyDown("m")) {
            Instantiate(prefab, gameObject.transform.position, Quaternion.identity).GetComponent<EchoExpand>().SetMaxScale(CalculateDecibel());
        }
    }


    //will also be where we calculate decibel from any in-game action
    //player based would check the player game state (walking, running, landing, tumbling, speaking etc) as well as if player has collectibles
    public virtual float CalculateDecibel()
    {
        //return defDecible;
        return Random.Range(7, 20);
    }
}
