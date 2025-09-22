using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaksiController : MonoBehaviour
{
    public enum SaksiState
    {
        Bos,        // Boş saksı
        Ekili,      // Tohum ekilmiş, büyüyor
        Kurumus,    // Ot kurumuş, tekrar tohum gerekli
        Hasat       // Ot hasat edilebilir
    }
    
    [Header("Saksı Ayarları")]
    public SaksiState currentState = SaksiState.Bos;
    public int saksıLevel = 1;
    public int coin = 0;
    
    [Header("Timer Ayarları")]
    public float otKurumaSuresi = 10800f; // 3 saat = 10800 saniye
    public float otUretimSuresi = 10f; // 10 saniyede bir ot üret
    
    [Header("UI Referansları")]
    public Button tohumEkleButton;
    public Button levelUpButton;
    public Button otUretButton;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timerText;
    public GameObject ot1;
    public GameObject ot2;
    public GameObject ot3;
    public GameObject ot4;
    
    [Header("Ot Ayarları")]
    public int otMiktari = 0;
    public int maxOtMiktari = 4; // Maksimum 4 ot
    public int otUretimMiktari = 4; // Her seferinde 4 ot üret
    public int toplananOtMiktari = 0; // Toplanan ot sayısı
    
    private float timer;
    private bool timerAktif = false;
    private Coroutine otUretimCoroutine;
    
    void Start()
    {
        // Ot'ları başlangıçta gizle
        if (ot1 != null) ot1.SetActive(false);
        if (ot2 != null) ot2.SetActive(false);
        if (ot3 != null) ot3.SetActive(false);
        if (ot4 != null) ot4.SetActive(false);
            
        // UI güncelle
        UpdateUI();
        
        // Buton event'lerini bağla
        if (tohumEkleButton != null)
            tohumEkleButton.onClick.AddListener(TohumEkle);
        if (levelUpButton != null)
            levelUpButton.onClick.AddListener(LevelUp);
        if (otUretButton != null)
            otUretButton.onClick.AddListener(OtUret);
    }
    
    void Update()
    {
        // Timer güncelle
        if (timerAktif)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();
            
            if (timer <= 0)
            {
                OtKurudu();
            }
        }
    }
    
    public void TohumEkle()
    {
        if (currentState == SaksiState.Bos || currentState == SaksiState.Kurumus)
        {
            currentState = SaksiState.Ekili;
            timer = otKurumaSuresi;
            timerAktif = true;
            
            Debug.Log("Tohum eklendi! Ot büyümeye başladı.");
            UpdateUI();
        }
    }
    
    public void LevelUp()
    {
        int levelUpCost = saksıLevel * 10; // Her level 10 coin daha pahalı
        
        if (coin >= levelUpCost)
        {
            coin -= levelUpCost;
            saksıLevel++;
            
            // Level artınca ot üretim süresi 0.5 saniye azalır
            otUretimSuresi = Mathf.Max(1f, 10f - (saksıLevel - 1) * 0.5f);
            
            Debug.Log($"Level up! Yeni level: {saksıLevel}, Ot üretim süresi: {otUretimSuresi} saniye");
            UpdateUI();
        }
        else
        {
            Debug.Log("Yeterli coin yok!");
        }
    }
    
    public void OtUret()
    {
        if (currentState == SaksiState.Ekili && otMiktari == 0)
        {
            if (otUretimCoroutine != null)
                StopCoroutine(otUretimCoroutine);
                
            otUretimCoroutine = StartCoroutine(OtUretimCoroutine());
            
            // Butonu hemen pasif yap
            if (otUretButton != null)
                otUretButton.interactable = false;
        }
    }
    
    private IEnumerator OtUretimCoroutine()
    {
        yield return new WaitForSeconds(otUretimSuresi);
        
        otMiktari = otUretimMiktari; // 4 ot üret
        toplananOtMiktari = 0; // Toplanan ot sayısını sıfırla
        Debug.Log($"{otUretimMiktari} ot üretildi! Toplam ot: {otMiktari}");
        
        // 4 ot'u görünür yap
        if (ot1 != null) ot1.SetActive(true);
        if (ot2 != null) ot2.SetActive(true);
        if (ot3 != null) ot3.SetActive(true);
        if (ot4 != null) ot4.SetActive(true);
            
        UpdateUI();
    }
    
    public void OtHasatEt()
    {
        if (otMiktari > 0)
        {
            otMiktari--; // 1 ot azalt
            toplananOtMiktari++; // Toplanan ot sayısını artır
            coin += 5; // Her ot 5 coin
            
            Debug.Log($"1 ot hasat edildi! Kalan ot: {otMiktari}, Toplanan: {toplananOtMiktari}");
            
            // Tüm otlar toplandıysa ot'ları gizle
            if (otMiktari == 0)
            {
                if (ot1 != null) ot1.SetActive(false);
                if (ot2 != null) ot2.SetActive(false);
                if (ot3 != null) ot3.SetActive(false);
                if (ot4 != null) ot4.SetActive(false);
                
                // Tüm otlar toplandı, butonu tekrar aktif yap
                if (otUretButton != null)
                    otUretButton.interactable = true;
            }
                
            UpdateUI();
        }
    }
    
    private void OtKurudu()
    {
        currentState = SaksiState.Kurumus;
        timerAktif = false;
        otMiktari = 0;
        toplananOtMiktari = 0;
        
        // Ot'ları gizle
        if (ot1 != null) ot1.SetActive(false);
        if (ot2 != null) ot2.SetActive(false);
        if (ot3 != null) ot3.SetActive(false);
        if (ot4 != null) ot4.SetActive(false);
            
        Debug.Log("Ot kurudu! Tekrar tohum ekmen gerekiyor.");
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        // Text'leri güncelle
        if (coinText != null)
            coinText.text = $"Coin: {coin}";
        if (levelText != null)
            levelText.text = $"Level: {saksıLevel}";
            
        // Buton durumlarını güncelle
        if (tohumEkleButton != null)
            tohumEkleButton.interactable = (currentState == SaksiState.Bos || currentState == SaksiState.Kurumus);
        if (levelUpButton != null)
            levelUpButton.interactable = (coin >= saksıLevel * 10);
        if (otUretButton != null)
            otUretButton.interactable = (currentState == SaksiState.Ekili && otMiktari == 0);
    }
    
    private void UpdateTimerUI()
    {
        if (timerText != null && timerAktif)
        {
            int dakika = Mathf.FloorToInt(timer / 60);
            int saniye = Mathf.FloorToInt(timer % 60);
            timerText.text = $"Timer: {dakika:00}:{saniye:00}";
        }
    }
    
    // Ot'a tıklandığında çağrılacak
    void OnMouseDown()
    {
        if (otMiktari > 0)
        {
            OtHasatEt();
        }
    }
}
