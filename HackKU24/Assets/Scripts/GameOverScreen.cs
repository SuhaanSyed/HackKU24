using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour{
    void Update()
    {
    
    }
    public Text pointsText;

    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";
     
    }
    public void Conclusion(){
        SceneManager.LoadScene("Conclusion");
    }
    
}
