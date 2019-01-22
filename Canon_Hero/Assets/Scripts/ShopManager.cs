using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopManager : MonoBehaviour 
{
    public static ShopManager Instance;
    [SerializeField]
    private List<float> costCharacter;
    [SerializeField]
    private GameObject buyBtn, selectBtn,shopPanel, NotEnoughMoneyPanel;
    [SerializeField]
    private Text costText;

    private int currentSelect;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt(Constants.CharacterInfo.LISTPLAYER[0], 1);
    }

    public void OnClickBackBtn()
    {
        AudioManager.Instance.PlayButtonAudio();
        shopPanel.SetActive(false);
    }

    public void OnClickCharacterBtn(int number)
    {
        switch (number)
        {
            case 0:
                SetStateButton(0);
                costText.text = costCharacter[0].ToString();
                currentSelect = number;
                break;
            case 1:
                SetStateButton(1);
                costText.text = costCharacter[1].ToString();
                currentSelect = number;
                break;
            case 2:
                SetStateButton(2);
                costText.text = costCharacter[2].ToString();
                currentSelect = number;
                break;
            case 3:
                SetStateButton(3);
                costText.text = costCharacter[3].ToString();
                currentSelect = number;
                break;
        }
    }

    private void SetStateButton(int number)
    {
        if (PlayerPrefs.GetInt(Constants.CharacterInfo.LISTPLAYER[number]) ==1)
        {
            selectBtn.SetActive(true);
            buyBtn.SetActive(false);
        }
        else
        {
            selectBtn.SetActive(false);
            buyBtn.SetActive(true);
        }
    }

    public void  OnClickBuyBtn()
    {
        AudioManager.Instance.PlayButtonAudio();
        if (PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS) >= costCharacter[currentSelect])
        {
            PlayerPrefs.SetFloat(Constants.ScoreInfo.TOTALCOINS, PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS)- costCharacter[currentSelect]);
            PlayerPrefs.SetInt(Constants.CharacterInfo.LISTPLAYER[currentSelect],1);
            Debug.Log("Buy success");
            selectBtn.SetActive(true);
            buyBtn.SetActive(false);
        }
        else
        {
            NotEnoughMoneyPanel.SetActive(true);
            Debug.Log("Not enough money");
        }
    }

    public void OnClickOKBtn()
    {
        AudioManager.Instance.PlayButtonAudio();
        NotEnoughMoneyPanel.SetActive(false);
    }
    public void OnClickSelectCharacter()
    {
        AudioManager.Instance.PlayButtonAudio();
        PlayerPrefs.SetInt(Constants.CharacterInfo.CURRENTPLAYER,currentSelect);
        StartCoroutine(DelayTime());
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(Constants.Scene.MAINSCENE);
    }
}
