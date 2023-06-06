using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Developed.Extentions
{
    public static class UIExtentions
    {
        public const float deadZoneRelative = 0.05f;
        public const float deadZoneRelativeSqr = deadZoneRelative * deadZoneRelative;


        public static void SetPosition(this RectTransform rectTransform, Vector2 position)
        {
            rectTransform.anchoredPosition = position;
        }

        public static void AddPosition(this RectTransform rectTransform, Vector2 position)
        {
            rectTransform.anchoredPosition += position;
        }


        public static void SetScreenRelativePosition(this RectTransform rectTransform, Vector2 relativePosition)
        {
            rectTransform.anchoredPosition = GetAbsolutePosition(relativePosition);
        }

        public static void AddScreenRelativePosition(this RectTransform rectTransform, Vector2 relativePosition)
        {
            rectTransform.anchoredPosition += GetAbsolutePosition(relativePosition);
        }


        public static Vector2 ScreenRelativePosition(this RectTransform rectTransform)
        {
            return GetScreenRelativePosition(rectTransform.anchoredPosition);
        }


        public static Vector2 GetScreenRelativePosition(Vector2 position)
        {
            return new Vector2(position.x / Screen.width, position.y / Screen.height);
        }

        public static Vector2 GetAbsolutePosition(Vector2 relativePosition)
        {
            return new Vector2(relativePosition.x * Screen.width, relativePosition.y * Screen.height);
        }
    }
}