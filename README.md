# Unity-Learning

Unity'yi adım adım öğrenmek için tutulan çalışma projesi. Şu an **UI Toolkit** dersleri üzerinde çalışılıyor.

## Gereksinimler

- **Unity 6.4 (6000.4.3f1)**, Unity Hub üzerinden. Başka bir sürümle açarsan Unity projeyi o sürüme yükseltmeyi önerir.
- **Git** ve **Git LFS**.
- **Kod editörü:** Visual Studio ya da VS Code (Unity eklentisiyle). Proje bunlar için `com.unity.ide.visualstudio` paketini içeriyor.
  Rider kullanacaksan Package Manager'dan `com.unity.ide.rider` paketini ekle.

## Projeyi açma

1. Repoyu OneDrive, Dropbox gibi senkronize edilen klasörlerin **dışına** klonla. Senkronizasyon, Unity'nin dosyalarını kilitleyip hatalara yol açabilir.

   ```bash
   git clone https://github.com/oguzhan07/Unity-Learning.git
   ```

2. Unity Hub'da `Projects > Add > Add project from disk` ile klonladığın klasörü seç.
3. İlk açılışta Unity `Library/` klasörünü oluşturur; bu birkaç dakika sürebilir.
4. Kod editörünü seç: `Edit > Preferences > External Tools > External Script Editor`.

## İçerik

| Klasör | Ne var? |
|--------|---------|
| [`Assets/UIToolkitDersleri/`](Assets/UIToolkitDersleri/README.md) | UI Toolkit dersleri ve yol haritası |
| [`Notlar/`](Notlar/) | Claude ile yapılan çalışma sohbetlerinin kayıtları |
| `Packages/` | Kullanılan paketler (`manifest.json`) ve tam sürümleri (`packages-lock.json`) |
| `ProjectSettings/` | Proje ayarları |

## Git notları

- **`.gitignore`**: Unity'nin ürettiği klasörler (`Library/`, `Temp/`, `Logs/`…) ve IDE dosyaları repoya girmez.
- **`.gitattributes`**: Satır sonlarını düzenler, sahne ve prefab gibi Unity YAML dosyaları için Smart Merge'ü tanımlar,
  görselleri, modelleri ve sesleri Git LFS'e yönlendirir.
- Her yeni bilgisayarda bir kez Git LFS'i etkinleştir:

  ```bash
  git lfs install
  ```

  Smart Merge sürücüsünü tanımlayan komutlar `.gitattributes` dosyasının içinde yazıyor.
