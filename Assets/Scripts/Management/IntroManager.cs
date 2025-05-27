using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class IntroManager : MonoBehaviour
{
    [System.Serializable]
    public class ImageData
    {
        public Sprite sprite;
        public Vector3 worldPosition;
        public Vector2 size = new Vector2(300, 300);
    }

    [System.Serializable]
    public class DialogueData
    {
        public string dialogueText;
        public Vector3 worldPosition;
        public float delayAfter = 2f;
    }

    [System.Serializable]
    public class PanelData
    {
        public List<ImageData> images;
        public List<DialogueData> dialogues;
    }

    [System.Serializable]
    public class Page
    {
        public List<PanelData> panels;
    }

    public List<Page> pages;

    public Image panelImageTemplate;
    public TextMeshProUGUI dialogueTextTemplate;
    public Button nextButton;
    public GameObject fadeOverlay;
    public Transform contentParent; // Parent for spawned UI objects

    // 🔊 Music support
    //public AudioSource musicSource;
    //public AudioClip backgroundMusic;
    //public int musicStartPageIndex = 0;
    //public int musicStartPanelIndex = 0;

    private int currentPageIndex = 0;
    private int currentPanelIndex = 0;
    private Coroutine dialogueCoroutine;

    public FadeUI transition;
    public SaveGameObject GameManager;
    public SaveGameObject SceneManager;

    void Start()
    {
        nextButton.onClick.AddListener(NextPanel);
        ShowPanel();
        transition = GameObject.Find("FadeIn/Out").GetComponent<FadeUI>();

        GameManager = GameObject.Find("=== GameManager ===").GetComponent<SaveGameObject>();
        SceneManager = GameObject.Find("=== SceneManager ===").GetComponent<SaveGameObject>();
    }

    void ShowPanel()
    {
        // Start music at the correct panel
        //if (!musicSource.isPlaying &&
        //    currentPageIndex == musicStartPageIndex &&
        //    currentPanelIndex == musicStartPanelIndex)
        //{
        //    musicSource.clip = backgroundMusic;
        //    musicSource.Play();
        //}

        var currentPanel = pages[currentPageIndex].panels[currentPanelIndex];

        // Clear old content
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Hide templates
        panelImageTemplate.gameObject.SetActive(false);
        dialogueTextTemplate.gameObject.SetActive(false);

        // Spawn Images
        foreach (var imageData in currentPanel.images)
        {
            Image newImage = Instantiate(panelImageTemplate, contentParent);
            newImage.sprite = imageData.sprite;
            newImage.rectTransform.sizeDelta = imageData.size;
            newImage.transform.position = imageData.worldPosition;
            newImage.gameObject.SetActive(true);
        }

        // Spawn Dialogues
        if (dialogueCoroutine != null)
            StopCoroutine(dialogueCoroutine);

        dialogueCoroutine = StartCoroutine(ShowDialoguesWithDelay(currentPanel.dialogues));
    }

    IEnumerator ShowDialoguesWithDelay(List<DialogueData> dialogues)
    {
        foreach (var dialogueData in dialogues)
        {
            TextMeshProUGUI newText = Instantiate(dialogueTextTemplate, contentParent);
            newText.text = dialogueData.dialogueText;
            newText.transform.position = dialogueData.worldPosition;
            newText.gameObject.SetActive(true);

            CanvasGroup cg = newText.GetComponent<CanvasGroup>();
            if (cg == null) cg = newText.gameObject.AddComponent<CanvasGroup>();

            cg.alpha = 0;
            for (float f = 0f; f <= 1f; f += Time.deltaTime * 2f)
            {
                cg.alpha = f;
                yield return null;
            }

            yield return new WaitForSeconds(dialogueData.delayAfter);
        }
    }

    void NextPanel()
    {
        currentPanelIndex++;

        if (currentPanelIndex >= pages[currentPageIndex].panels.Count)
        {
            currentPageIndex++;
            currentPanelIndex = 0;

            if (currentPageIndex >= pages.Count)
            {
                transition.Fade();
                // nextButton.interactable = false;
                // dialogueTextTemplate.text = "The End.";
                // panelImageTemplate.enabled = false;
                return;
            }

            StartCoroutine(TransitionToNextPage());
        }
        else
        {
            ShowPanel();
        }
    }

    IEnumerator TransitionToNextPage()
    {
        if (fadeOverlay)
        {
            fadeOverlay.SetActive(true);
            CanvasGroup cg = fadeOverlay.GetComponent<CanvasGroup>();
            if (cg)
            {
                for (float f = 0; f <= 1; f += Time.deltaTime)
                {
                    cg.alpha = f;
                    yield return null;
                }

                ShowPanel();

                for (float f = 1; f >= 0; f -= Time.deltaTime)
                {
                    cg.alpha = f;
                    yield return null;
                }

                fadeOverlay.SetActive(false);
            }
            else
            {
                ShowPanel(); // fallback
            }
        }
        else
        {
            ShowPanel(); // fallback
        }
    }
}
