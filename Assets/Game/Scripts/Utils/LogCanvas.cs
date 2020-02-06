using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogCanvas : MonoBehaviour
{
    [Header("UI")]
        [Tooltip("Parent canvas displaying the log")]
        public GameObject canvas;
        [Tooltip("Placeholder for the Log messages")]
        public VerticalLayoutGroup verticalLayout;
        [Tooltip("Prefab containing a Text object to add to the layout")]
        public GameObject textPrefab;
        [Tooltip("Set to true to allow the log only on dev build")]
        public bool devBuildOnly = true;

        [Header("Max Messages")]
        [Tooltip("The max message to be in the log console")]
        public int maxMessage = 8;
        private Queue<GameObject> currentLogMessages;

        private bool currentToggleButtonState;

        private void Awake()
        {
            currentLogMessages = new Queue<GameObject>(maxMessage);
        }

        private void Start()
        {
            canvas.SetActive( true);
        }

        #region Callback
        /// <summary>
        /// Listen to log messages
        /// </summary>
        void OnEnable()
        {
            if (!devBuildOnly || Debug.isDebugBuild)
            {
                Application.logMessageReceived += HandleLog;
            }
        }

        /// <summary>
        /// Detach callback for log message
        /// </summary>
        void OnDisable()
        {
            if (!devBuildOnly || Debug.isDebugBuild)
            {
                Application.logMessageReceived -= HandleLog;
            }
        }
        #endregion

        #region Log
        /// <summary>
        /// Instantiate a new textPRefab containing the log message
        /// in the vertical layout of the scrollRect content
        /// </summary>
        /// <param name="logString">Log string.</param>
        /// <param name="stackTrace">Stack trace.</param>
        /// <param name="type">Type.</param>
        void HandleLog(string logString, string stackTrace, LogType type)
        {
            GameObject text = null;

            if (currentLogMessages.Count < maxMessage)
            {
                text = Instantiate(textPrefab);
                if (text != null) currentLogMessages.Enqueue(text);
            }
            else
            {
                text = currentLogMessages.Dequeue();
                currentLogMessages.Enqueue(text);
            }
            
            text.transform.SetParent(verticalLayout.gameObject.transform, false);
            text.transform.SetSiblingIndex(verticalLayout.gameObject.transform.childCount-1);
            text.GetComponent<Text>().text = DateTime.Now.ToString("HH:mm:ss") + ": "+ logString + "\n";

            if (type == LogType.Error)
            {
                text.GetComponent<Text>().color = Color.red;
            }
            else if (type == LogType.Warning)
            {
                text.GetComponent<Text>().color = Color.yellow;
            }
        }
        #endregion
}
