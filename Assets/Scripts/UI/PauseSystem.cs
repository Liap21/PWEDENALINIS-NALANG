using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] GameObject UI_PauseMenu = null;
    // Start is called before the first frame update
    bool isPaused;

    private void Awake()        
    {
        //UI_PauseMenu = FindObjectOfType<PauseSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;    
            Time.timeScale = Time.timeScale <= Mathf.Epsilon ? 0 : 1;
            UI_PauseMenu.SetActive(isPaused);   
        }
    }

    public bool GetIsPaused() { return isPaused; }  
}
