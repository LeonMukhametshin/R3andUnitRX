using R3;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoSomethingWithDelayMono : MonoBehaviour
{
    [SerializeField] private Button m_button;
    [SerializeField] private TextMeshProUGUI m_buttonText;

    [SerializeField][Range(0f, 5f)] private float m_delay = 4f;

    private CompositeDisposable m_disposable = new();

    private void Awake()
    {
        m_button.onClick.AddListener(() =>
        {
            DoSomethingWithDelay();
        });
    }

    private void DoSomethingWithDelay()
    {
        m_buttonText.text = "In progress..";

        Observable
            .Timer(TimeSpan.FromSeconds(m_delay))
            .Subscribe(_ => DoSomething())
            .AddTo(m_disposable);
    }

    private void DoSomething() => 
        m_buttonText.text = "Ready!";

    private void OnDestroy() => 
        m_disposable.Dispose();
}