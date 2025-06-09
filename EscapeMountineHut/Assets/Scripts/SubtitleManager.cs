using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class SubtitleData
{
    public string triggerName;
    public string[] lines;
}

[System.Serializable]
public class SubtitleJson
{
    public string[] initialLines;
    public List<SubtitleData> subtitles;
}

public class SubtitleManager : MonoBehaviour
{
    public GameObject subtitlePanel;
    public TextMeshProUGUI subtitleText;
    public Button touchZone;
    public GameObject popupPanel;
    public TextAsset jsonFile;

    private Dictionary<string, string[]> subtitleDict;
    private string[] currentLines;
    private int currentLineIndex = 0;
    private bool isActive = false;

    void Start()
    {
        subtitlePanel.SetActive(false);
        touchZone.onClick.AddListener(NextLine);
        LoadSubtitles();

        StartInitialSubtitle();
    }

    void LoadSubtitles()
    {
        subtitleDict = new Dictionary<string, string[]>();
        SubtitleJson data = JsonUtility.FromJson<SubtitleJson>(jsonFile.text);

        foreach (SubtitleData item in data.subtitles)
        {
            subtitleDict[item.triggerName] = item.lines;
        }

        currentLines = data.initialLines;
    }

    void StartInitialSubtitle()
    {
        if (currentLines == null || currentLines.Length == 0) return;

        isActive = true;
        currentLineIndex = 0;
        subtitlePanel.SetActive(true);
        subtitleText.text = currentLines[currentLineIndex];
    }

    public void StartSubtitleByTrigger(string triggerName)
    {
        if (!subtitleDict.ContainsKey(triggerName)) return;

        currentLines = subtitleDict[triggerName];
        currentLineIndex = 0;
        isActive = true;
        subtitlePanel.SetActive(true);
        subtitleText.text = currentLines[currentLineIndex];
    }

    void NextLine()
    {
        if (!isActive || (popupPanel != null && popupPanel.activeSelf)) return;

        currentLineIndex++;
        if (currentLineIndex >= currentLines.Length)
        {
            EndSubtitle();
        }
        else
        {
            subtitleText.text = currentLines[currentLineIndex];
        }
    }

    void EndSubtitle()
    {
        isActive = false;
        subtitlePanel.SetActive(false);
    }
}
