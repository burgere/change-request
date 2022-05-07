using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public string placeholder = "Test placeholder";
    private string input;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringToInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
}
