using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimation : MonoBehaviour
{
    private PlatypusManager paper;
    private int explosionUpdate;
    private int totalAnimationFrames;
    private SpriteRenderer spriteRender;
    private float lastUpdateTime;
    private MicrogameJamController microgameJamController;
    public Sprite []frames;
    public AudioSource platypusSound;
    public bool playSound;

    // Start is called before the first frame update
    void Start()
    {
        paper = GameObject.Find("Paper").GetComponent<PlatypusManager>();
        spriteRender = GameObject.Find("background").GetComponent<SpriteRenderer>();
        microgameJamController = GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>();
        GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>().SetMaxTimer(15);
        lastUpdateTime = 10;
        explosionUpdate = 0;
        totalAnimationFrames = 8*10;
        platypusSound = GetComponent<AudioSource>();
        playSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        float time = microgameJamController.GetTimer();
        // if(paper.pats == paper.winningPatNumber){

      //  }
        if (time <= .1) {
            Debug.Log(paper.pats >= paper.winningPatNumber);
            if(paper.pats >= paper.winningPatNumber){
                microgameJamController.WinGame();
            }else{
                microgameJamController.LoseGame();
            }
        }
       
        if (paper.isPlatypusOnScreen && explosionUpdate < totalAnimationFrames && lastUpdateTime-time > 0.08)
        {
            playSoundMethod();
            lastUpdateTime = time;
            if(explosionUpdate<frames.Length){
                spriteRender.sprite = frames[explosionUpdate];
                explosionUpdate++;
            }
        } 
    }

    private void playSoundMethod(){
        if(playSound){
            platypusSound.Play();
        }
        playSound = false;
    }
}
