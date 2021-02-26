using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    class AlphaSNetManager : Singleton<AlphaSNetManager>
    {


        protected override void Awake()
        {
            base.Awake();


        }


        public void SendGet(string url)
        {
            //string url = "https://localhost:5001/api/Participant";
            StartCoroutine(GetRequest(url));
        }

        void SendPost(string url, string json)
        {
            StartCoroutine(PostRequest(url, json));
        }


        IEnumerator GetRequest(string uri)
        {
            UnityWebRequest uwr = UnityWebRequest.Get(uri);
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                UnityEngine.Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                UnityEngine.Debug.Log("Received: " + uwr.downloadHandler.text);
            }
        }

        IEnumerator PostRequest(string url, string json)
        {
            var uwr = new UnityWebRequest(url, "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");

            //Send the request then wait here until it returns
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                UnityEngine.Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                UnityEngine.Debug.Log("Received: " + uwr.downloadHandler.text);
            }
        }



    }
}
