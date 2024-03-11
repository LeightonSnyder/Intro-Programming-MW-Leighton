using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //use Scene Management Library
                                   /// <summary>
                                   /// (is there a list or guide to these libraries?)
                                   /// </summary>

public class SceneChanger : MonoBehaviour
{
    //GLOBAL VARS
    public int sceneNumber;
     //0 = Start
     //1 = Main
     //2 = End
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneNumber == 0) //in the Start scene
        {
            StartSceneControls();
        }
        else if (sceneNumber == 1) //in the Main scene
        {
            MainSceneControls();
        }
        else if (sceneNumber == 2) //in the End scene
        {
            EndSceneControls();
        }
    }

    public void StartSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Return))  //key down comes true ONCE; get key repeats while pressed
        {
            SceneManager.LoadScene(1);
        }
    }

    public void MainSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))  //key down comes true ONCE; get key repeats while pressed
        {
            SceneManager.LoadScene(2);
        }
    }

    public void EndSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.R))  //key down comes true ONCE; get key repeats while pressed
        {
            SceneManager.LoadScene(0);
        }
    }
}
