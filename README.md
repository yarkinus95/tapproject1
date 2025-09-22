# 🌱 Weed Growing Idle Game - Unity

2D idle tap clicker oyunu - Unity ile geliştirilmiştir. iOS ve Android için publish edilebilir.

## 🎯 Oyun Özellikleri

- **2 Ana Sahne**: Garaj (Büyütme) ve Satış Alanı
- **Idle Gameplay**: Otomatik para kazanma sistemi
- **Bitki Çeşitleri**: Farklı türlerde bitkiler
- **Alıcı Sistemi**: Bitkileri satma mekaniği
- **Offline Oyun**: İnternet olmadan oynanabilir
- **Opsiyonel Reklamlar**: Kullanıcı tercihine bağlı

## 🛠 Teknoloji Stack

- **Engine**: Unity 2022.3 LTS
- **Scripting**: C#
- **Platform**: iOS, Android
- **Reklamlar**: Unity Ads
- **Analytics**: Unity Analytics
- **Build**: Unity Cloud Build (opsiyonel)

## 📁 Proje Yapısı

```
Assets/
├── Scripts/                  # C# Scripts
│   ├── Game/                 # Oyun mantığı
│   ├── UI/                   # UI Scripts
│   ├── Managers/             # Game Manager, Audio Manager
│   ├── Data/                 # Scriptable Objects
│   └── Utils/                # Yardımcı sınıflar
├── Scenes/                   # Unity Scenes
│   ├── MainMenu.unity
│   ├── Garage.unity
│   └── Market.unity
├── Prefabs/                  # Prefab'lar
│   ├── Plants/               # Bitki prefab'ları
│   ├── UI/                   # UI prefab'ları
│   └── Effects/              # Efekt prefab'ları
├── Sprites/                  # 2D Görseller
│   ├── Plants/               # Bitki sprite'ları
│   ├── UI/                   # UI sprite'ları
│   └── Backgrounds/          # Arka plan görselleri
├── Audio/                    # Ses dosyaları
│   ├── SFX/                  # Ses efektleri
│   └── Music/                # Müzik
├── Animations/               # Animasyon dosyaları
├── Materials/                # Material'lar
├── Fonts/                    # Font dosyaları
└── StreamingAssets/          # Streaming Assets
```

## 👥 Geliştirici Ekip

- **Game Designer**: Oyun mekaniği ve tasarım
- **Programmer**: C# kodlama ve sistem entegrasyonu
- **Artist**: 2D sanat ve animasyonlar

## 🚀 Kurulum

### Gereksinimler
- Unity 2022.3 LTS
- Visual Studio Code veya Visual Studio
- Git

### Kurulum Adımları
1. Unity Hub'ı indir ve kur
2. Unity 2022.3 LTS'i kur
3. Projeyi klonla:
   ```bash
   git clone [repository-url]
   cd weed-growing-game
   ```
4. Unity Hub'da "Open" → Proje klasörünü seç
5. Unity'de projeyi aç

## 📱 Platform Desteği

- iOS 12.0+
- Android 8.0+ (API 26+)
- Tablet desteği
- Offline çalışma

## 🎮 Oyun Mekaniği

### Garaj Sahnesi
- Bitki ekme ve büyütme
- Otomatik sulama sistemi
- Para kazanma (tap/click)
- Yeni bitki türleri açma

### Satış Sahnesi
- Bitki satışı
- Alıcı sistemi
- Fiyat optimizasyonu
- Pazar analizi

## 🔧 Geliştirme Kuralları

1. **Script Organizasyonu**: Her script kendi klasöründe
2. **Naming Convention**: PascalCase (PlayerController.cs)
3. **Prefab Kullanımı**: Tekrar kullanılabilir objeler için
4. **Scene Yönetimi**: Her sahne ayrı dosya
5. **Asset Organizasyonu**: Klasörlere göre düzenle

## 📋 Milestone'lar

### Phase 1: Temel Yapı (1-2 hafta)
- [ ] Unity proje kurulumu
- [ ] Temel scene'ler
- [ ] Ana menü
- [ ] Temel UI sistemi

### Phase 2: Oyun Mekaniği (2-3 hafta)
- [ ] Garaj scene'i
- [ ] Bitki büyütme sistemi
- [ ] Para kazanma mekaniği
- [ ] Data persistence

### Phase 3: Satış Sistemi (1-2 hafta)
- [ ] Satış scene'i
- [ ] Alıcı sistemi
- [ ] Fiyat optimizasyonu

### Phase 4: Optimizasyon (1 hafta)
- [ ] Performance optimizasyonu
- [ ] Reklam entegrasyonu
- [ ] Final testing

### Phase 5: Release (1 hafta)
- [ ] App Store hazırlığı
- [ ] Google Play hazırlığı
- [ ] Marketing materyalleri
- [ ] Launch