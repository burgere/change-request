using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public string placeholder = "Test placeholder";
    public GameObject mug;
    GlideBehavior mugGliding;

    private Dictionary<string, string[]> inputStringsMap = new Dictionary<string, string[]>
    {
        {"Mug", new string[]{"coffee", "mug", "cup"} }
    };
    private Dictionary<string, GameObject> gameObjectMap;
    private Dictionary<string, Vector3> transformMap;
    private Dictionary<string, GlideBehavior> glideMap;
    private string input;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectMap = new Dictionary<string, GameObject>
    {
        {"Mug", mug }
    };

        glideMap = new Dictionary<string, GlideBehavior>
        {
            {"Mug",  mug.GetComponent<GlideBehavior>()}
        };
        
        transformMap = new Dictionary<string, Vector3>
        {
            {"Mug",  new Vector3(-0.5f, 1.2f, -7.5f)}
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringToInput(string s)
    {
        foreach (KeyValuePair<string, string[]> entry in inputStringsMap)
        {
            // do something with entry.Value or entry.Key
            string[] inputWords = s.ToLower().Split(' ');
            HashSet<string> inputSet = new HashSet<string>(inputWords);
            HashSet<string> mapSet = new HashSet<string>(entry.Value);
            
            if (inputSet.IsSubsetOf(mapSet))
            {
                Vector3 transformVector = transformMap[entry.Key];
                GlideBehavior glide = glideMap[entry.Key];
                glide.SetDestination(transformVector);
            }
        }
    }
    
}
