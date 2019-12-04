using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_start_bouton : MonoBehaviour
{
    public GameObject imageFade;
    float countdown=1f;
    bool startCountdonwn=false;
    public string sceneNameToLoad;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void ChangeScene()
    {
        //active l'image ce qui déclenche l'animation et le compte à rebours.
        imageFade.SetActive(true);
        startCountdonwn = true;
    }
    void Update()
    {
        //attend une seconde que l'animation se joue puis change de scène.
        if (startCountdonwn == true)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
