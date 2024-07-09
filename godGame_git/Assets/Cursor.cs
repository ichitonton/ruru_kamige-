using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Cursor : MonoBehaviour
{
    public Transform startButton;
    public Transform settingButton;
    public Transform endButton;
        
    public SceneAsset startScene;
    public SceneAsset settingScene;
    public SceneAsset endScene;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startButton.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (transform.position == startButton.position)
            {
                transform.position = endButton.position;
            }
            else if (transform.position == settingButton.position)
            {
                transform.position = startButton.position;
            }
            else if (transform.position == endButton.position)
            {
                transform.position = settingButton.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (transform.position == startButton.position)
            {
                transform.position = settingButton.position;
            }
            else if (transform.position == settingButton.position)
            {
                transform.position = endButton.position;
            }
            else if (transform.position == endButton.position)
            {
                transform.position = startButton.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (transform.position == startButton.position)
            {
                SceneManager.LoadScene(startScene.name);
            }
            if (transform.position == settingButton.position)
            {
                SceneManager.LoadScene(settingScene.name);
            }
            if (transform.position == endButton.position)
            {
                SceneManager.LoadScene(endScene.name);
            }
        }

    }
}
