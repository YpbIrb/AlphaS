using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EEGProcessing;

public class EEGController : BaseAirplaneController
{
    //Временная затычка
    private IEEGHandler handler;

    public EEGController ()
    {
        handler = new OpenVibeEEGHandler();
    }
    public float GetValue()
    {
        return handler.GetCurrValue();
    }
}
