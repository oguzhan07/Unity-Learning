# Ders 01: İlk Ekran

Bu derste ortada bir kart olan bir ekran yapıyoruz: bir sayaç, bir isim kutusu, koyu tema düğmesi ve bir "Sıfırla" butonu.
Amaç, UI Toolkit'in üç parçasının nasıl birlikte çalıştığını görmek.

## Çalıştırma

1. `Ders01.unity` sahnesini aç (sahne yoksa menüden: `UI Toolkit Dersleri > Ders 01 Sahnesini Kur`).
2. **Play**'e bas.
3. `+` / `-` butonlarına bas, isim yaz, koyu temayı aç, sonra "Sıfırla"ya bas.

## Büyük resim: üç dosya, üç görev

| Dosya | Görevi | Web'deki karşılığı |
|-------|--------|--------------------|
| `Ders01.uxml` | **Ne var?** Elemanlar ve iç içe yapıları | HTML |
| `Ders01.uss` | **Nasıl görünüyor?** Renk, boyut, yerleşim | CSS |
| `Ders01Controller.cs` | **Ne yapıyor?** Tıklamalar, değer değişimleri | JavaScript |

Bunları sahneye bağlayan iki parça daha var:

- **UIDocument** (sahnedeki `UI` objesinde): "Bu UXML'i ekrana koy" diyen bileşen.
- **PanelSettings** (`Ortak/DersPanelSettings.asset`): UI'ın ekrana *nasıl* çizileceği. Ölçekleme, tema, çizim sırası.
  İçindeki **Theme** (`Ortak/DersTemasi.tss`), Button, Toggle gibi hazır kontrollerin varsayılan görünümünü sağlar. Tema olmazsa kontroller stilsiz görünür.

## 1. UXML: yapı

UI Toolkit'te her şey bir **VisualElement**'tir. `Label`, `Button`, `TextField` da özelleşmiş VisualElement'lerdir.
Elemanlar bir ağaç oluşturur:

```
screen (VisualElement)
└── card (VisualElement)
    ├── Label        "Merhaba UI Toolkit!"
    ├── Label        açıklama
    ├── VisualElement  counter-row
    │   ├── Button   "-"
    │   ├── Label    "0"
    │   └── Button   "+"
    ├── TextField    "Adın"
    ├── Label        selamlama
    ├── Toggle       "Koyu tema"
    └── Button       "Sıfırla"
```

İki önemli özellik var:

- **`name`**: Elemanın kimliği. C# elemanı bununla bulur: `root.Q<Button>("increment-button")`. Tek olmalı.
- **`class`**: Stil grubu. Birden fazla eleman aynı class'ı paylaşabilir. Bir elemanın birden fazla class'ı olabilir.

Kural: **stil için class, C#'tan bulmak için name** kullan.

## 2. USS: stil

### Seçiciler

| Seçici | Anlamı | Bu derste |
|--------|--------|-----------|
| `.card` | class'ı `card` olan | kart |
| `#card` | name'i `card` olan | (kullanmadık, class tercih edilir) |
| `Label` | tipi Label olan | `.card.dark Label` |
| `.card .title` | `.card` içindeki (herhangi derinlikte) `.title` | |
| `.counter.negative` | **aynı elemanda** iki class birden | eksi sayı kırmızı |
| `:hover`, `:active` | fare üstündeyken / basılıyken | yuvarlak butonlar |

### Layout = Flexbox

UI Toolkit yerleşimi **Flexbox** ile yapar. Web'den farklı olarak varsayılan yön **`column`**'dur (alt alta).

- `flex-direction: row`: çocukları yan yana diz (`.counter-row`).
- `justify-content`: ana eksende hizala (column'da dikey, row'da yatay).
- `align-items`: çapraz eksende hizala.
- `flex-grow: 1`: boş alanı doldur (`.screen` tüm ekranı böyle kaplıyor).

### Özgüllük (specificity)

İki kural aynı elemana uyarsa **daha özgül olan** kazanır. Kabaca class sayısı fazla olan kazanır:

