using UIToolkitDersleri.Ders01;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitDersleri.EditorTools
{
    /// <summary>
    /// Ders sahnelerini tek tıkla kuran yardımcı. Dersin konusu değildir;
    /// aynı kurulumun elle nasıl yapıldığı Ders 01 README'sinde anlatılıyor.
    /// </summary>
    public static class DersKurulumu
    {
        const string RootFolder = "Assets/UIToolkitDersleri";
        const string ThemePath = RootFolder + "/Ortak/DersTemasi.tss";
        const string PanelSettingsPath = RootFolder + "/Ortak/DersPanelSettings.asset";

        const string Ders01Folder = RootFolder + "/Ders01_IlkEkran";

        [MenuItem("UI Toolkit Dersleri/Ders 01 Sahnesini Kur")]
        public static void KurDers01()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                return;

            // Sahne zaten varsa üzerine yazmıyoruz, sadece açıyoruz.
            var scenePath = Ders01Folder + "/Ders01.unity";
            if (AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath) != null)
            {
                EditorSceneManager.OpenScene(scenePath);
                return;
            }

            var uxml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(Ders01Folder + "/Ders01.uxml");
            if (uxml == null)
            {
                Debug.LogError($"UXML bulunamadı: {Ders01Folder}/Ders01.uxml");
                return;
            }

            var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

            var ui = new GameObject("UI");
            var document = ui.AddComponent<UIDocument>();
            document.panelSettings = GetOrCreatePanelSettings();
            document.visualTreeAsset = uxml;
            ui.AddComponent<Ders01Controller>();

            EditorSceneManager.SaveScene(scene, scenePath);
            Debug.Log($"Ders 01 sahnesi hazır: {scenePath}");
        }

        static PanelSettings GetOrCreatePanelSettings()
        {
            var panelSettings = AssetDatabase.LoadAssetAtPath<PanelSettings>(PanelSettingsPath);
            if (panelSettings != null)
                return panelSettings;

            panelSettings = ScriptableObject.CreateInstance<PanelSettings>();
            // Tema: Button, Toggle, TextField gibi hazır kontrollerin varsayılan görünümü.
            panelSettings.themeStyleSheet = AssetDatabase.LoadAssetAtPath<ThemeStyleSheet>(ThemePath);
            // UI, 1920x1080 referans alınarak ekran boyutuna göre ölçeklensin.
            panelSettings.scaleMode = PanelScaleMode.ScaleWithScreenSize;
            panelSettings.referenceResolution = new Vector2Int(1920, 1080);
            panelSettings.match = 0.5f;
            AssetDatabase.CreateAsset(panelSettings, PanelSettingsPath);
            return panelSettings;
        }
    }
}
