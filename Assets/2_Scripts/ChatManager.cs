using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatManager : MonoBehaviour
{
    // 데이터!
    public TextAsset data;
    protected AllData datas;
    //김민준, 강예원, 한예설
    public List<string> cName = new List<string>() { "김민준", "강예원", "한예설" };

    // UI!
    public Text TextName;
    public TypeEffect TextSentence;
    public Image Portrait;

    // 인물
    public List<Sprite> Profiles1;
    public List<Sprite> Profiles2;
    public List<Sprite> Profiles3;
    public List<Sprite> Profiles4;

    public Image InMoL1;
    public Image InMoL2;
    public Image InMoL3;

    public Image BG;
    public List<Sprite> BGS;
    // 입력!
    public KeyCode NextInput;

    // 인덱스 관리!
    protected int NextIndex = 0;

    // 애니메이션
    public Animator CharacterPanel;
    public Animator BranchPanel1;
    public Animator BranchPanel2;

    protected bool onBranch1;
    protected bool onBranch2;
    protected bool checkBranch;

    public Text tx1;
    public Text tx2;

    // 배경 리스트
    protected string[] backgroundlist = new string[] { "LINE", "CLASS", "FOOD", "SUNSETALLEY", "NIGHTMARE", "BLO", "GROUND", "SUMMERLINE", "SUMMERNIGHT", "SUNSETLINE", "SIBAL" };

    private IEnumerator setWaitT()
    {
        print("setWaitT");
        CharacterPanel.SetBool("isShow", true);
        yield return new WaitForSeconds(0.7f);

        BranchPanel1.SetBool("isBranch", true);
        BranchPanel2.SetBool("isBranch", true);
    }

    private IEnumerator setWaitF()
    {
        print("setWaitF");
        yield return new WaitForSeconds(0.7f);
        BranchPanel1.SetBool("isBranch", false);
        BranchPanel2.SetBool("isBranch", false);
        yield return new WaitForSeconds(0.5f);

        CharacterPanel.SetBool("isShow", false);
    }

    protected float timer = 0;
    protected IEnumerator Timer()
    {
        while (true)
        {
            //print(timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    protected void Awake()
    {
        datas = JsonUtility.FromJson<AllData>(data.text);

        print(datas.story[NextIndex].Info);
        TextName.text = datas.story[NextIndex].Info;
        TextSentence.SetMsg(datas.story[NextIndex].Contents);
        Portrait.sprite = Profiles4[0];


        StartCoroutine(Timer());
    }

    

    protected void Update()
    {
        Next();
    }

    protected int mode = 0;

    protected void Changebackground()
    {
        for(int i = 0; i<backgroundlist.Length; i++)
        {
            if (datas.story[NextIndex].SubInfo == backgroundlist[i].ToString())
            {
                BG.color = new Color(1, 1, 1, 1);
                BG.sprite = BGS[i];
                return;
            }
        }
        BG.color = new Color(0, 0, 0, 255 / 255f);
        return;
    }


    protected virtual void End()
    {
        // 호감도 넣기..
        if (PlayerStatus.friendshiplevel >= 80)
        {
            SceneManager.LoadScene("PlayingGameEndingHAPPY");
        }
        else if (PlayerStatus.friendshiplevel >= 40)
        {
            SceneManager.LoadScene("PlayingGameEndingNORMAL");
        }
        else if (PlayerStatus.friendshiplevel < 40)
        {
            SceneManager.LoadScene("PlayingGameEndingBAD");
        }
    }
    protected void Next()
    {
        // 인물
        if (datas.story[NextIndex].Info == "나래이션")
        {
            InMoL1.color = Color.clear;
            InMoL2.color = Color.clear;
            InMoL3.color = Color.clear;
        }
        if (datas.story[NextIndex].Info == cName[0])
        {
            Portrait.sprite = Profiles1[0];
            InMoL1.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            InMoL2.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL3.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
        }
        else if (datas.story[NextIndex].Info == cName[1])
        {
            Portrait.sprite = Profiles2[0];
            InMoL1.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL2.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            InMoL3.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
        }
        else if (datas.story[NextIndex].Info == cName[2])
        {
            Portrait.sprite = Profiles3[0];
            InMoL1.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL2.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL3.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }
        else
        {
            Portrait.sprite = Profiles4[0];
        }

        // 배경
        Changebackground();

        if(datas.story[NextIndex].Code == "NARRATION")
        {
            InMoL1.sprite = Profiles1[0];
            InMoL2.sprite = Profiles2[0];
            InMoL3.sprite = Profiles3[0];
        }
        if (datas.story[NextIndex].Info == "김민준")
        {
            if (datas.story[NextIndex].SubContents == "IDLE")
            {
                InMoL1.sprite = Profiles1[0];
            }
            else if (datas.story[NextIndex].SubContents == "SMILE")
            {
                InMoL1.sprite = Profiles1[1];
            }
            else if (datas.story[NextIndex].SubContents == "TALK")
            {
                InMoL1.sprite = Profiles1[2];
            }
            else if (datas.story[NextIndex].SubContents == "FLUTTER")
            {
                InMoL1.sprite = Profiles1[3];
            }
            else if (datas.story[NextIndex].SubContents == "BORING")
            {
                InMoL1.sprite = Profiles1[4];
            }
            else if (datas.story[NextIndex].SubContents == "ANGRY")
            {
                InMoL1.sprite = Profiles1[5];
            }
        }
        if (datas.story[NextIndex].Info == "강예원")
        {
            if (datas.story[NextIndex].SubContents == "IDLE")
            {
                InMoL2.sprite = Profiles2[0];
            }
            else if (datas.story[NextIndex].SubContents == "SMILE")
            {
                InMoL2.sprite = Profiles2[1];
            }
            else if (datas.story[NextIndex].SubContents == "TALK")
            {
                InMoL2.sprite = Profiles2[2];
            }
            else if (datas.story[NextIndex].SubContents == "ANGRY")
            {
                InMoL2.sprite = Profiles2[3];
            }
        }
        if (datas.story[NextIndex].Info == "한예설")
        {
            if (datas.story[NextIndex].SubContents == "IDLE")
            {
                InMoL3.sprite = Profiles3[0];
            }
            else if (datas.story[NextIndex].SubContents == "SMILE")
            {
                InMoL3.sprite = Profiles3[1];
            }
            else if (datas.story[NextIndex].SubContents == "TALK")
            {
                InMoL3.sprite = Profiles3[2];
            }
            else if (datas.story[NextIndex].SubContents == "FLUTTER")
            {
                InMoL3.sprite = Profiles3[3];
            }
            else if (datas.story[NextIndex].SubContents == "EMBARRASSMENT")
            {
                InMoL3.sprite = Profiles3[4];
            }
            else if (datas.story[NextIndex].SubContents == "ANGRY")
            {
                InMoL3.sprite = Profiles3[5];
            }
        }

        if (datas.story[NextIndex + 1].Code != "END" && (Input.GetKeyUp(NextInput) || checkBranch))
        {
            while (datas.story[NextIndex + 1].Flag != mode)
            {
                if(datas.story[NextIndex + 1].Flag == 0)
                {
                    mode = 0;
                    break;
                }
                print(NextIndex);
                NextIndex++;
            }
            print(mode);

            //print(NextIndex + " " + onBranch1 + " " + onBranch2);
            if (datas.story[NextIndex + 1].Code == "SELECT")
            {
                if (TextSentence.isAnim)
                {
                    TextSentence.SetMsg("");
                    return;
                }
                tx1.text = datas.story[NextIndex + 1].Contents;
                tx2.text = datas.story[NextIndex + 2].Contents;
                StartCoroutine(setWaitT());

                if (onBranch1 || onBranch2)
                {
                    StartCoroutine(setWaitF());
                }

                checkBranch = false;

                if (onBranch1)
                {
                    while (datas.story[NextIndex].Flag != 1)
                    {
                        NextIndex++;
                    }
                    mode = 1;

                    onBranch1 = false;
                }
                else if (onBranch2)
                {
                    while (datas.story[NextIndex].Flag != 2)
                    {
                        NextIndex++;
                    }
                    mode = 2;

                    onBranch2 = false;
                }
                else
                    return;

                checkBranch = false;
            }
            else
            {
                NextIndex++;

                //print(NextIndex);
                //print("접근함.");

            }

            if (TextSentence.isAnim)
            {
                TextSentence.SetMsg("");
                NextIndex--;
                return;
            }
            else
            {
                
                if (NextIndex >= datas.story.Length)
                {
                    //print("끝");
                    return;
                }

                PrintText();
            }
        }
        else if(datas.story[NextIndex+1].Code == "END")
        {
            End();
        }
    }

    protected void PrintText()
    {
        TextName.text = datas.story[NextIndex].Info;
        TextSentence.SetMsg(datas.story[NextIndex].Contents);
    }

    public void OnBranch1()
    {
        if (datas.story[NextIndex + 1].Code == "SELECT")
        {
            print("접근");
            checkBranch = true;
            onBranch1 = true;
        }
    }

    public void OnBranch2()
    {
        if (datas.story[NextIndex + 1].Code == "SELECT")
        {
            print("접근");
            checkBranch = true;
            onBranch2 = true;
        }
    }
}

[Serializable]
public class AllData
{
    public ScenarioData[] story;
}

[Serializable]
public class ScenarioData
{
    public string Code;
    public int Flag;
    public string Info;
    public string SubInfo;
    public string SubContents;
    public string Contents;
}