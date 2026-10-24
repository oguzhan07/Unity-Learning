# UI Toolkit Dersleri

Bu klasör, Unity'nin **UI Toolkit** sistemini adım adım öğrenmek için hazırlandı.
Her ders kendi klasöründe: bir sahne, UXML (yapı), USS (stil), C# (davranış) ve bir README.

Unity sürümü: **6000.4.3f1 (Unity 6.4)**

## Yol haritası

| # | Ders | Konu |
|---|------|------|
| 01 | [İlk Ekran](Ders01_IlkEkran/README.md) | UXML + USS + C# üçlüsü, UIDocument, PanelSettings, olaylar, class ile stil değiştirme |
| 02 | Layout | Flexbox derinlemesine, boyutlar, `position: absolute`, ekran ölçekleme |
| 03 | Kontroller ve olaylar | Slider, DropdownField, ScrollView, olay yayılımı (trickle-down / bubble-up), pointer olayları |
| 04 | Şablonlar ve listeler | UXML Template/Instance, `ListView` ile envanter ekranı |
| 05 | Veri bağlama | Unity 6 runtime data binding: veriyi UI'a kod yazmadan bağlamak |
| 06 | Geçişler ve animasyon | USS transition'ları, ekranlar arası geçiş |
| 07 | Özel kontroller | `[UxmlElement]` ile kendi UI elemanını yazmak |
| 08 | Editor araçları | Custom Inspector ve EditorWindow |
| 09 | Mini proje | Ana menü + ayarlar + oyun içi HUD |

## Yardımcı menü

`UI Toolkit Dersleri` menüsü, ders sahnelerini tek tıkla kurar (kodu: `Editor/DersKurulumu.cs`).
Sahne zaten varsa üzerine yazmaz, sadece açar. Play modundayken menü pasiftir.

## Faydalı pencereler

- **UI Builder**: `Window > UI Toolkit > UI Builder`. UXML/USS'i görsel olarak düzenlemek için.
- **UI Toolkit Debugger**: `Window > UI Toolkit > Debugger`. Tarayıcıdaki "Inspect Element" gibidir: bir elemanı seçip hangi stil kuralının uygulandığını görürsün.
