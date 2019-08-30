using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManagerScript : MonoBehaviour
{
    public Button registerButton, loginButton;
    public GameObject registerPanel, loginPanel, mainPanel;

    private GameObject currentPanel;

    public void RegisterForm()
    {
        mainPanel.SetActive(false);
        registerPanel.SetActive(true);
        currentPanel = registerPanel;
    }

    public void LoginForm()
    {
        mainPanel.SetActive(false);
        loginPanel.SetActive(true);
        currentPanel = loginPanel;
    }

    public void BackButton()
    {
        currentPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
