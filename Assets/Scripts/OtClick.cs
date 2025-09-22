using UnityEngine;
using UnityEngine.UI;

public class OtClick : MonoBehaviour
{
    private SaksiController saksiController;
    private Button button;
    
    void Start()
    {
        // SaksiController'ı bul
        saksiController = FindFirstObjectByType<SaksiController>();
        
        // Button component'ini al
        button = GetComponent<Button>();
        
        // Button event'ini bağla
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }
    
    public void OnClick()
    {
        Debug.Log("Ot'a tıklandı!");
        
        if (saksiController != null)
        {
            saksiController.OtHasatEt();
            
            // Bu ot'u gizle
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("SaksiController bulunamadı!");
        }
    }
}
