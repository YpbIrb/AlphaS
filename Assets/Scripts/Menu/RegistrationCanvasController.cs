using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;
using TMPro;

namespace Assets.Scripts.Menu
{
    public class RegistrationCanvasController : CanvasController
    {
        [SerializeField]
        GameObject BirthDateInputField;

        [SerializeField]
        GameObject BirthCountryInputField;

        [SerializeField]
        GameObject BirthCityInputField;

        [SerializeField]
        GameObject GenderDropdown; 


        protected void Awake()
        {  
            Debug.Log("In Awake in RegistrationCanvasController");
            this.menuCanvasType = MenuCanvasType.RegistrationMenu;
        }

        public RegistrationInfo GetRegistrationInfo()
        {
            /*
            if(BirthCityInputField != null)
            {
                Debug.Log("BirthCityInputField NOT null");
            }
            else
            {
                Debug.Log("BirthCityInputField IS null");
            }

            

            Debug.Log(BirthCityInputField.GetType());

            TextMeshProUGUI text = BirthCityInputField.GetComponent<TextMeshProUGUI>();
            if (!text) Debug.Log("There is no such component on the object!");
            else
            {
                Debug.Log("There is TextMeshProUGUI component on the object!");
            }

            Debug.Log(BirthCityInputField.GetComponent<TextMeshProUGUI>().text);
            */

            TMP_Dropdown dropdown = GenderDropdown.GetComponent<TMP_Dropdown>();
            

            RegistrationInfo res = new RegistrationInfo(GenderDropdown.GetComponent<TMP_Dropdown>().captionText.text, new System.DateTime(), BirthCityInputField.GetComponent<TextMeshProUGUI>().text, BirthCountryInputField.GetComponent<TextMeshProUGUI>().text) ;



            return res;
        }


    }
}