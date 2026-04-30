using R3;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TickEveryNSecondsMono : MonoBehaviour
{
    [SerializeField] private Button m_button;
    [SerializeField] private TextMeshProUGUI m_buttonText;

    [SerializeField][Range(0f, 1f)] private float m_delay = 0.5f;

    private CompositeDisposable m_disposable = new();

    private int m_ticks = 0;

    private void Awake()
    {
        m_button.onClick.AddListener(() =>
        {
            TickEveryNSeconds();
        });
    }

    private void TickEveryNSeconds()
    {
        Observable
            .Interval(TimeSpan.FromSeconds(m_delay))
            .Subscribe(_ => AddTick())
            .AddTo(m_disposable);
    }

    private void AddTick()
    {
        m_ticks++;
        m_buttonText.text = m_ticks.ToString();
    }

    private void OnDestroy() => 
        m_disposable.Dispose();
}