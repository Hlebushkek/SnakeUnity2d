using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ScoreObj;
    [SerializeField] GameObject MenuObj;
    private void Start()
    {
        ScoreObj.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnMenu();
        }
    }
    private void ReturnMenu()
    {
        ScoreObj.SetActive(false);
        MenuObj.SetActive(true);
    }
    public void LoadPlayLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadScore()
    {
        ScoreObj.SetActive(true);
        MenuObj.SetActive(false);
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            ScoreObj.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "";
            var JsonRes = PlayerPrefs.GetString("PlayerScore");
            var playerResList = JsonUtility.FromJson<ScoreListObj>(JsonRes);
            bubbleSort(playerResList.playerScoreList);
            for (int i = 0; i < playerResList.playerScoreList.Count; i++)
            {
                string tempt = playerResList.playerScoreList[i].pScore + "\t" + playerResList.playerScoreList[i].pName + "\n";
                ScoreObj.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text += tempt;
            }
            /*playerResList.playerScoreList.RemoveRange(10,1);
            var jsonstr = JsonUtility.ToJson(playerResList);
            PlayerPrefs.SetString("PlayerScore", jsonstr);*/
        }
    }
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    static private void bubbleSort(List<PlayerResult> sortlist)
    {
        int n = sortlist.Count;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (sortlist[j].pScore < sortlist[j + 1].pScore)
                {
                    var temp = sortlist[j];
                    sortlist[j] = sortlist[j + 1];
                    sortlist[j + 1] = temp;
                }
    }
}
