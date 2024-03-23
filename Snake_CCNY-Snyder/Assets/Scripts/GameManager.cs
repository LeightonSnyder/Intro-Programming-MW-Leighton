using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //GLOBAL VARS
    public TextMeshProUGUI foodScoreText; //variable to link to the UI object for P1 score 
    public TextMeshProUGUI foodScoreText2; //variable to link to the UI object for P2 score 
    public int foodScore = 0; //P1's food score
    public int foodScore2 = 0; //P2's food score

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodScoreText.text = "P1: " + foodScore; //update UI to "P1:" and the current food score for P1
        foodScoreText2.text = "P2: " + foodScore; //update UI to "P2:" and the current food score for P2
    }

    public void FoodEaten() //to be called when P1 collides with food
    {
        foodScore++; //add 1 to P1's food score
    }

    public void FoodEaten2() //to be called when P2 collides with food
    {
        foodScore2++; //add 1 to P2's food score
    }
}
