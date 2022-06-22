using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCardUI : MonoBehaviour
{
    [Header("Level Information")]
    [SerializeField]
    public Level levelData;

    private string levelName;
    private string subTitle = "Mission";
    private string description;

    [Header("Text Fields")]
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text subTitleText;
    [SerializeField]
    private TMP_Text descriptionText;
    [Header("Button Info")]
    [SerializeField]
    private Button button;
    [SerializeField]
    private string buttonLabel = "Play Level";
    private TMP_Text buttonText;

    private void Awake()
    {
        AssignValues();
    }

    private void Start()
    {
        if (button != null)
            button.onClick.AddListener(() => levelData.LoadScene());
    }

    public void AssignValues()
    {
        if (levelData != null)
        {
            levelName = levelData.levelName;
            subTitle = levelData.subTitle;
            description = levelData.description;

            if (titleText != null)
                titleText.text = levelName;

            if (subTitleText != null)
                subTitleText.text = subTitle;

            if (descriptionText != null)
                descriptionText.text = description;

            if (buttonText != null)
                buttonText.text = buttonLabel;
        }
    }

}
