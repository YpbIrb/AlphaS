using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class GameManager : MonoBehaviour
{
    public enum ModelType
    {
        Placebo,
        EEG
    }
    
    private float timeRemaining = 30F;
    private float timeToMatching;
    private const float MatchingTime = 5F;


    [SerializeField]
    private List <AirplaneModel> planes;
    
    private List <BaseAirplaneController> planeControllers;

    public ModelType modelType;
  
    void Start()
    {
        Debug.Log("Matching started");
        timeToMatching = MatchingTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0) {
            //Debug.Log("Remaining time"+timeRemaining);
            timeRemaining-=Time.deltaTime;
        } 
        if(timeRemaining <= 0) { 
             GameOver(); 
        }

         //Debug.Log("RightPlane position:" + planeR.transform.position[1]);
         //Debug.Log("LeftPlane position:" + planeL.transform.position[1]);

         if((planes[1].transform.position[1] - planes[0].transform.position[1]) < 0.5){
            timeToMatching-=Time.deltaTime; 
            if(timeToMatching <= 0){
                GameOver();
            }
        }
        else{
            timeToMatching = MatchingTime;
        }

    }

    void Awake()
    {
        /*foreach (var plane in planes)
        {
            switch (modelType)
            {
                case ModelType.Placebo:
                    plane.controller = new PlaceboController();
                    break;
                default:
                    plane.controller = new EEGController();
                    break;
            } 
            planeControllers.Add(plane.controller);
        }*/
    }

    void GameOver()
    {
        //Time.timeScale = 0;
        Debug.Log("Game over");
        planeControllers.Clear();
        ApplicationController.GetInstance().OnMatchingFinish();
    }


}
