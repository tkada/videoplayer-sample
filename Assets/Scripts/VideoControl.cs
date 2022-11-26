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
            //再生する
            //一時停止中の場合は再開する
            this.videoPlayer.Play();
        });

        this.stopButton.onClick.AddListener(() =>
        {
            //停止する
            this.videoPlayer.Stop();
        });

        this.pauseButton.onClick.AddListener(() =>
        {
            //一時停止する
            this.videoPlayer.Pause();
        });

        this.slider.onValueChanged.AddListener(value =>
        {
            //スライダーの場所に合わせて再生する場所を変える
            this.videoPlayer.time = this.videoPlayer.length * value;
        });
    }

    void Update()
    {
        //スライダーを再生時間に合わせて進行させる
        //SetValueWithoutNotifyを使うとonValueChangedのコールバックが呼ばれない
        //→UIで操作したイベントだけを取得することができる
        this.slider.SetValueWithoutNotify((float)(this.videoPlayer.time / this.videoPlayer.length));

        //現在再生時間を表示
        this.timeText.text = $"{(int)this.videoPlayer.time / 60:D2}:{(int)this.videoPlayer.time % 60:D2}";
    }
}
