using Assets.Scripts.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{

    enum ScreenType 
    {
        IdentificationTypeChoiceMenu,
        RegistrationMenu,
        AuthorisationMenu,
        MainMenu,
        BaseAlphaScreen,
        MatchingScreen,
        GameScreen
        
    }

    class ApplicationView : Singleton<ApplicationView>
    {

        MenuCanvasManager menuCanvasManager;
        


        override protected void Awake()
        {
            base.Awake();
            menuCanvasManager = MenuCanvasManager.GetInstance();
        }

        public void ShowErrorMessage(String message)
        {
            ((ErrorCanvasController)menuCanvasManager.GetCanvasControllerByType(MenuCanvasType.ErrorMessageMenu)).SetErrorMessage(message);
            menuCanvasManager.ShowError();
        }

        public void CloseErrorMessage()
        {
            menuCanvasManager.CloseError();
        }

        public void OpenScreen(ScreenType screenType)
        {
            switch (screenType)
            {
                case ScreenType.IdentificationTypeChoiceMenu:
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                    break;

                case ScreenType.RegistrationMenu:
                    menuCanvasManager.OpenCanvas(MenuCanvasType.RegistrationMenu);
                    break;

                case ScreenType.MatchingScreen:
                    Debug.Log("Openeing MatchingScreen");
                    menuCanvasManager.DisableMenu();
                    SceneManager.LoadScene(2, LoadSceneMode.Single);
                    break;

                case ScreenType.AuthorisationMenu:
                    menuCanvasManager.OpenCanvas(MenuCanvasType.AuthorisationMenu);
                    break;

                case ScreenType.MainMenu:
                    Debug.Log("Openeing Main Menu");
                    if (SceneManager.GetActiveScene().buildIndex != 0)
                        SceneManager.LoadScene(0, LoadSceneMode.Single);


                    menuCanvasManager.OpenCanvas(MenuCanvasType.MainMenu);
                    break;

                case ScreenType.BaseAlphaScreen:
                    SceneManager.LoadScene(1, LoadSceneMode.Single);
                    break;

                case ScreenType.GameScreen:
                    //SceneManager.LoadScene(3);
                    break;
            }
        } 


        private void SwitchScene()
        {

        }


    }
}
