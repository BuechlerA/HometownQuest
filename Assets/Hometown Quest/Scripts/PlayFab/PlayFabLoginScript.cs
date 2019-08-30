using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLoginScript : MonoBehaviour
{
    public InputField regUsername, regEmail, regPassword;
    public GameObject regPanel;
    public InputField loginUsername, loginPassword;
    public GameObject loginPanel;
    public Text errorText;

    public GUIManagerScript GUIManager;

    public void LoginUser()
    {
        var request = new LoginWithPlayFabRequest();
        request.TitleId = PlayFabSettings.TitleId;
        request.Username = loginUsername.text;
        request.Password = loginPassword.text;

        //send api request
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginResult, OnPlayFabError);
    }

    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest();
        request.TitleId = PlayFabSettings.TitleId;
        request.Username = regUsername.text;
        request.Email = regEmail.text;
        request.Password = regPassword.text;

        //send api request
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterResult, OnPlayFabError);

    }

    private void OnPlayFabError(PlayFabError obj)
    {
        Debug.Log(obj.Error.ToString());
        //errorText.text = obj.Error.ToString();

        string output = "";

        switch (obj.Error)
        {
            case PlayFabErrorCode.InvalidParams:
                output = "Bitte alle Felder ausfüllen!";
                break;
            case PlayFabErrorCode.AccountBanned:
                output = "Benutzer wurde gesperrt!";
                break;
            case PlayFabErrorCode.InvalidUsernameOrPassword:
                output = "Falscher Benutzername oder Passwort!";
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                output = "Benutzername bereits vergeben!";
                break;
            case PlayFabErrorCode.EmailAddressNotAvailable:
                output = "E-Mail Adresse wird bereits verwendet!";
                break;
            case PlayFabErrorCode.AccountNotFound:
                output = "Benutzerkonto existiert nicht!";
                break;
            default:
                break;
        }

        errorText.text = output;

    }

    private void OnLoginResult(LoginResult obj)
    {
        Debug.Log("login worked");
        GUIManager.BackButton();
        GetAccountInfo();
    }

    private void OnRegisterResult(RegisterPlayFabUserResult obj)
    {
        Debug.Log("user succesfully registered");
        GUIManager.BackButton();
    }

    public void GetAccountInfo()
    {
        var request = new GetAccountInfoRequest();

        PlayFabClientAPI.GetAccountInfo(request, OnGetInfoResult, OnPlayFabError);
    }

    private void OnGetInfoResult(GetAccountInfoResult obj)
    {
        Debug.Log("account info request successful");
        Debug.Log("username: " + obj.AccountInfo.Username);
    }
}
