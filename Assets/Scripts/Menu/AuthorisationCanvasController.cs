using Assets.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



namespace Assets.Scripts.Menu
{

    public class AuthorisationCanvasController : CanvasController
    {
        [SerializeField]
        GameObject IDInputField;

        protected void Awake()
        {
            Debug.Log("In Awake in AuthorisationCanvasController");
            this.menuCanvasType = MenuCanvasType.AuthorisationMenu;
        }

        public AuthorisationInfo GetAuthorisationInfo()
        {
            return new AuthorisationInfo(IDInputField.GetComponent<TextMeshProUGUI>().text);
        }


    }
}