using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI showScore;

    public void point(string s)
    {
        showScore.text = s ;
    }
    public void print()
    {
        showScore.text = "hello";
    }
    
}
