using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BadEnd : ChatManager
{
    protected override void End()
    {
        // 호감도 넣기..
        SceneManager.LoadScene("BAD");
    }
}