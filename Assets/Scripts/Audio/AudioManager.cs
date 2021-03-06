using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource audioSource;
    public Button toggleAudio;
    public Sprite audioOffImage;
    private Sprite audioOnImage;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (toggleAudio == null)
            toggleAudio = GetComponentInChildren<Button>();

        audioOnImage = toggleAudio.image.sprite;
    }

    private void Start()
    {
        toggleAudio.onClick.AddListener(() => ToggleMusic());
    }


    void ToggleMusic()
    {
        if (audioSource.mute == false)
        {
            audioSource.mute = true;
            toggleAudio.image.sprite = audioOffImage;
        }
        else
        {
            audioSource.mute = false;
            toggleAudio.image.sprite = audioOnImage;
        }
    }
}
