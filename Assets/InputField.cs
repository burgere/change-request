using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public string placeholder = "Test placeholder";
    public GameObject mug;
    public GameObject cabinet;
    public Camera camera;

    GlideBehavior cameraGliding;

    private Dictionary<string, string[]> inputStringsMap = new Dictionary<string, string[]>
    {
        {"Mug", new string[]{"coffee", "mug", "cup", "brew", "cafe"} },
        {"Cabinet", new string[]{"cabinet, shelves"}}
    };
    private Dictionary<string, GameObject> gameObjectMap;
    private Dictionary<string, Vector3> transformMap;
    private Dictionary<string, Vector3> cameraPositions;
    private Dictionary<string, GlideBehavior> glideMap;
    private string input;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectMap = new Dictionary<string, GameObject>
    {
        {"Mug", mug },
        {"Cabinet", cabinet}
    };

        glideMap = new Dictionary<string, GlideBehavior>
        {
            {"Mug",  mug.GetComponent<GlideBehavior>()}
        };
        
        transformMap = new Dictionary<string, Vector3>
        {
            {"Mug",  new Vector3(0.0f, 1.6f, -9.5f)}
            // Vector3(Y, ???, X)
            //new Vector3(-0.7f, 1.6f, -9.3f)
        };
        
        cameraPositions = new Dictionary<string, Vector3>
        {
            {"Cabinet",  new Vector3(0.0f, 1.6f, -9.5f)}
            // Vector3(Y, ???, X)
            //new Vector3(-0.7f, 1.6f, -9.3f)
        };
        cameraGliding = camera.GetComponent<GlideBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringToInput(string s)
    {
        foreach (KeyValuePair<string, string[]> entry in inputStringsMap)
        {
            // Check if there is a camera position associated with the input.
            string[] inputWords = s.ToLower().Split(' ');
            HashSet<string> inputSet = new HashSet<string>(inputWords);
            HashSet<string> mapSet = new HashSet<string>(entry.Value);

            if (inputSet.IsSubsetOf(mapSet))
            {
                Vector3 transformVector = transformMap[entry.Key];
                if (glideMap.ContainsKey(entry.Key))
                {
                    GlideBehavior glide = glideMap[entry.Key];
                    glide.SetDestination(transformVector);

                }
                if (cameraPositions.ContainsKey(entry.Key))
                {
                    Vector3 cameraPosition = cameraPositions[entry.Key];
                    cameraGliding.SetDestination(cameraPosition);
                }
            }
        }
    }
    
}