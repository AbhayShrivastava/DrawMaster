using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

    #region UI Public fields
    public string PlayerName="Player";

    public InputField NameField;

    public Text Score;

    public Button Play;

    public GameObject DrawingScreen;
    public GameObject MenuScreen;

    #endregion


    private void Start()
    {
      /*  Resources res = getResources();
        string text = res.getString(res.getIdentifier("some_text_id", "string", "com.mycompany.MyUnity3DGame"));

        // The above is equal to
        String text = res.getString(R.string.some_text_id);*/
    }

    #region PlayButton
    public void ButtonPLAY()
    {
        PlayerName = NameField.text;
        DrawingScreen.SetActive(true);
        MenuScreen.SetActive(false);
        Score.text = PlayerName;

    }


    #endregion




}
