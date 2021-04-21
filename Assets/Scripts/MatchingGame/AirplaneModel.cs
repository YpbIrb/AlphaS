using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneModel : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private BaseAirplaneController _controller;
    public BaseAirplaneController controller
    {
        get => _controller;
        set => _controller = value;
    }

    public float height;
    public bool isRightPlane;

    void Start()
    {
        height = transform.localScale.y;
        controller = new EEGController();
        //Debug.Log(height + "\n");
    }

    void Update()
    {
        transform.Translate(controller.GetValue() * Vector2.up * Time.deltaTime * speed);
        /*if(isRightPlane){
            float move = Input.GetKey(KeyCode.UpArrow)? 1 : 0 ;
            move += Input.GetKey(KeyCode.DownArrow)? -1 : 0 ;
            transform.Translate(move * Vector2.up * Time.deltaTime * speed);
        }
        else{
            float move = Input.GetKey(KeyCode.W)? 1 : 0 ;
            move += Input.GetKey(KeyCode.S)? -1 : 0 ;
            transform.Translate(move * Vector2.up * Time.deltaTime * speed);
        }*/
    }

}
