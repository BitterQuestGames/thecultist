using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class OpenMultiplayerUI : MonoBehaviour
{
    public GameObject MultiplayerUI;
    Button OpenMultiplayerUIButton;
    bool shouldOpenMultiplayerUI;
    GameObject m_Instructions;
    Transform BtnUIPos;
    Transform BtnUIPos1;
    AudioSource audio;
    public AudioClip audioClip;
    public float volume = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        shouldOpenMultiplayerUI = false;
        m_Instructions = GameObject.Find("InstructionsPanel");
        OpenMultiplayerUIButton = GameObject.Find("MultiplayerButton").GetComponent<Button>();
        BtnUIPos = GameObject.Find("ConnectButtonPOS0").GetComponent<Transform>();
        BtnUIPos1 = GameObject.Find("ConnectButtonPOS1").GetComponent<Transform>();
        audio = GetComponent<AudioSource>();



    }

    public void OpenMultiplayerMenu()
    {
        // toggle boolean on off 
        audio.PlayOneShot(audioClip, volume);
        shouldOpenMultiplayerUI = !shouldOpenMultiplayerUI;
        if (shouldOpenMultiplayerUI)
        {
            OpenMultiplayerUIButton.transform.position = BtnUIPos.transform.position;
            OpenMultiplayerUIButton.GetComponentInChildren<TextMeshProUGUI>(). text = "CLOSE"; //set button text to close
            

            MultiplayerUI.SetActive(true); // Multiplayer panel options OPEN
        }
        else
        {
            OpenMultiplayerUIButton.GetComponentInChildren<TextMeshProUGUI>().text = "CONNECT";  // set botton text to Connect

            MultiplayerUI.SetActive(false); // Multiplayer panel options OPEN
            //OpenMultiplayerUIButton.transform.position = BtnUIPos1.transform.position;


        }
    }

    IEnumerator CloseInstructions()
    {
        if (m_Instructions != null)
        {
            m_Instructions.SetActive(true);

        }

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(8);

        if (m_Instructions != null)
        {
            m_Instructions.SetActive(false);

        }
    }
}
