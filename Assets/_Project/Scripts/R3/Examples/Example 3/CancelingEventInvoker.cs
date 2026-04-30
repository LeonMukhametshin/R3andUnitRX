using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CancelingEventInvoker : MonoBehaviour
{
    [SerializeField] private Button m_button;
    [SerializeField] private TextMeshProUGUI m_buttonText;

    public readonly Subject<int> cancalingR3Event = new();

    private int m_counter = 0;

    private void Awake()
    {
        m_button.onClick.AddListener(OnButtonClicked);
        m_buttonText.text = m_counter.ToString();
    }

    private void OnButtonClicked()
    {
        m_counter++;
        m_buttonText.text = m_counter.ToString();
        cancalingR3Event.OnNext(m_counter);
        
        if(m_counter >= 10)
        {
            cancalingR3Event.OnCompleted();
        }
    }
}