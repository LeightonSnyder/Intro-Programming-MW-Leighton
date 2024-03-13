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
       
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
