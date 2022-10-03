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
    }

    // Update is called once per frame
    void Update()
    {
        float time = microgameJamController.GetTimer();
        if (paper.isPlatypusOnScreen && explosionUpdate < totalAnimationFrames && lastUpdateTime-time > 0.08)
        {
            lastUpdateTime = time;
            if(explosionUpdate<frames.Length){
                spriteRender.sprite = frames[explosionUpdate];
                explosionUpdate++;
            }
        }
    }
}
