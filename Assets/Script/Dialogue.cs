using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;

    public UnityEngine.UI.Button NextButton;

    private GameObject DialogueUI;

    private UnityEngine.TextCore.Text.TextAsset DialogueTextAsset;

    private string[] rows;
    private string[] cell;
    private int contentIndex = 1;

    public UnityEngine.TextAsset textFile;

    public Image Left_Character;
    public Image Right_Character;

    public TextMeshProUGUI NameText;

    public CharacterDBSO CharacterList;
    // Start is called before the first frame update
    void Start()
    {
        DialogueUI = this.transform.gameObject;
        NextButton.onClick.AddListener(OnClickNextButton);

        readText();

        



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
        int CharacterId = -1;
        
        if (contentIndex >= rows.Length)
        {
            Hide(); return;
        }

        cell = rows[contentIndex].Split(',');

        if (cell[0] == "0")
        {
            CharacterId = int.Parse(cell[2]);
            NameText.text = cell[3];
            if (cell[4] == "×ó")
            {
                Left_Character.sprite = CharacterList.CharacterList[CharacterId].CharacterIcon;
            }
            else if (cell[4] == "ÓÒ")
            {
                Right_Character.sprite = CharacterList.CharacterList[CharacterId].CharacterIcon;
            }
            DialogueText.text = cell[5];
        }

        contentIndex = int.Parse(cell[6]);
        contentIndex++;
    }

    public void readText()
    {
        rows = textFile.text.Split("\n");
        
    }
}
