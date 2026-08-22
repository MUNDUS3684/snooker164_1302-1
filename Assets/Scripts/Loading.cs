using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private float waitSecond = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitSecond > 0f)
        {
            waitSecond -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(LoadNewScene());
        }
    }

    private IEnumerator LoadNewScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scene01");

        while(!operation.isDone)
        {
            slider.value = operation.progress/0.9f;
            yield return null;
        }
    }
}
