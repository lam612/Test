using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterSuccess : MonoBehaviour {

    private string inputUserName;
    private string inputPassword;
    private string inputEmail;

    public InputField NewUsername;
    public InputField NewPassword;
    public InputField NewEmail;
    string CreateUserURL = "www.clickmebabyhedspi.tk/insertUser.php";
    public GameObject SuccessText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void RegisterSuccessText()
    {
        SuccessText.SetActive(true);
        inputUserName = NewUsername.text;
        inputPassword = NewPassword.text;
        inputEmail = NewEmail.text;     
        StartCoroutine(CreateUser(inputUserName, inputPassword, inputEmail));      
    }

    public void LoginScene()
    {
        SceneManager.LoadScene("Loginscene");
    }

    IEnumerator CreateUser(string username, string password, string email)
    {
        Debug.Log("Create User Begin");
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("emailPost", email);

        WWW www = new WWW(CreateUserURL, form);
        yield return www;
        Debug.Log("Creat User Have Done");
    }   
}
