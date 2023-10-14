using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        Continue();
    }

    public void Pause(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
        }
    }

    public void Continue(){
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            menu.SetActive(false);
        }
    }
}
