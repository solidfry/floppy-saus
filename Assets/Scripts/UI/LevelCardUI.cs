using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCardUI : MonoBehaviour
{
    [Header("Level Information")]
    [SerializeField]
    public Level levelData;

    private string levelName;
    private string subTitle;
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

            if (levelData.levelComplete)
                subTitleText.text = $"{levelData.subTitle} Complete!";
            // todo: this needs to be improved so that if you've completed the previous level this level will be available
//            if (levelData.levelID != 1 && levelData.levelComplete == false) 
//            {
//                button.interactable = false;
//                button.GetComponentInChildren<TMP_Text>().color = new Color(0.07f,0,0.2f, 0.5f);
//            }
            
            if (descriptionText != null)
                descriptionText.text = description;

            if (buttonText != null)
                buttonText.text = buttonLabel;
        }
    }

}
