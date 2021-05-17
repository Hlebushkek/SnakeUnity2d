using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    [SerializeField] GameObject scoreObj;
    [SerializeField] GameObject inputField;
    private string playerRes;
    private ScoreListObj playerResList = new ScoreListObj();
    private void LoadScoreList()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            var JsonRes = PlayerPrefs.GetString("PlayerScore");
            playerResList = JsonUtility.FromJson<ScoreListObj>(JsonRes);
        }
    }
    public void AddScoreToFile()
    {
        LoadScoreList();
        PlayerResult pRes = new PlayerResult();
        pRes.pScore = scoreObj.GetComponent<ScoreScript>().GetScore();
        pRes.pName = inputField.GetComponent<TMPro.TextMeshProUGUI>().text;
        Debug.Log(pRes.pScore + " " + pRes.pName);
        if (playerResList.playerScoreList.Count > 9)
        {
            for (int i = 0; i < playerResList.playerScoreList.Count; i++)
            {
                if (pRes.pScore > playerResList.playerScoreList[i].pScore)
                {
                    int minscore = 13 * 11;
                    int minIndex = -1;
                    for (int j = 0; j < playerResList.playerScoreList.Count; j++)
                    {
                        if (minscore > playerResList.playerScoreList[i].pScore)
                        {
                            minscore = playerResList.playerScoreList[i].pScore;
                            minIndex = j;
                        }
                    }
                    playerResList.playerScoreList[minIndex] = pRes;
                    break;
                }
            }
        } else {playerResList.playerScoreList.Add(pRes);}
        var jsonRes = JsonUtility.ToJson(playerResList);
        
        PlayerPrefs.SetString("PlayerScore", jsonRes);
    }
}
[System.Serializable]
public struct PlayerResult
{
    public int pScore;
    public string pName;
};
[System.Serializable]
public class ScoreListObj
{
    public List<PlayerResult> playerScoreList = new List<PlayerResult>();
}