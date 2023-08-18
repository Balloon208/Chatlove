using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HappyEnd : MonoBehaviour
{
    public TextAsset data;
    private AllData1 datas;
    //�����, ������, �ѿ���
    public List<string> cName = new List<string>() { "�����", "������", "�ѿ���" };

    // UI!
    public Text TextName;
    public TypeEffect TextSentence;
    public Image Portrait;

    // �ι�
    public List<Sprite> Profiles1;
    public List<Sprite> Profiles2;
    public List<Sprite> Profiles3;
    public List<Sprite> Profiles4;

    public Image InMoL1;
    public Image InMoL2;
    public Image InMoL3;

    public Image BG;
    public List<Sprite> BGS;
    // �Է�!
    public KeyCode NextInput;

    // �ε��� ����!
    private int NextIndex = 0;

    // �ִϸ��̼�
    public Animator CharacterPanel;

    bool isAction;
    bool onBranch1;
    bool onBranch2;
    bool checkBranch;

    IEnumerator setWaitT()
    {
        print("setWaitT");
        CharacterPanel.SetBool("isShow", true);
        yield return new WaitForSeconds(0.7f);
    }

    IEnumerator setWaitF()
    {
        print("setWaitF");
        yield return new WaitForSeconds(0.7f);
        yield return new WaitForSeconds(0.5f);

        CharacterPanel.SetBool("isShow", false);
    }

    float timer = 0;
    IEnumerator Timer()
    {
        while (true)
        {
            //print(timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void Awake()
    {
        datas = JsonUtility.FromJson<AllData1>(data.text);

        print(datas.happy[NextIndex].Info);
        TextName.text = datas.happy[NextIndex].Info;
        TextSentence.SetMsg(datas.happy[NextIndex].Contents);
        Portrait.sprite = Profiles4[0];


        StartCoroutine(Timer());
    }



    private void Update()
    {
        Next();
    }

    int mode = 0;
    private void Next()
    {
        // �ι�
        if (datas.happy[NextIndex].Info == "�����̼�")
        {
            InMoL1.color = Color.clear;
            // InMoL2.color = Color.clear;
            InMoL3.color = Color.clear;
        }
        if (datas.happy[NextIndex].Info == cName[0])
        {
            Portrait.sprite = Profiles1[0];
            InMoL1.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            // InMoL2.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL3.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
        }
        else if (datas.happy[NextIndex].Info == cName[1])
        {
            Portrait.sprite = Profiles2[0];
            InMoL1.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            // InMoL2.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            InMoL3.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
        }
        else if (datas.happy[NextIndex].Info == cName[2])
        {
            Portrait.sprite = Profiles3[0];
            InMoL1.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            // InMoL2.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL3.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }
        else
        {
            Portrait.sprite = Profiles4[0];
        }

        // ���
        if (datas.happy[NextIndex].SubInfo == "LINE")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[0];
        }
        else if (datas.happy[NextIndex].SubInfo == "CLASS")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[1];
        }
        else if (datas.happy[NextIndex].SubInfo == "FOOD")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[2];
        }
        else if (datas.happy[NextIndex].SubInfo == "SUNSETALLEY")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[3];
        }
        else if (datas.happy[NextIndex].SubInfo == "NIGHTLINE")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[4];
        }
        else if (datas.happy[NextIndex].SubInfo == "BLO")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[5];
        }
        else if (datas.happy[NextIndex].SubInfo == "GROUND")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[6];
        }
        else if (datas.happy[NextIndex].SubInfo == "SUMMERLINE")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[7];
        }
        else if (datas.happy[NextIndex].SubInfo == "SUMMERNIGHT")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[8];
        }
        else if (datas.happy[NextIndex].SubInfo == "SUNSETLINE")
        {
            BG.color = new Color(1, 1, 1, 1);
            BG.sprite = BGS[9];
        }
        else
        {
            BG.color = new Color(0, 0, 0, 255 / 255f);
        }

        if (datas.happy[NextIndex].Info == "�����")
        {
            if (datas.happy[NextIndex].SubContents == "IDLE")
            {
                InMoL1.sprite = Profiles1[0];
            }
            else if (datas.happy[NextIndex].SubContents == "SMILE")
            {
                InMoL1.sprite = Profiles1[1];
            }
            else if (datas.happy[NextIndex].SubContents == "TALK")
            {
                InMoL1.sprite = Profiles1[2];
            }
            else if (datas.happy[NextIndex].SubContents == "FLUTTER")
            {
                InMoL1.sprite = Profiles1[3];
            }
            else if (datas.happy[NextIndex].SubContents == "BORING")
            {
                InMoL1.sprite = Profiles1[4];
            }
            else if (datas.happy[NextIndex].SubContents == "ANGRY")
            {
                InMoL1.sprite = Profiles1[5];
            }
        }
        if (datas.happy[NextIndex].Info == "������")
        {
            if (datas.happy[NextIndex].SubContents == "IDLE")
            {
                InMoL2.sprite = Profiles2[0];
            }
            else if (datas.happy[NextIndex].SubContents == "SMILE")
            {
                InMoL2.sprite = Profiles2[1];
            }
            else if (datas.happy[NextIndex].SubContents == "TALK")
            {
                InMoL2.sprite = Profiles2[2];
            }
            else if (datas.happy[NextIndex].SubContents == "ANGRY")
            {
                InMoL2.sprite = Profiles2[3];
            }
        }
        if (datas.happy[NextIndex].Info == "�ѿ���")
        {
            if (datas.happy[NextIndex].SubContents == "IDLE")
            {
                InMoL3.sprite = Profiles3[0];
            }
            else if (datas.happy[NextIndex].SubContents == "SMILE")
            {
                InMoL3.sprite = Profiles3[1];
            }
            else if (datas.happy[NextIndex].SubContents == "TALK")
            {
                InMoL3.sprite = Profiles3[2];
            }
            else if (datas.happy[NextIndex].SubContents == "FLUTTER")
            {
                InMoL3.sprite = Profiles3[3];
            }
            else if (datas.happy[NextIndex].SubContents == "EMBARRASSMENT")
            {
                InMoL3.sprite = Profiles3[4];
            }
            else if (datas.happy[NextIndex].SubContents == "ANGRY")
            {
                InMoL3.sprite = Profiles3[5];
            }
        }

        if (datas.happy[NextIndex + 1].Code != "END" && (Input.GetKeyUp(NextInput) || checkBranch))
        {
            NextIndex++;

            //print(NextIndex);
            //print("������.");

            if (TextSentence.isAnim)
            {
                TextSentence.SetMsg("");
                NextIndex--;
                return;
            }
            else
            {

                if (NextIndex >= datas.happy.Length)
                {
                    //print("��");
                    return;
                }

                PrintText();
            }
        }
        else if (datas.happy[NextIndex + 1].Code == "END")
        {
            SceneManager.LoadScene("HAPPY");
        }
    }

    void PrintText()
    {
        TextName.text = datas.happy[NextIndex].Info;
        TextSentence.SetMsg(datas.happy[NextIndex].Contents);
    }
}



[Serializable]
public class AllData1
{
    public ScenarioData1[] happy;
}

[Serializable]
public class ScenarioData1
{
    public string Code;
    public int Flag;
    public string Info;
    public string SubInfo;
    public string SubContents;
    public string Contents;
}