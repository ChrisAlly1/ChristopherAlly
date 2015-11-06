using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("path"), "time", 60.0f, "easetype", iTween.EaseType.easeInOutSine, "oncomplete", "setPosAndSpeed", "oncompletetarget", gameObject));



    }
   
}
