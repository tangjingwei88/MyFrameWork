using UnityEngine;
using System.Collections;

public class LoginGame : MonoBehaviour {

    public LoadingScenePanel theLoadingScenePanel;


    public void OnLoginBtnClick()
    {
        LoadingManager.Instance.StartLoadScence("MainScence");
        //theBlackScreenPanel.WaitingLoadingScence("MainScence");
    }




}
