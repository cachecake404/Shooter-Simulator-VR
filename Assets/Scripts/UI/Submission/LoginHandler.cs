using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginHandler : MonoBehaviour
{
    private string password;
    public InputField passwordText;
    public TextMeshProUGUI messageText;
    public void LoadMenu()
    {
        password = passwordText.text;
        if(password=="password")
        {
            SceneManager.LoadScene("MainMenuTeacher");
        }
        else
        {
            print("Wrong Password");
            messageText.text = "Wrong password, try again!";
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
