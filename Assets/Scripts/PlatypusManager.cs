using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatypusManager : MonoBehaviour
{
    public int pats;
    public int winCondition;
    // Start is called before the first frame update
    void Start()
    {
        pats = 0;
        winCondition = 14;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other) {
       Debug.Log("Collision");
        if (other.gameObject.CompareTag("Player")){
            pats++;
            Debug.Log(pats);
        }
    }
}
