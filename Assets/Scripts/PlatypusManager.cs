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
    public Sprite []phases;
    public SpriteRenderer spriteRender;
    private int spriteOffset;
    // How many times all the images in a phase are cycled through before moving on to the next phase
    public int cyclesPerPhase;
    // How many sprites are cycled through within a phase
    public int spritesPerCycle;
    private int patsPerPhase;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>().SetMaxTimer(15);
        spriteRender = GameObject.Find("Paper").GetComponent<SpriteRenderer>();
        pats = 0;
        patsPerPhase = cyclesPerPhase * spritesPerCycle;
    }

    // Update is called once per frame
    void Update()
    {
        if(pats >= winCondition){
           //play platypus explsion animation

        }

        timeText.text = "Time: " +GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>().GetTimer();

    }
    public void UpdatePats(int patsToAdd){
        pats++;
        patText.text = "Pats: " + pats;
        if (pats>1 && pats%patsPerPhase==1) spriteOffset ++;
        spriteRender.sprite = phases[(pats)%3+spriteOffset];
    }
}
