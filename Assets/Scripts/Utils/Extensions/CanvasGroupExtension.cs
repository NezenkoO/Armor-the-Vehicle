using UnityEngine;

namespace Utils.Extensions
{
    public static class CanvasGroupExtension
    {
        public static void Show(this CanvasGroup canvasGroup)
        {
            SetCanvasGroupState(canvasGroup, 1, true, true);
        }

        public static void Hide(this CanvasGroup canvasGroup)
        {
            SetCanvasGroupState(canvasGroup, 0, false, false);
        }

        public static void SetCanvasGroupState(this CanvasGroup canvasGroup, float alpha, bool interactable, bool blocksRaycasts)
        {
            canvasGroup.alpha = alpha;
            canvasGroup.interactable = interactable;
            canvasGroup.blocksRaycasts = blocksRaycasts;
        }
    }
}
