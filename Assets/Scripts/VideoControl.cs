using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoControl : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    [SerializeField] Button playButton;
    [SerializeField] Button stopButton;
    [SerializeField] Button pauseButton;

    [SerializeField] Slider slider;
    [SerializeField] Text timeText;

    void Start()
    {
        this.playButton.onClick.AddListener(() =>
        {
            this.videoPlayer.Play();
        });

        this.stopButton.onClick.AddListener(() =>
        {
            this.videoPlayer.Stop();
        });

        this.pauseButton.onClick.AddListener(() =>
        {
            this.videoPlayer.Pause();
        });
    }

    void Update()
    {
        this.slider.value = (float)(this.videoPlayer.time / this.videoPlayer.length);
        this.timeText.text = $"{(int)this.videoPlayer.time / 60:D2}:{(int)this.videoPlayer.time % 60:D2}";
    }
}
