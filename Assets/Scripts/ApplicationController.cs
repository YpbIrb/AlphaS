
using Assets.Scripts.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;


namespace Assets.Scripts
{

    public class ApplicationController : Singleton<ApplicationController>
    {

        DataManager dataManager;
        MenuCanvasManager canvasManager;
        ApplicationView applicationView;

        protected override void Awake()
        {
            base.Awake();

            dataManager = DataManager.GetInstance();
            canvasManager = MenuCanvasManager.GetInstance();
            applicationView = ApplicationView.GetInstance();
            Debug.Log("App controller Awake");
        }


        public void OnNotification(Notification notification)
        {

            var res = 0;
            switch (notification)
            {
                case Notification.RegistrationChosen:
                    applicationView.OpenScreen(ScreenType.RegistrationMenu);
                    break;

                case Notification.RegistrationSend:
                    RegistrationCanvasController registrationCanvasController = (RegistrationCanvasController)canvasManager.GetCanvasControllerByType(MenuCanvasType.RegistrationMenu);
                    RegistrationRequest registrationInfo = registrationCanvasController.GetRegistrationInfo();
                    res = dataManager.Register(registrationInfo);
                    if (res != 0)
                    {

                    }

                    //var net_manager = AlphaSNetManager.GetInstance();
                    //https://localhost:5001/api/Participant
                    //net_manager.SendGet("https://localhost:5001/api/Participant");

                    applicationView.OpenScreen(ScreenType.MainMenu);
                    break;

                case Notification.AuthorisationChosen:
                    applicationView.OpenScreen(ScreenType.AuthorisationMenu);
                    
                    break;

                case Notification.AuthorisationSend:
                    AuthorisationCanvasController authorisationCanvasController = (AuthorisationCanvasController)canvasManager.GetCanvasControllerByType(MenuCanvasType.AuthorisationMenu);
                    AuthorisationRequest authorisationInfo = authorisationCanvasController.GetAuthorisationInfo();

                    res = dataManager.Login(authorisationInfo);
                    if (res != 0)
                    {

                    }
                    applicationView.OpenScreen(ScreenType.MainMenu);
                    break;


                case Notification.MatchingStart:
                    Debug.Log("Opening matching screen");
                    applicationView.OpenScreen(ScreenType.MatchingScreen);
                    break;

                case Notification.BaseAlphaStart:
                    applicationView.ShowErrorMessage("No base alpha ((");

                    Debug.Log(":AOSDkfjs;dlfkjad;rlrk");


                    //applicationView.OpenScreen(ScreenType.BaseAlphaScreen);
                    break;

                case Notification.GameStart:
                    applicationView.OpenScreen(ScreenType.GameScreen);
                    break;

                case Notification.MatchingFinish:
                    applicationView.OpenScreen(ScreenType.MainMenu);
                    break;

                case Notification.CloseError:
                    applicationView.CloseErrorMessage();
                    break;

                default:
                    break;
            }
        }


    }
}