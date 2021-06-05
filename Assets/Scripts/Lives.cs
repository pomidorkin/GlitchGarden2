using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{

    [SerializeField] int lives = 5;
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
            lives -= 1;
            UpdateDisplay();

        if(lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