- `.card.dark Label` (2 class + 1 tip), `.title` (1 class) kuralını yener. Bu yüzden koyu temada başlık beyazlaşıyor.
- `.card .counter.negative` (3 class), `.card.dark Label`'ı yener. Bu yüzden koyu temada da eksi sayı kırmızı kalıyor.
- Unity'nin teması da butonlara `:hover` rengi veriyor. Bizim `.card .round-button:hover` kuralımız daha özgül olduğu için bizimki görünüyor.

### Unity'ye özel noktalar

- Unity'ye özgü özellikler `-unity-` ile başlar: `-unity-font-style`, `-unity-text-align`.
- Birim olarak `px` ve `%` kullanılır.
- `transition-property` ve `transition-duration`: kod yazmadan yumuşak geçiş (kart rengi, buton küçülmesi).

## 3. C#: davranış

`Ders01Controller.cs` dört şey yapıyor:

1. **Kökü al.** `GetComponent<UIDocument>().rootVisualElement`. Bunu `OnEnable`'da yapıyoruz, çünkü UIDocument ağacı kendi `OnEnable`'ında kurar (ve bizden önce çalışır).
2. **Elemanları bul.** `root.Q<Label>("counter-label")`. `Q` = Query.
3. **Olaylara abone ol.**
   - Buton: `button.clicked += Metot;`
   - Değer tutan kontroller (TextField, Toggle, Slider…): `field.RegisterValueChangedCallback(Metot);` → `ChangeEvent<T>` gelir; `evt.newValue` yeni değerdir.
   - `OnDisable`'da aboneliklerden çıkıyoruz.
4. **Durumu ekrana yansıt.** `_count` değişkeni asıl veridir. Değişince `Refresh()` çağrılır ve ekran güncellenir. Ekranı güncelleyen tek bir yer olması, hataları azaltır.

### Görünümü C#'ta değil USS'te tut

Koyu temada C# rengi kendisi değiştirmiyor. Sadece class ekliyor:

```csharp
_card.EnableInClassList("dark", evt.newValue);
```

Renklerin hepsi USS'te, `.card.dark` kurallarında. Böylece tasarımı değiştirmek için koda dokunman gerekmez.

## Kendin kurmak istersen (elle kurulum)

Yardımcı menünün yaptığını elle yapmak için:

1. Project penceresinde sağ tık → `Create > UI Toolkit > Panel Settings Asset`. Unity bir tema dosyası da oluşturur.
2. Sahnede boş bir GameObject oluştur → `Add Component > UI Document`.
3. UI Document'in **Panel Settings** alanına oluşturduğun asset'i, **Source Asset** alanına UXML dosyanı sürükle.
4. Aynı objeye kendi controller script'ini ekle.

## UI Builder ile bak

`Ders01.uxml`'e çift tıkla; UI Builder açılır. Soldaki **Hierarchy**'de ağacı, sağdaki **Inspector**'da her elemanın özelliklerini ve stillerini görürsün.
Bir şeyi UI Builder'da değiştirip kaydettiğinde UXML dosyasının nasıl değiştiğine bak. Bu, UXML okumayı öğrenmenin hızlı bir yolu.

## Alıştırmalar

1. **Kolay:** Başlık metnini ve kart rengini değiştir. Hangisi UXML'de, hangisi USS'te?
2. **Kolay:** Karta bir `×2` butonu ekle. Bastıkça sayaç ikiyle çarpılsın (UXML'e buton ekle, C#'ta bul ve `clicked`'e abone ol).
3. **Orta:** Sayaç 10 olunca `+` butonunu devre dışı bırak: `_incrementButton.SetEnabled(_count < 10);`. Sonra USS'te `.card .round-button:disabled` ile soluk göster (ipucu: `opacity: 0.4;`).
4. **Orta:** Kart genişliğini `480px` yerine `40%` yap. Game penceresini boyutlandırıp farkı izle.
5. **Zor:** Koyu temada TextField'ın yazı alanı hâlâ açık renk. `Window > UI Toolkit > Debugger` ile o iç elemanı seç, class'ını bul ve `.card.dark` altında koyulaştır.
