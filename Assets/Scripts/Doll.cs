using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    public int turnbackdegree = -90;
    public Rigidbody rb;
    public GameObject player;
    public float nextActionTime = 3f;
    public bool startGame = false;
    public bool gameWin = false;
    public bool gameLose = false;
    public bool DollLookBack = false;
    public Transform dollLookforward;
    public Transform dollLookBack;
    public float period = 0.5f;
    private Vector3 playerWinPosition;
    public Rigidbody playerRb;
    public AudioClip greenLight;
    public AudioClip redLight;
    public AudioClip gunShot;
    private Vector3 lastPosition;
    public Transform playerTransform; 
    public bool playerMoving = false;
    public AudioSource themeSongs;
    
    

    //private object Vector3;

    // Start is called before the first frame update
    
    void Start()
    {
        startGame = false;
       // transform.rotation = Quaternion.Euler(0,-90,0);
        //playerWinPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
        
        rb = GetComponent<Rigidbody>();
        playerRb = GetComponent<Rigidbody>();
       // greenLight = GetComponents<AudioSource>().GreenLight_Clip;
       // redLight = GetComponents<AudioSource>().RedLight_Clip;
        themeSongs = GetComponent<AudioSource>();
        playerTransform = player.transform;
        lastPosition = playerTransform.position;
        playerMoving = false;
        
        // var player_LastPos = player.transform.position.x;
        //  var player_curPos= player.transform.position.x;




    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position != lastPosition)
        {
            playerMoving = true;
        }
        else
        {
            playerMoving = false;
        }

        lastPosition = playerTransform.position;


    }



    public void GameStart()
    {
        
         startGame = true;
         StartCoroutine("GamePlay");


    }
    public void GameWin()
    {
        Debug.Log("Game Won");
        //playerPosition
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator GamePlay()
    {
        while (startGame)
        {
            
            Debug.Log("The Coroutine is working");
            //Loop: Doll turns 90 degrees evey 5 secs & turn back to 90 degrees
            //Doll turns back and kill
            transform.rotation = Quaternion.Euler(0,90,0);
            themeSongs.clip = greenLight;
            themeSongs.Play();
            //greenLight.Play();
            //themeSongs.PlayOneShot(greenLight,0.7f);
            DollLookBack = false;
            Debug.Log("DollLookBack is false");
            yield return new WaitForSeconds(5.0f);
            transform.rotation = Quaternion.Euler(0,-90,0);
            themeSongs.clip = redLight;
            themeSongs.Play();
            //redLight.Play();
            //themeSongs.PlayOneShot(redLight,0.7f);
            DollLookBack = true;
            Debug.Log("DollLookBack is true");
            yield return new WaitForSeconds(5.0f);

            
            

            if (DollLookBack && playerMoving)
            {
                Debug.Log("You Die");
                Destroy(player,2f);
                
                Debug.Log("You lose the game");
                //corontine("GameOver");
                startGame = false;
                //greenLight.Pause();
               // redLight.Pause();
                break;

            }
            else

            {
                if (player.transform.position.x >= 56.5f)
                {
                    GameWin();
                    startGame = false;
                   // greenLight.Pause();
                   // redLight.Pause();
                    break;
                    Debug.Log("You Win");
                    
                }
            }


            

               
        }


    }


}

