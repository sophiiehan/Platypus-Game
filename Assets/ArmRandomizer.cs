using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRandomizer : MonoBehaviour
{
    public Sprite []arms;

    // Start is called before the first frame update
    void Start()
    {
        int armSelect = (int)(Random.value*3);
        Sprite sprite = GameObject.Find("Hand").GetComponent<SpriteRenderer>().sprite;
        sprite = arms[armSelect];
    }

}
