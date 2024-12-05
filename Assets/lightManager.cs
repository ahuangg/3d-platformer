using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lightManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string newGameLevel; // Name of the new scene
    public Vector3 lightPosition = new Vector3(400f, 300f, 100f); // Desired light position
    public Vector3 lightRotation = new Vector3(50f, -30f, 0f); // Desired light rotation

    public void PlayGameDialogYes()
    {
        // Add a listener to modify the lighting after the scene loads
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Load the new scene
        SceneManager.LoadScene(newGameLevel);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the main directional light
        Light directionalLight = gameObject.GetComponent<Light>();
        if (directionalLight != null && directionalLight.type == LightType.Directional)
        {
            // Set light position and rotation
            directionalLight.transform.position = lightPosition;
            directionalLight.transform.rotation = Quaternion.Euler(lightRotation);
        }

        // Remove the listener to prevent it from firing for other scenes
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
