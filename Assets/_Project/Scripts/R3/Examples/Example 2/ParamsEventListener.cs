using R3;
using TMPro;
using UnityEngine;

public class ParamsEventListener : MonoBehaviour
{
    [SerializeField] private ParamsEventInvoker m_invoker;
    [SerializeField] private TextMeshProUGUI m_buttonText;
    
    private void Awake()
    {
        m_invoker.paramsR3Event
            .Where(counter => counter % 2 == 0)
            .Subscribe(counter => m_buttonText.text = counter.ToString())
            .AddTo(this);

        m_buttonText.text = "0";
    }
}