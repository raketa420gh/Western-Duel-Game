using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Raketa420
{
    public class SettingMenu : MonoBehaviour
    {
        [Header("Space between items")]
        [SerializeField] private Vector2 spacing;

        [Header("Main button rotation")]
        [SerializeField] private float rotationDuration;
        [SerializeField] private Ease rotationEase;

        [Header("Animation")]
        [SerializeField] private float expandDuration;
        [SerializeField] private float collapseDuration;
        [SerializeField] private Ease expandEase;
        [SerializeField] private Ease collapseEase;

        [Header("Fading")]
        [SerializeField] private float expandFadeDuration;
        [SerializeField] private float collapseFadeDuration;

        private Button mainButton;
        private SettingMenuItem[] menuItems;
        private bool isExpanded;
        private Vector2 mainButtonPosition;
        private int itemsCount;

        private void Start()
        {
            itemsCount = transform.childCount - 1;
            menuItems = new SettingMenuItem[itemsCount];

            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingMenuItem>();
            }

            mainButton = transform.GetChild(0).GetComponent<Button>();
            mainButton.onClick.AddListener(ToggleMenu);
            mainButton.transform.SetAsLastSibling();

            mainButtonPosition = mainButton.transform.position;

            ResetPositions();
        }

        private void OnDestroy()
        {
            mainButton.onClick.RemoveListener(ToggleMenu);
        }

        private void ResetPositions()
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].SelfTransform.position = mainButtonPosition;
            }
        }

        private void ToggleMenu()
        {
            isExpanded = !isExpanded;

            if (isExpanded)
            {
                CollapseMenu();
            }
            else
            {
                ExpandMenu();
            }

            mainButton.transform.DOLocalRotate(Vector3.forward * 180, rotationDuration).From(Vector3.zero).SetEase(rotationEase);
        }

        private void ExpandMenu()
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].SelfTransform.DOMove(mainButtonPosition, collapseDuration).SetEase(collapseEase);
                menuItems[i].Image.DOFade(0f, collapseDuration).From(1f);
            }
        }

        private void CollapseMenu()
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].SelfTransform.DOMove(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].Image.DOFade(1f, expandDuration).From(0f);
            }
        }
    }
}

