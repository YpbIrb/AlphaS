using Assets.Scripts.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        AssigmentScreen,
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

        }

        public void OpenScreen(ScreenType screenType)
        {
            switch (screenType)
            {
                case ScreenType.IdentificationTypeChoiceMenu:
                    SceneManager.LoadScene(1);
                    break;

                case ScreenType.RegistrationMenu:
                    menuCanvasManager.SwitchCanvas(MenuCanvasType.RegistrationMenu);
                    break;

                case ScreenType.AssigmentScreen:
                    SceneManager.LoadScene(2);
                    break;

                case ScreenType.AuthorisationMenu:
                    menuCanvasManager.SwitchCanvas(MenuCanvasType.AuthorisationMenu);
                    break;

                case ScreenType.MainMenu:
                    if (SceneManager.GetActiveScene().buildIndex != 0)
                        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

                    menuCanvasManager.SwitchCanvas(MenuCanvasType.MainMenu);
                    break;

                case ScreenType.BaseAlphaScreen:
                    SceneManager.LoadScene(1);
                    break;

                case ScreenType.GameScreen:
                    SceneManager.LoadScene(3);
                    break;
            }
        } 


        private void SwitchScene()
        {

        }


    }
}
