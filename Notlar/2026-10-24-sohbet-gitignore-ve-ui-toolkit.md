# Sohbet Kaydı: .gitignore Kurulumu ve UI Toolkit Ders 01

- **Tarih:** 24–25 Ekim 2026
- **Katılımcılar:** oguzhan07 ve Claude (Claude Code)
- **Repo:** [oguzhan07/Unity-Learning](https://github.com/oguzhan07/Unity-Learning)

## Özet

1. Unity projeleri için standart bir `.gitignore` hazırlandı ve projeye eklendi.
2. `.gitignore` ayrı bir dalda commit edildi, [PR #1](https://github.com/oguzhan07/Unity-Learning/pull/1) ile `main`'e merge edildi.
3. UI Toolkit öğrenme serisi başlatıldı: Ders 01 (UXML + USS + C#) dosyaları `Assets/UIToolkitDersleri/` altına eklendi.
4. Ders dosyaları, `Packages/` ve `ProjectSettings/` oguzhan07 tarafından `7929d01 Laptop` commit'iyle `main`'e gönderildi.

Mesajlar yazıldıkları dilde bırakıldı. *İtalik* satırlar, Claude'un o adımda yaptığı işlemleri özetler.

---

## 1. Unity için .gitignore

**oguzhan07:**
> Bir unity projesinde olması gereken gitignore'ları verir misin ?,

**Claude:**

Aşağıdaki, GitHub'ın resmi `Unity.gitignore` şablonuna dayanıyor; birkaç ek satır da var (işletim sistemi ve editör dosyaları için).

**Önemli:** Satırların başındaki `/` işareti, yolun `.gitignore` dosyasının bulunduğu klasörden itibaren sayılacağını söyler. Bu yüzden dosya, Unity projesinin kök klasöründe olmalı, yani `Assets` klasörünün yanında.

> İçeriğin tamamı repodaki [`.gitignore`](../.gitignore) dosyasında. Bölümler: Unity tarafından üretilen klasörler (`Library`, `Temp`, `Obj`, `Build`, `Logs`, `UserSettings`…), Blender yedekleri, IDE dosyaları (Visual Studio / Rider / VS Code), çökme ve Mono dosyaları, build çıktıları, Test Runner, Addressables, Visual Scripting ve işletim sistemi dosyaları.

### Kesinlikle commit edilmesi gerekenler
- **`Assets/`**: oyunun tüm içeriği.
- **`.meta` dosyaları**: Bunları asla ignore etme. Unity varlıklar arasındaki bağlantıları bu dosyalardaki GUID'lerle tutar. Eksik olurlarsa sahnelerdeki ve prefab'lardaki referanslar kopar.
- **`Packages/`**: içindeki `manifest.json` ve `packages-lock.json` dosyaları.
- **`ProjectSettings/`**

### Ek ipuçları
- `Library/` gibi bir klasörü daha önce commit ettiysen, `.gitignore`'a eklemek yetmez. Önce Git'in takibinden çıkarman gerekir: `git rm -r --cached Library`
- Büyük dosyalar (`.psd`, `.fbx`, ses dosyaları gibi) için **Git LFS** ve bir `.gitattributes` dosyası kullanman önerilir.

---

## 2. .gitignore dosyasını oluşturma

**oguzhan07:**
> Evet, bu .gitignore dosyasını Unity-Learning klasörüne oluştur.

**Claude:**

*İşlem: `.gitignore` oluşturuldu ve kurallar `git check-ignore` ile denendi.*

| Örnek yol | Sonuç |
|---|---|
| `Library/...` | Yok sayılıyor ✅ |
| `Temp/...` | Yok sayılıyor ✅ |
| `Assembly-CSharp.csproj` | Yok sayılıyor ✅ |
| `Assets/a.cs.meta` | Takip ediliyor ✅ |
| `Assets/Scenes/Main.unity` | Takip ediliyor ✅ |

---

## 3. Commit

**oguzhan07:**
> Commit the working tree changes with a sensible message.

**Claude:**

*İşlem: `main` varsayılan dal olduğu için `add-unity-gitignore` dalı açıldı ve `.gitignore` commit edildi.*

I committed the `.gitignore` as `8eb588e`, with the message **"Add Unity .gitignore"**, on a new branch called `add-unity-gitignore`. You were on `main`, the repo's default branch, so I made a new branch for the commit instead of committing to `main` directly. Nothing has been pushed to GitHub.

---

## 4. Push ve pull request

**oguzhan07:**
> Push add-unity-gitignore to origin and open a pull request into main.

**Claude:**

*İşlem: Dal push edildi ve PR açıldı.*

I pushed `add-unity-gitignore` and opened a pull request into `main`: [oguzhan07/Unity-Learning#1](https://github.com/oguzhan07/Unity-Learning/pull/1). GitHub says it can be merged with no conflicts.

The first attempt to open the PR failed. The `gh` command-line tool was signed in with another GitHub account that isn't a collaborator on this repo. I ran that one command again as `oguzhan07`, so the PR is authored by the repo owner. To make `oguzhan07` the default `gh` account:

```bash
gh auth switch --user oguzhan07
```

---

## 5. Merge

**oguzhan07:**
> Merge PR #1 into main as oguzhan07, delete the add-unity-gitignore branch, and update local main.

**Claude:**

*İşlem: PR merge edildi, dal hem GitHub'da hem yerelde silindi, yerel `main` güncellendi.*

- **Merge:** GitHub's standard "Create a merge commit" option. The merge commit is `001f868`.
- **Branch:** `add-unity-gitignore` is deleted on GitHub and on your computer.
- **Local main:** matches `origin/main`, and `.gitignore` is in it.

---

## 6. UI Toolkit öğrenmeye başlangıç: Ders 01

**oguzhan07:**
> Bana bu proje üzerinden Unity UI ToolKit'i anlatmanı, öğretmeni istiyorum.

**Claude:**

*İşlem: Ders 01 dosyaları yazıldı. Unity batch modda sahneyi kurmak için çalıştırıldı ama proje zaten açık olduğu için ikinci bir Unity onu açamadı. Açık olan Unity 6.4 editörü dosyaları içe aktardı ve iki script de hatasız derlendi.*

İlk dersi projeye koydum. Dersin sahnesi ise oluşmadı; sahneyi aşağıdaki menüyle sen kuracaksın.

### Çalıştırmak için

1. Unity'nin üst menüsünden **UI Toolkit Dersleri → Ders 01 Sahnesini Kur**'a tıkla. Sahne oluşur ve açılır.
2. **Play**'e bas.
3. `+` / `-` butonlarına bas, isim yaz, koyu temayı aç, sonra **Sıfırla**'ya bas.

### Ders 01: Büyük resim

UI Toolkit, web'deki HTML / CSS / JavaScript üçlüsüne çok benzer:

| Dosya | Görevi | Web'deki karşılığı |
|---|---|---|
| [Ders01.uxml](../Assets/UIToolkitDersleri/Ders01_IlkEkran/Ders01.uxml) | **Ne var?** Elemanlar ve iç içe yapıları | HTML |
| [Ders01.uss](../Assets/UIToolkitDersleri/Ders01_IlkEkran/Ders01.uss) | **Nasıl görünüyor?** Renk, boyut, yerleşim | CSS |
| [Ders01Controller.cs](../Assets/UIToolkitDersleri/Ders01_IlkEkran/Ders01Controller.cs) | **Ne yapıyor?** Tıklamalar, değer değişimleri | JavaScript |

Bunları sahneye iki parça bağlar:
- **UIDocument**, sahnedeki bir bileşendir ve "bu UXML'i ekrana koy" der.
- **PanelSettings**, arayüzün ekrana nasıl çizileceğini belirler: ölçekleme ve tema gibi. İçindeki tema dosyası olmazsa Button, Toggle gibi hazır kontroller stilsiz görünür.

#### 1. UXML: Her şey bir VisualElement

Arayüz bir ağaçtır: `Label`, `Button`, `TextField` hepsi özelleşmiş birer `VisualElement`. Elemanların iki önemli özelliği var:

```xml
<ui:Button name="increment-button" text="+" class="round-button" />
```
- **`name`**: Kimlik. C# elemanı bununla bulur ve her elemanda farklı olmalı.
- **`class`**: Stil grubu. Birçok eleman aynı class'ı paylaşabilir.

Kural: **stil vermek için class, C#'tan bulmak için name** kullan.

#### 2. USS: Yerleşim Flexbox ile yapılır

```css
.counter-row { flex-direction: row; }   /* varsayılan "column" (alt alta) */
.card .round-button:hover { ... }        /* fare üstündeyken, C# gerekmez */
.card.dark Label { ... }                 /* koyu karttaki tüm Label'lar */
```
Web'den en önemli fark: varsayılan yön **`column`**, yani elemanlar alt alta dizilir. İki kural aynı elemana uyarsa **daha özgül olan** (kabaca daha çok class içeren) kazanır. Bu yüzden koyu temada eksi sayı hâlâ kırmızı kalıyor.

#### 3. C#: Bul, abone ol, güncelle

```csharp
var root = GetComponent<UIDocument>().rootVisualElement;   // OnEnable'da hazırdır
_counterLabel = root.Q<Label>("counter-label");             // Q = Query, name ile bul
_incrementButton.clicked += Increment;                      // buton olayı
_nameField.RegisterValueChangedCallback(OnNameChanged);     // değer değişimi olayı
_card.EnableInClassList("dark", evt.newValue);              // class ekle ya da çıkar
```
Bu dersin en önemli fikri son satırda: **C# rengi kendisi değiştirmiyor, sadece class ekliyor.** Görünüm kararlarının hepsi USS'te duruyor. Böylece tasarımı değiştirmek için koda dokunman gerekmiyor.

### Sırada ne var?

Ayrıntılı notlar ve beş alıştırma [Ders 01 README](../Assets/UIToolkitDersleri/Ders01_IlkEkran/README.md) dosyasında. Alıştırmalar kolaydan zora gidiyor: `×2` butonu ekleme, `:disabled` stili ve Debugger ile iç elemanı bulma. Dokuz derslik yol haritası da [genel README](../Assets/UIToolkitDersleri/README.md) dosyasında.

Deneyeceğin iki pencere:
- **UI Builder** (`Window > UI Toolkit > UI Builder`): `Ders01.uxml`'e çift tıklayınca açılır.
- **Debugger** (`Window > UI Toolkit > Debugger`): Tarayıcıdaki "Inspect Element" gibi çalışır.

---

## 7. Sohbeti projeye kaydetme

**oguzhan07:**
> Bu sohbeti proje dosyalarına koyar mısın bir md dosyası hazırlayıp onu da koy ve push

**Claude:**

*İşlem: Bu dosya (`Notlar/2026-10-24-sohbet-gitignore-ve-ui-toolkit.md`) oluşturuldu, commit edildi ve push edildi. Repo herkese açık olduğu için sohbette geçen diğer GitHub hesabının adı bu kayda yazılmadı.*
