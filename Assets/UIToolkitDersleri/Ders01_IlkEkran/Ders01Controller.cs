using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitDersleri.Ders01
{
    /// <summary>
    /// Ders01.uxml'deki elemanları bulur ve onlara davranış ekler.
    /// UIDocument ile aynı GameObject üzerinde durmalıdır.
    /// </summary>
    [RequireComponent(typeof(UIDocument))]
    public class Ders01Controller : MonoBehaviour
    {
        // Uygulamanın "durumu" (state). Ekrandaki sayı bu verinin bir yansımasıdır.
        int _count;

        // UXML'den bulacağımız elemanlar
        VisualElement _card;
        Label _counterLabel;
        Label _greetingLabel;
        Button _incrementButton;
        Button _decrementButton;
        Button _resetButton;
        TextField _nameField;
        Toggle _darkModeToggle;

        void OnEnable()
        {
            // UIDocument, UXML'i kendi OnEnable'ında kurar ve bizden önce çalışır;
            // bu yüzden rootVisualElement burada hazırdır.
            var root = GetComponent<UIDocument>().rootVisualElement;

            // Q<T>("isim") = Query: ağaçta bu tipte ve bu isimde ilk elemanı bulur.
            _card = root.Q<VisualElement>("card");
            _counterLabel = root.Q<Label>("counter-label");
            _greetingLabel = root.Q<Label>("greeting-label");
            _incrementButton = root.Q<Button>("increment-button");
            _decrementButton = root.Q<Button>("decrement-button");
            _resetButton = root.Q<Button>("reset-button");
            _nameField = root.Q<TextField>("name-field");
            _darkModeToggle = root.Q<Toggle>("dark-mode-toggle");

            // Butonlar: en basit olay "clicked"
            _incrementButton.clicked += Increment;
            _decrementButton.clicked += Decrement;
            _resetButton.clicked += ResetAll;

            // Değer tutan kontroller (TextField, Toggle, Slider...): değer değişince ChangeEvent<T> gelir
            _nameField.RegisterValueChangedCallback(OnNameChanged);
            _darkModeToggle.RegisterValueChangedCallback(OnDarkModeChanged);

            Refresh();
        }

        void OnDisable()
        {
            // Abone olduğumuz her olaydan çıkıyoruz; obje yeniden açılınca olaylar çift tetiklenmesin.
            _incrementButton.clicked -= Increment;
            _decrementButton.clicked -= Decrement;
            _resetButton.clicked -= ResetAll;
            _nameField.UnregisterValueChangedCallback(OnNameChanged);
            _darkModeToggle.UnregisterValueChangedCallback(OnDarkModeChanged);
        }

        void Increment()
        {
            _count++;
            Refresh();
        }

        void Decrement()
        {
            _count--;
            Refresh();
        }

        void ResetAll()
        {
            _count = 0;
            // value'yu koddan değiştirmek de ChangeEvent tetikler,
            // yani OnNameChanged ve OnDarkModeChanged kendiliğinden çalışır.
            _nameField.value = string.Empty;
            _darkModeToggle.value = false;
            Refresh();
        }

        void OnNameChanged(ChangeEvent<string> evt)
        {
            _greetingLabel.text = string.IsNullOrWhiteSpace(evt.newValue)
                ? "Bir isim yaz..."
                : $"Merhaba, {evt.newValue.Trim()}!";
        }

        void OnDarkModeChanged(ChangeEvent<bool> evt)
        {
            // Görünüm kararı USS'te; C# sadece class ekler ya da çıkarır.
            _card.EnableInClassList("dark", evt.newValue);
        }

        // Durumu ekrana yansıtan tek yer. Durum değişince bunu çağırırız.
        void Refresh()
        {
            _counterLabel.text = _count.ToString();
            _counterLabel.EnableInClassList("negative", _count < 0);
        }
    }
}
