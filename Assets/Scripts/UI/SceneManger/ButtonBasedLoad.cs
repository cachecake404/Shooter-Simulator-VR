using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonBasedLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if (Input.GetKeyUp("f"))
        {
            PlayerPrefs.SetInt("IsTeacher", 1);
            SceneManager.LoadScene("LoginTeacher");
        }
        if(OVRInput.GetUp(OVRInput.Button.Three))
        {
            PlayerPrefs.SetInt("IsTeacher", 0);
            SceneManager.LoadScene("MainMenu");
        }

    }
}
