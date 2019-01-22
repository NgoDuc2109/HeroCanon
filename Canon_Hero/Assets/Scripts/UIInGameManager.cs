using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIInGameManager : MonoBehaviour
{
    public static UIInGameManager Instance;
    public static bool isRestart;
    [SerializeField]
    private GameObject startPanel;
    [SerializeField]
    private GameObject ingamePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text lastScoreText;
    [SerializeField]
    private Text totalCoins;
    [SerializeField]
    private Text totalCoinsInShop;
    [SerializeField]
    private Text bestScoreInStartPanel;
    [SerializeField]
    private Text bestScoreInGameoverPanel;
    [SerializeField]
    private GameObject onePoint, headshot, ultra, miss,roundLight;

    [SerializeField]
    private List<string> quote;
    [SerializeField]
    private Text quoteText;
    [SerializeField]
    private GameObject quoteObj;
    [SerializeField]
    private Animator startPanelAnim;
    [SerializeField]
    private Animator pausePanelAnim;
    private const string best = "BEST: ";
    public Text TotalCoins
    {
        get
        {
            return totalCoins;
        }

        set
        {
            totalCoins = value;
        }
    }

    public Text TotalCoinsInShop
    {
        get
        {
            return totalCoinsInShop;
        }

        set
        {
            totalCoinsInShop = value;
        }
    }

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
        if (isRestart == true)
        {
            startPanel.SetActive(false);
            ingamePanel.SetActive(true);
        }
        currentScoreText.text = "0";
        bestScoreInStartPanel.text = PlayerPrefs.GetFloat(Constants.ScoreInfo.BESTSCORE).ToString();
        totalCoins.text = PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS).ToString();
        TotalCoinsInShop.text = PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS).ToString();
        quoteText.text = quote[(int) Random.Range(0,quote.Count -1)];
    }
    public void OnClickStart_HideStartPanel()
    {
        startPanelAnim.SetTrigger(Constants.Animation.ISHIDE);
        quoteObj.SetActive(false);
        StartCoroutine(Delay());
        ingamePanel.SetActive(true);     
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        startPanel.SetActive(false);
    }
    public void ChangeCurrentScoreTextOnIngamePanel()
    {
        currentScoreText.text = ScoreManager.Instance.CurrentScore.ToString();
    }
    public void OnClickPauseBtn()
    {
        AudioManager.Instance.PlayButtonAudio();
        ingamePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void OnClickContinueBtn()
    {
        AudioManager.Instance.PlayButtonAudio();
        pausePanelAnim.Play(Constants.Animation.PAUSEFADE);
        StartCoroutine(Delay2());
    }

    private IEnumerator Delay2()
    {
        yield return new WaitForSeconds(0.5f);
        pausePanel.SetActive(false);
        ingamePanel.SetActive(true);
    }

    public void OnClickRestartBtn()
    {

        AudioManager.Instance.PlayButtonAudio();
        BulletControl.TotalCombo = 0;
        Time.timeScale = 1;
        isRestart = true;
        StartCoroutine(DelayTime());
    }

    public void OnClickHomeBtn()
    {
        AudioManager.Instance.PlayButtonAudio();
        BulletControl.TotalCombo = 0;
        isRestart = false;
        StartCoroutine(DelayTime());       
    }
    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(Constants.Scene.MAINSCENE);

    }
    public void OnClickShopBtn()
    {
        AudioManager.Instance.PlayButtonAudio();
        shopPanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        BulletControl.TotalCombo = 0;
        ingamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        lastScoreText.text = currentScoreText.text;
        if (ScoreManager.Instance.CurrentScore > PlayerPrefs.GetFloat(Constants.ScoreInfo.BESTSCORE))
        {
            PlayerPrefs.SetFloat(Constants.ScoreInfo.BESTSCORE, ScoreManager.Instance.CurrentScore);
            roundLight.SetActive(true);
        }
        bestScoreInGameoverPanel.text = best + PlayerPrefs.GetFloat(Constants.ScoreInfo.BESTSCORE);
    }

    /// <summary>
    /// set active text
    /// </summary>
    /// <param name="number">case0 : miss , case1 : 1point, case2 : headshot, case3: ultrakill</param>
    public void SetActiveText(int number)
    {
        switch (number)
        {
            case 0:
                miss.SetActive(true);
                break;
            case 1:
                onePoint.SetActive(true);

                break;
            case 2:
                headshot.SetActive(true);
                break;
            case 3:
                ultra.SetActive(true);
                break;
        }
    }
}
