using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlatypusManager : MonoBehaviour
{
    public int pats;
    public int winningPatNumber;
    // public TextMeshProUGUI patText;

    //checks if platypus is on screen
    public bool isPlatypusOnScreen;

    //public TextMeshProUGUI timeText;
    public Sprite []phases;
    private SpriteRenderer spriteRender;
    private int spriteOffset;
    // How many times all the images in a phase are cycled through before moving on to the next phase
    public int cyclesPerPhase;
    // How many sprites are cycled through within a phase
    public int spritesPerCycle;
    private int patsPerPhase;
    private MicrogameJamController microgameJamController;
    // Start is called before the first frame update
    void Start()
    {
        microgameJamController = GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>();
        // microgameJamController.SetMaxTimer(15);
        spriteRender = GameObject.Find("Paper").GetComponent<SpriteRenderer>();
        // pats = 0;
        patsPerPhase = cyclesPerPhase * spritesPerCycle;
        // winningPatNumber = 15;
        isPlatypusOnScreen = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        float time = microgameJamController.GetTimer();
        //timeText.text = "Time: " + time;
        if (pats >= winningPatNumber) {
            isPlatypusOnScreen = true;
            GameObject.Find("Paper").SetActive(false);
            //play paper explosion animation once
        }
    }

    public void UpdatePats(int patsToAdd){
        pats++;
        // patText.text = "Pats: " + pats;
        if (pats>1 && pats%patsPerPhase==1) spriteOffset ++;
        spriteRender.sprite = phases[(pats)%3+spriteOffset];
    }
}