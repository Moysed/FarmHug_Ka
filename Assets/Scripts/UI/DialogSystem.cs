using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Text dialog, TextinButton;
    public int line = 0;
    public float TimeToType = 3; //ความเร็วในการพิมพ์
    public bool endWord = false; //จบประโยค = true
    public float textPersentage = 0f; //ดูว่าครบประโยครึยัง ครบ = 100%
    public TextAsset textFile;
    public GameObject TapText;
    public GameObject Button;

    void Start()
    {
        GetDialog(0); //เริ่มบรรทัด0
        TapText.gameObject.SetActive(true);
        Button.gameObject.SetActive(false);
    }

    void Update()
    {
        TextinButton.text = "Skip";
        GetDialog(line);
        if (Input.GetMouseButtonDown(0))
        {
            line += 1;
            textPersentage = 0f;
            endWord = false;
        }
    }

    void GetDialog(int line)
    {
        string[] linesInFile;
        linesInFile = textFile.text.Split('\n');
        if(line < linesInFile.Length)
        {
            //callTyping
            callTyping(linesInFile[line]);
        }
        else
        {
            dialog.text = "กด Play เพื่อเริ่มเกม";
            TextinButton.text = "Play";
             TapText.gameObject.SetActive(false);
            Button.gameObject.SetActive(true);
        }
    }

    void callTyping(string TextToType)
    {
        int numberOfLettersToShow = (int)(TextToType.Length * textPersentage);
        dialog.text = TextToType.Substring(0, numberOfLettersToShow);
        textPersentage += Time.deltaTime / TimeToType;
        textPersentage = Mathf.Min(1.0f, textPersentage);
        if(textPersentage >= 1)
        {
            endWord = true;
        }
    }
}
