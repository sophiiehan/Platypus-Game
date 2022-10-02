using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlatypusManager : MonoBehaviour
{
    public int pats;
    public int winCondition;
    public TextMeshProUGUI patText;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>().SetMaxTimer(15);
        pats = 0;
        winCondition = 14;
    }

    // Update is called once per frame
    void Update()
    {
        if(pats >=15){
           //play platypus explsion animation
        }

        timeText.text = "Time: " +GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>().GetTimer();

    }
    public void UpdatePats(int patsToAdd){
        pats++;
        patText.text = "Pats: " + pats;

    }
   
}
