using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float patDistance;

    public float xBoundLeft;
    public float xBoundRight;
    public float yBound;

    public GameObject paper;
    public bool canPat;


    // Start is called before the first frame update
    void Start()
    {
        patDistance = 1.5f;
        speed = 10;
        xBoundLeft = -6;
        xBoundRight = 13;
        yBound = 5;
        canPat = false;

        paper = GameObject.Find("Paper");
        GameObject.Find("MicrogameJamController").GetComponent<MicrogameJamController>().SetMaxTimer(15);

    }

    // Update is called once per frame
    void Update()
    {
        //for movement, make sure it doesn't go outside screen
        if(transform.position.x >=xBoundLeft && transform.position.x<=xBoundRight){
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        
        if(transform.position.y >= -yBound && transform.position.y <= yBound){
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        }
       
        //patting
        if(Input.GetKeyDown(KeyCode.Space)){
            if(paper.GetComponent<PlatypusManager>().isPlatypusOnScreen == false){
             transform.Translate(new Vector3(0,-patDistance, 0));
            }
             if(paper.GetComponent<PlatypusManager>().isPlatypusOnScreen == true){
             transform.Translate(new Vector3(patDistance,0, 0));
            }
            if(canPat){
                paper.GetComponent<PlatypusManager>().UpdatePats(1);
                Debug.Log(paper.GetComponent<PlatypusManager>().pats);
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)){

            if(paper.GetComponent<PlatypusManager>().isPlatypusOnScreen == false){
             transform.Translate(new Vector3(0,patDistance, 0));
            }
             if(paper.GetComponent<PlatypusManager>().isPlatypusOnScreen == true){
             transform.Translate(new Vector3(-patDistance,0, 0));
            }

        }
    }

    //when hand coll
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Paper")){
            canPat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Paper")){
            canPat = false;
        }
    }

    
}
