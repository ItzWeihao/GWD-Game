using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GraphicNovelManager : MonoBehaviour
{
    [System.Serializable]
    public class ImageData
    {
        public Sprite sprite;
        public Vector2 anchoredPosition;
        public Vector2 size = new Vector2(300, 300);
        public float delayAfter = 0f;
    }

    [System.Serializable]
    public class DialogueData
    {
        public string dialogueText;
        public Vector2 anchoredPosition;
        public float delayAfter = 0f;
    }

    [System.Serializable]
    public class PanelData
    {
        public List<ImageData> images = new List<ImageData>();
        public List<DialogueData> dialogues = new List<DialogueData>();
    }

    [System.Serializable]
    public class Page
    {
        public List<PanelData> panels = new List<PanelData>();
    }

    public List<Page> pages = new List<Page>();

    public Image panelImageTemplate;         // Prefab: Image (inactive)
    public TextMeshProUGUI dialogueTextTemplate; // Prefab: TextMeshProUGUI (inactive)
    public Button nextButton;
    public GameObject fadeOverlay;            // Optional black screen overlay

    private int currentPageIndex = 0;
    private int currentPanelIndex = 0;
    private bool isTransitioning = false;

    void Start()
    {
        if (nextButton != null)
            nextButton.onClick.AddListener(NextPanel);

        ShowPanel();
    }

    void ClearPanel()
    {
        foreach (Transform child in panelImageTemplate.transform.parent)
        {
            if (child != panelImageTemplate.transform && child != dialogueTextTemplate.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void ShowPanel()
    {
        if (isTransitioning) return;

        ClearPanel();

        if (nextButton != null)
            nextButton.interactable = false;

        var currentPanel = pages[currentPageIndex].panels[currentPanelIndex];
        StartCoroutine(ShowImagesAndDialogues(currentPanel.images, currentPanel.dialogues));
    }

    System.Collections.IEnumerator ShowImagesAndDialogues(List<ImageData> images, List<DialogueData> dialogues)
    {
        // Show images
        foreach (var imgData in images)
        {
            if (panelImageTemplate == null) yield break;

            Image newImage = Instantiate(panelImageTemplate, panelImageTemplate.transform.parent);
            newImage.sprite = imgData.sprite;
            RectTransform rt = newImage.GetComponent<RectTransform>();
            rt.anchoredPosition = imgData.anchoredPosition;
            rt.sizeDelta = imgData.size;
            newImage.gameObject.SetActive(true);

            // Fade in
            CanvasGroup cg = newImage.gameObject.AddComponent<CanvasGroup>();
            cg.alpha = 0f;
            float duration = 0.5f;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                cg.alpha = Mathf.Clamp01(elapsed / duration);
                yield return null;
            }
            cg.alpha = 1f;

            yield return new WaitForSeconds(Mathf.Max(0.1f, imgData.delayAfter));
        }

        // Show dialogues
        foreach (var dialogue in dialogues)
        {
            if (dialogueTextTemplate == null) yield break;

            TextMeshProUGUI newDialogue = Instantiate(dialogueTextTemplate, dialogueTextTemplate.transform.parent);
            newDialogue.text = dialogue.dialogueText;
            RectTransform rt = newDialogue.GetComponent<RectTransform>();
            rt.anchoredPosition = dialogue.anchoredPosition;
            newDialogue.gameObject.SetActive(true);

            // Fade in
            CanvasGroup cg = newDialogue.gameObject.AddComponent<CanvasGroup>();
            cg.alpha = 0f;
            float duration = 0.5f;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                cg.alpha = Mathf.Clamp01(elapsed / duration);
                yield return null;
            }
            cg.alpha = 1f;

            yield return new WaitForSeconds(Mathf.Max(0.1f, dialogue.delayAfter));
        }

        // Enable next button safely
        if (nextButton != null && nextButton.gameObject != null)
        {
            nextButton.interactable = true;
        }
    }

    void NextPanel()
    {
        if (isTransitioning) return;

        currentPanelIndex++;

        if (currentPanelIndex >= pages[currentPageIndex].panels.Count)
        {
            currentPageIndex++;
            currentPanelIndex = 0;

            if (currentPageIndex >= pages.Count)
            {
                Debug.Log("End of story.");

                if (nextButton != null)
                    nextButton.interactable = false;

                return;
            }

            StartCoroutine(TransitionToNextPage());
        }
        else
        {
            ShowPanel();
        }
    }

    System.Collections.IEnumerator TransitionToNextPage()
    {
        if (fadeOverlay == null)
        {
            ShowPanel();
            yield break;
        }

        isTransitioning = true;

        fadeOverlay.SetActive(true);

        CanvasGroup cg = fadeOverlay.GetComponent<CanvasGroup>();
        if (cg == null)
        {
            cg = fadeOverlay.AddComponent<CanvasGroup>();
        }

        // Fade to black
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        cg.alpha = 1f;

        ShowPanel();

        // Fade back in
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = 1f - Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        cg.alpha = 0f;
        fadeOverlay.SetActive(false);

        isTransitioning = false;
    }
}
