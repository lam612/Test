using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{

    private string inputUsername;
    private string inputPassword;
    string LoginURL = "www.clickmebabyhedspi.tk/Login.php";

    public InputField username;
    public InputField password;
    public GameObject LoginSuccessText;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }    
    public void loginDB()
    {    
        inputUsername = username.text;
        inputPassword = password.text;
        StartCoroutine(LoginToDB(inputUsername, inputPassword));
        Debug.Log("Collecting!!!");
    }
    IEnumerator LoginToDB(string username, string password)
    {
       
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(LoginURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text == "login success")
        {         
            SceneManager.LoadScene("playscene");
            PlayerPrefs.SetString("Username", username);
        }       
    }
    public void Register()
    {
        SceneManager.LoadScene("RegisterScene");
    }
}

