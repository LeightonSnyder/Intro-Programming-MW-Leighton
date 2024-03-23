using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //use Scene Management Library
                                   
public class SceneChanger : MonoBehaviour
{
     //SCENE # GUIDES
     //0 = Start
     //1 = Main
     //2 = Winner P1
     //3 = Winner P2
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MoveToScene(int sceneID) //method for changing scenes that can be called by other scripts
    {
        SceneManager.LoadScene(sceneID); //load the scene from the ID provided in the void
    }
}
