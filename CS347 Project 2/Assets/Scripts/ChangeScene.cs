using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string Overworld, Town, Desert;
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (scene.name == Town || scene.name == Desert)
            SceneManager.LoadSceneAsync(Overworld);
        else
            SceneManager.LoadSceneAsync(collider.name);
    }
}
