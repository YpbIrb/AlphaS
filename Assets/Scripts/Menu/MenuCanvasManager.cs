using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




namespace Assets.Scripts.Menu
{
    public enum MenuCanvasType
    {
        IdentificationTypeChoiceMenu,
        RegistrationMenu,
        AuthorisationMenu,
        MainMenu
    }



    public class MenuCanvasManager : Singleton<MenuCanvasManager>
    {

        List<CanvasController> canvasControllerList;
        CanvasController lastActiveCanvas;

        protected override void Awake()
        {
            base.Awake();
            canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
            canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
            SwitchCanvas(MenuCanvasType.IdentificationTypeChoiceMenu);
        }

        public void SwitchCanvas(MenuCanvasType _type)
        {
            if (lastActiveCanvas != null)
            {
                lastActiveCanvas.gameObject.SetActive(false);
            }

            CanvasController desiredCanvas = canvasControllerList.Find(x => x.menuCanvasType == _type);
            if (desiredCanvas != null)
            {
                desiredCanvas.gameObject.SetActive(true);
                lastActiveCanvas = desiredCanvas;
            }
            else { Debug.LogWarning("The desired canvas was not found!"); }
        }

        public CanvasController GetCanvasControllerByType(MenuCanvasType _type)
        {
            CanvasController desiredCanvas = canvasControllerList.Find(x => x.menuCanvasType == _type);
            if (desiredCanvas != null)
            {
                return desiredCanvas;
            }
            else
            {

                Debug.LogWarning("The desired canvas was not found!");
                return null;
            }
        }

    }
}