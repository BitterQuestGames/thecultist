using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneHandler : MonoBehaviour
{

    //Add scenes in inspector
    [SerializeField] private List<Scene> _sceneList;
    // Start is called before the first frame update
    //Attach these Buttons in the Inspector
    public Button m_YourFirstButton, m_StartGame, m_Options;

    // options panel
    public GameObject m_OptionsPanel;
    public GameObject m_StartPanel;

    // use to name nextScene
    public string enterNextSceneName;
    private string m_OptionsButtonText;

    //checks if options panel isOpen
    private bool isOpen;


    AudioSource audio;
    public AudioClip audioClip;
    public float volume = 0.5f;


    void Start()
    {
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
        m_StartGame.onClick.AddListener(delegate { TaskWithParameters(enterNextSceneName); });
        m_Options.onClick.AddListener(() => ButtonClicked(42));
        m_OptionsPanel.SetActive(false);
        m_StartPanel.SetActive(true);
        audio = GetComponent<AudioSource>();


    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        QuitGame();
    }

    void TaskWithParameters(string levelName)
    {
        //Deactivate Panel
        m_OptionsPanel.SetActive(false);
        m_StartPanel.SetActive(false);
        audio.PlayOneShot(audioClip, volume);

        //SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        //m_StartPanel.SetActive(false);
        levelName = enterNextSceneName;
        Debug.Log(levelName);

    }

    void ButtonClicked(int buttonNo)
    {
        audio.PlayOneShot(audioClip, volume);

        //Open options menu
        OpenOptionsPanel();

    }

    private void OpenOptionsPanel()
    {
        audio.PlayOneShot(audioClip, volume);

        isOpen = !isOpen;
        if (isOpen)
        {
            //isOpen = true;
            m_OptionsPanel.SetActive(true);
            m_Options.GetComponentInChildren<TextMeshProUGUI>().text = "CLOSE" ;


        }
        else
        {
            m_Options.GetComponentInChildren<TextMeshProUGUI>().text = "Options";

            m_OptionsPanel.SetActive(false);

        }


    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
