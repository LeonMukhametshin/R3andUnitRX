using R3;
using TMPro;
using UnityEngine;

public class CancelingEventListener : MonoBehaviour
{
    [SerializeField] private CancelingEventInvoker m_invoker;
    [SerializeField] private TextMeshProUGUI m_buttonText;
    
    private void Awake()
    {
        m_invoker.cancalingR3Event
            .Subscribe(counter => m_buttonText.text = counter.ToString())
            .AddTo(this);
    }
}