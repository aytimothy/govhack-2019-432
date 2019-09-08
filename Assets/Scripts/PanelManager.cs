using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace OpenSims.Common.UI {
    public class PanelManager : MonoBehaviour {
        public List<PanelManagerPanel> panels;
        public int startupPanelID = 0;
        [SerializeField] 
        public int currentPanelID = -1;

        void Start() {

        }

        public void SwitchPanel(int index) {
            if (index > panels.Count) throw new IndexOutOfRangeException();
            if (currentPanelID >= 0) {
                panels[currentPanelID].Hide();
            }
            currentPanelID = index;
            if (currentPanelID >= 0) {
                panels[currentPanelID].Show();
            }
        }

        public void SwitchPanel(string id) {
            for (int i = 0; i < panels.Count; i++)
                if (panels[i].panelID == id) {
                    SwitchPanel(i);
                    return;
                }

            Debug.LogError("Cannot find panel with ID \"" + id + "\".", gameObject);
        }
    }

    [Serializable]
    public class PanelManagerPanel {
        public GameObject[] panelObjects;
        public string panelID;

        public void Show() {
            foreach (GameObject panelObject in panelObjects)
                panelObject.SetActive(true);
        }

        public void Hide() {
            foreach (GameObject paneLObject in panelObjects)
                paneLObject.SetActive(false);
        }
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(PanelManager))]
    public class PanelManagerEditor : Editor {
        public PanelManager component => (PanelManager)target;
        int currentPanel = 0;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (!Application.isPlaying) {
                currentPanel = EditorGUILayout.IntSlider(component.currentPanelID, 0, component.panels.Count - 1);
                if (currentPanel != component.currentPanelID) {
                    component.currentPanelID = currentPanel;
                    for (int i = 0; i < component.panels.Count; i++) {
                        if (i == component.currentPanelID) component.panels[i].Show();
                        if (i != component.currentPanelID) component.panels[i].Hide();
                    }
                }
            }
        }
    }
    #endif
}