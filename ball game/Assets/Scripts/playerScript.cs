using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerScript : MonoBehaviour
{   

            private int scoreCounter = 49;
            private int levelremaning= 5;
            private int healthCounter=100;
            public Text ScoreText;
            public Text LevelReaminText;
            public Text HealthText;
            public GameObject level2;
            public GameObject level3;
            public GameObject level4;
            public GameObject levelfinal;
            public GameObject win;
            public GameObject lose;
            public Camera mycamera;
            public AudioClip pickSound;

    void FixedUpdate(){
        // creating varibles from unity represting the movement of the ball
        //GetAxis is found in Unity and inside it, it have horizontal and vertical that it can recognize it
        float moveHorizontal= Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");

        //this rigid body is used to add phycis to the ball so it doesn't fall of the plan
        Vector3 movement= new Vector3();
          movement.x=moveHorizontal; // x to move left or right
          movement.z=moveVertical; // z to move back or forth

    // that's a referece for rigidbody, GetComponent is used for any components added to the object
     
    // we called the object and added a method to make the ball move smoothly on the board

       Rigidbody rb = this.GetComponent<Rigidbody>();
       rb.AddForce (movement*1000*Time.deltaTime);

  //lose state if fell from the map
  if( this.transform.position.y < -2) // we chose the y-axis because we want to access the inwards and outward
                { 
                        lose.gameObject.SetActive(true);                
                }
             
    }
        //this function is used to override the default of Collider and when the ball passes over the cubs
        //it will check the tag of it, it's equal to  string "pickup"
        //then we access unity and make the block disapear and make the counter decresses everytime it disapears. 
    void OnTriggerEnter(Collider x){

        Rigidbody r = this.GetComponent<Rigidbody>(); // used to create object type Rigidbody from unity that was added from compenent
        //reference for the audiosource
        AudioSource s =  mycamera.GetComponent <AudioSource>(); //used to create object type AdioSorce from unity that was added from compenent

        if(x.tag =="pickup"){
            x.gameObject.SetActive(false);
            scoreCounter --;
            ScoreText.text= "Cubes Remaining: " + scoreCounter; //this is used to keep the text in the game updated while playing


                    //this is used to make sound while the ball eats the cubes    
                  
                s.PlayOneShot(pickSound); 
                //These if condtions to open the next level according to the score
                //will open level 2
                if(scoreCounter== 37){
                    level2.gameObject.SetActive(true);  
                    levelremaning --;
                    LevelReaminText.text = "Level Remaining: " + levelremaning;
                }
                //will open level three
                 else if(scoreCounter== 25){
                    level3.gameObject.SetActive(true);  
                    levelremaning --;
                    LevelReaminText.text = "Level Remaining: " + levelremaning;
                }
                //will open level four
               else if(scoreCounter== 13){
                    level4.gameObject.SetActive(true); 
                    levelremaning --; 
                    LevelReaminText.text = "Level Remaining: " + levelremaning;
                }
                //will open the final level five
                else if (scoreCounter == 1){
                    levelfinal.gameObject.SetActive(true); 
                    levelremaning --; 
                    LevelReaminText.text = "Final Level unlocked" ; 
                    LevelReaminText.color= Color.green;
                    
                  
                }
                  
        }
       

            //to check on the red block decrese by 40 each time it eats
        if(x.tag=="healthtag"){ 
            s.PlayOneShot(pickSound); 
            x.gameObject.SetActive(false);
            healthCounter-=40;
            if(healthCounter<=0){
                healthCounter=0;
            }
            HealthText.text= "Health: " +healthCounter+"%";   

        }
            //green platform
        if(x.tag=="finalPlatform")
           { 
            r.AddForce (0,500,0);

            }
            //that's after reaching the final level what will happen
            //wine state
            if(x.tag=="wintag")
           { 
               scoreCounter --;
               ScoreText.text= "Cubes Remaining: " + scoreCounter;
              x.gameObject.SetActive(false);
              s.PlayOneShot(pickSound);
              win.gameObject.SetActive(true); //only object no tag
              Time.timeScale=0;
            } 
            //lose state if health is finsished
              if(healthCounter == 0)
                { 
                    lose.gameObject.SetActive(true);
                     Time.timeScale=0;                      
                } 
             
          

    }

    
}
