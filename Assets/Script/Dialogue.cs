using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;

    public UnityEngine.UI.Button NextButton;

    private GameObject DialogueUI;

    private UnityEngine.TextCore.Text.TextAsset DialogueTextAsset;

    private string[] contentList;
    private int contentIndex = 0;

    public UnityEngine.TextAsset textFile;
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI = this.transform.gameObject;
        NextButton.onClick.AddListener(OnClickNextButton);

        readText();

        //contentList = new List<string>();
        //contentList.Add("ÄãºÃ");
        //contentList.Add("WTF");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show()
    {
        DialogueUI.SetActive(true);
    }

    private void Hide()
    {
        DialogueUI.SetActive(false);
    }

    private void OnClickNextButton()
    {
        contentIndex++;
        if (contentIndex >= contentList.Length)
        {
            Hide(); return;
        }
        DialogueText.text = contentList[contentIndex];
        
    }

    public void readText()
    {
        contentList = textFile.text.Split("\n");
        
    }
}
