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


    // Start is called before the first frame update
    void Start()
    {
        patDistance = 1.5f;
        speed = 10;
        xBoundLeft = -6;
        xBoundRight = 13;
        yBound = 5;

        paper = GameObject.Find("Paper");
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
            transform.Translate(new Vector3(0,-patDistance, 0));
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            transform.Translate(new Vector3(0,patDistance, 0));

        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag== "Paper"){
            paper.GetComponent<PlatypusManager>().pats++;
            Debug.Log(paper.GetComponent<PlatypusManager>().pats++);
        }
    }

    
}
