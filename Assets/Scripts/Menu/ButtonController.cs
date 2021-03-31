using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Menu
{

    public enum ButtonType
    {
        IdentificationTypeChoice_Authorisation,
        IdentificationTypeChoice_Registration,
        Authorisation_Send,
        Registration_Send,
        Main_BaseAlpha_Start,
        Main_Assigment_Start,
        Main_Game_Start,
        Error_close
    }


    [RequireComponent(typeof(Button))]
    public class ButtonController : MonoBehaviour
    {
        public ButtonType buttonType;
        //public CanvasController canvasController;
        ApplicationController applicationController;
        MenuCanvasManager canvasManager;
        Button menuButton;

        private void Start()
        {
            menuButton = GetComponent<Button>();
            menuButton.onClick.AddListener(OnButtonClicked);
            canvasManager = MenuCanvasManager.GetInstance();
            applicationController = ApplicationController.GetInstance();
        }

        void OnButtonClicked()
        {

            switch (buttonType)
            {
                case ButtonType.IdentificationTypeChoice_Authorisation:
                    applicationController.OnNotification(Notification.AuthorisationChosen);
                    break;

                case ButtonType.IdentificationTypeChoice_Registration:
                    applicationController.OnNotification(Notification.RegistrationChosen);
                    break;

                case ButtonType.Authorisation_Send:
                    applicationController.OnNotification(Notification.AuthorisationSend);
                    break;

                case ButtonType.Registration_Send:
                    applicationController.OnNotification(Notification.RegistrationSend);
                    break;


                case ButtonType.Main_Assigment_Start:
                    applicationController.OnNotification(Notification.MatchingStart);
                    break;

                case ButtonType.Main_BaseAlpha_Start:
                    applicationController.OnNotification(Notification.BaseAlphaStart);
                    break;

                case ButtonType.Main_Game_Start:
                    applicationController.OnNotification(Notification.GameStart);
                    break;

                case ButtonType.Error_close:
                    applicationController.OnNotification(Notification.CloseError);
                    break;

                default:
                    break;
            }
        }
    }
}