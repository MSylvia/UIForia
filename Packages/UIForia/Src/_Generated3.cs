using Shapes2D;
using UIForia.Layout;
using UIForia.Layout.LayoutTypes;
using TMPro;
using UIForia.Bindings.StyleBindings;
using System.Collections.Generic;
using UnityEngine;
using UIForia.Util;
using UIForia.Text;
using FontStyle = UIForia.Text.FontStyle;
using TextAlignment = UIForia.Text.TextAlignment;

// Do not edit this file. See CodeGen.cs instead.

namespace UIForia.Rendering {

    public static class DefaultStyleValues_Generated {

		public const Overflow OverflowX = UIForia.Rendering.Overflow.Visible;
		public const Overflow OverflowY = UIForia.Rendering.Overflow.Visible;
		public static readonly Color BackgroundColor = new Color(-1f, -1f, -1f, -1f);
		public static readonly UIFixedLength BackgroundImageOffsetX = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BackgroundImageOffsetY = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BackgroundImageScaleX = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BackgroundImageScaleY = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BackgroundImageTileX = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BackgroundImageTileY = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BackgroundImageRotation = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly Texture2D BackgroundImage = null;
		public static readonly string Painter = "";
		public const float Opacity = 1f;
		public static readonly CursorStyle Cursor = null;
		public const Visibility Visibility = UIForia.Rendering.Visibility.Visible;
		public const int FlexItemOrder = 0;
		public const int FlexItemGrow = 0;
		public const int FlexItemShrink = 0;
		public const CrossAxisAlignment FlexItemSelfAlignment = UIForia.Layout.CrossAxisAlignment.Unset;
		public const LayoutDirection FlexLayoutDirection = UIForia.Layout.LayoutDirection.Horizontal;
		public const LayoutWrap FlexLayoutWrap = UIForia.Layout.LayoutWrap.None;
		public const MainAxisAlignment FlexLayoutMainAxisAlignment = UIForia.Layout.MainAxisAlignment.Start;
		public const CrossAxisAlignment FlexLayoutCrossAxisAlignment = UIForia.Layout.CrossAxisAlignment.Start;
		public const int GridItemColStart = 2147483647;
		public const int GridItemColSpan = 1;
		public const int GridItemRowStart = 2147483647;
		public const int GridItemRowSpan = 1;
		public const GridAxisAlignment GridItemColSelfAlignment = UIForia.Layout.GridAxisAlignment.Unset;
		public const GridAxisAlignment GridItemRowSelfAlignment = UIForia.Layout.GridAxisAlignment.Unset;
		public const LayoutDirection GridLayoutDirection = UIForia.Layout.LayoutDirection.Horizontal;
		public const GridLayoutDensity GridLayoutDensity = UIForia.Layout.GridLayoutDensity.Sparse;
		public static readonly IReadOnlyList<UIForia.Layout.LayoutTypes.GridTrackSize> GridLayoutColTemplate = ListPool<GridTrackSize>.Empty;
		public static readonly IReadOnlyList<UIForia.Layout.LayoutTypes.GridTrackSize> GridLayoutRowTemplate = ListPool<GridTrackSize>.Empty;
		public static readonly GridTrackSize GridLayoutMainAxisAutoSize = new GridTrackSize(1f, GridTemplateUnit.MaxContent);
		public static readonly GridTrackSize GridLayoutCrossAxisAutoSize = new GridTrackSize(1f, GridTemplateUnit.FractionalRemaining);
		public const float GridLayoutColGap = 0f;
		public const float GridLayoutRowGap = 0f;
		public const GridAxisAlignment GridLayoutColAlignment = UIForia.Layout.GridAxisAlignment.Grow;
		public const GridAxisAlignment GridLayoutRowAlignment = UIForia.Layout.GridAxisAlignment.Grow;
		public const float RadialLayoutStartAngle = 0f;
		public const float RadialLayoutEndAngle = 360f;
		public static readonly UIFixedLength RadialLayoutRadius = new UIFixedLength(0.5f, UIFixedUnit.Percent);
		public static readonly UIMeasurement MinWidth = new UIMeasurement(0f, UIMeasurementUnit.Pixel);
		public static readonly UIMeasurement MaxWidth = new UIMeasurement(3.402823E+38f, UIMeasurementUnit.Pixel);
		public static readonly UIMeasurement PreferredWidth = new UIMeasurement(1f, UIMeasurementUnit.Content);
		public static readonly UIMeasurement MinHeight = new UIMeasurement(0f, UIMeasurementUnit.Pixel);
		public static readonly UIMeasurement MaxHeight = new UIMeasurement(3.402823E+38f, UIMeasurementUnit.Pixel);
		public static readonly UIMeasurement PreferredHeight = new UIMeasurement(1f, UIMeasurementUnit.Content);
		public static readonly UIMeasurement MarginTop = new UIMeasurement(0f, UIMeasurementUnit.Pixel);
		public static readonly UIMeasurement MarginRight = new UIMeasurement(0f, UIMeasurementUnit.Pixel);
		public static readonly UIMeasurement MarginBottom = new UIMeasurement(0f, UIMeasurementUnit.Pixel);
		public static readonly UIMeasurement MarginLeft = new UIMeasurement(0f, UIMeasurementUnit.Pixel);
		public static readonly Color BorderColor = new Color(-1f, -1f, -1f, -1f);
		public static readonly UIFixedLength BorderTop = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BorderRight = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BorderBottom = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BorderLeft = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BorderRadiusTopLeft = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BorderRadiusTopRight = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BorderRadiusBottomRight = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength BorderRadiusBottomLeft = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength PaddingTop = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength PaddingRight = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength PaddingBottom = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength PaddingLeft = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly Color TextColor = new Color(0f, 0f, 0f, 1f);
		public static readonly TMP_FontAsset TextFontAsset = TMP_FontAsset.defaultFontAsset;
		public static readonly UIFixedLength TextFontSize = new UIFixedLength(18f, UIFixedUnit.Pixel);
		public const FontStyle TextFontStyle = UIForia.Text.FontStyle.Normal;
		public const TextAlignment TextAlignment = UIForia.Text.TextAlignment.Left;
		public const float TextOutlineWidth = 0f;
		public static readonly Color TextOutlineColor = new Color(0f, 0f, 0f, 1f);
		public static readonly Color TextGlowColor = new Color(-1f, -1f, -1f, -1f);
		public const float TextGlowOffset = 0f;
		public const float TextGlowInner = 0f;
		public const float TextGlowOuter = 0f;
		public const float TextGlowPower = 0f;
		public static readonly Color TextShadowColor = new Color(-1f, -1f, -1f, -1f);
		public const float TextShadowOffsetX = 0f;
		public const float TextShadowOffsetY = 0f;
		public const float TextShadowIntensity = 0.5f;
		public const float TextShadowSoftness = 0.5f;
		public const ShadowType TextShadowType = UIForia.Rendering.ShadowType.Unset;
		public const TextTransform TextTransform = UIForia.Text.TextTransform.None;
		public static readonly UIFixedLength AnchorTop = new UIFixedLength(0f, UIFixedUnit.Percent);
		public static readonly UIFixedLength AnchorRight = new UIFixedLength(1f, UIFixedUnit.Percent);
		public static readonly UIFixedLength AnchorBottom = new UIFixedLength(1f, UIFixedUnit.Percent);
		public static readonly UIFixedLength AnchorLeft = new UIFixedLength(0f, UIFixedUnit.Percent);
		public const AnchorTarget AnchorTarget = UIForia.Rendering.AnchorTarget.Parent;
		public static readonly TransformOffset TransformPositionX = new TransformOffset(0f, TransformUnit.Pixel);
		public static readonly TransformOffset TransformPositionY = new TransformOffset(0f, TransformUnit.Pixel);
		public static readonly UIFixedLength TransformPivotX = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public static readonly UIFixedLength TransformPivotY = new UIFixedLength(0f, UIFixedUnit.Pixel);
		public const float TransformScaleX = 1f;
		public const float TransformScaleY = 1f;
		public const float TransformRotation = 0f;
		public const TransformBehavior TransformBehaviorX = UIForia.Rendering.TransformBehavior.LayoutOffset;
		public const TransformBehavior TransformBehaviorY = UIForia.Rendering.TransformBehavior.LayoutOffset;
		public const LayoutType LayoutType = UIForia.Layout.LayoutType.Flex;
		public const LayoutBehavior LayoutBehavior = UIForia.Layout.LayoutBehavior.Normal;
		public const int ZIndex = 0;
		public const int RenderLayerOffset = 0;
		public const RenderLayer RenderLayer = UIForia.Rendering.RenderLayer.Default;
		public const int Layer = 0;
		public static readonly string Scrollbar = "";
		public static readonly UIMeasurement ScrollbarSize = new UIMeasurement(15f, UIMeasurementUnit.Pixel);
		public static readonly Color ScrollbarColor = new Color(0f, 0f, 0f, 1f);
		public const ShadowType ShadowType = UIForia.Rendering.ShadowType.Unset;
		public const float ShadowOffsetX = 0f;
		public const float ShadowOffsetY = 0f;
		public const float ShadowSoftnessX = 0.1f;
		public const float ShadowSoftnessY = 0.1f;
		public const float ShadowIntensity = 0.7f;
		public static StyleProperty GetPropertyValue(StylePropertyId propertyId) {

			switch(propertyId) {
				case StylePropertyId.OverflowX:
					 return new StyleProperty(StylePropertyId.OverflowX, (int)UIForia.Rendering.Overflow.Visible);
				case StylePropertyId.OverflowY:
					 return new StyleProperty(StylePropertyId.OverflowY, (int)UIForia.Rendering.Overflow.Visible);
				case StylePropertyId.BackgroundColor:
					 return new StyleProperty(StylePropertyId.BackgroundColor, new Color(-1f, -1f, -1f, -1f));
				case StylePropertyId.BackgroundImageOffsetX:
					 return new StyleProperty(StylePropertyId.BackgroundImageOffsetX, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BackgroundImageOffsetY:
					 return new StyleProperty(StylePropertyId.BackgroundImageOffsetY, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BackgroundImageScaleX:
					 return new StyleProperty(StylePropertyId.BackgroundImageScaleX, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BackgroundImageScaleY:
					 return new StyleProperty(StylePropertyId.BackgroundImageScaleY, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BackgroundImageTileX:
					 return new StyleProperty(StylePropertyId.BackgroundImageTileX, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BackgroundImageTileY:
					 return new StyleProperty(StylePropertyId.BackgroundImageTileY, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BackgroundImageRotation:
					 return new StyleProperty(StylePropertyId.BackgroundImageRotation, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BackgroundImage:
					 return new StyleProperty(StylePropertyId.BackgroundImage, 0, 0, null);
				case StylePropertyId.Painter:
					 return new StyleProperty(StylePropertyId.Painter, 0, 0, "");
				case StylePropertyId.Opacity:
					 return new StyleProperty(StylePropertyId.Opacity, 1f);
				case StylePropertyId.Cursor:
					 return new StyleProperty(StylePropertyId.Cursor, 0, 0, null);
				case StylePropertyId.Visibility:
					 return new StyleProperty(StylePropertyId.Visibility, (int)UIForia.Rendering.Visibility.Visible);
				case StylePropertyId.FlexItemOrder:
					 return new StyleProperty(StylePropertyId.FlexItemOrder, 0);
				case StylePropertyId.FlexItemGrow:
					 return new StyleProperty(StylePropertyId.FlexItemGrow, 0);
				case StylePropertyId.FlexItemShrink:
					 return new StyleProperty(StylePropertyId.FlexItemShrink, 0);
				case StylePropertyId.FlexItemSelfAlignment:
					 return new StyleProperty(StylePropertyId.FlexItemSelfAlignment, (int)UIForia.Layout.CrossAxisAlignment.Unset);
				case StylePropertyId.FlexLayoutDirection:
					 return new StyleProperty(StylePropertyId.FlexLayoutDirection, (int)UIForia.Layout.LayoutDirection.Horizontal);
				case StylePropertyId.FlexLayoutWrap:
					 return new StyleProperty(StylePropertyId.FlexLayoutWrap, (int)UIForia.Layout.LayoutWrap.None);
				case StylePropertyId.FlexLayoutMainAxisAlignment:
					 return new StyleProperty(StylePropertyId.FlexLayoutMainAxisAlignment, (int)UIForia.Layout.MainAxisAlignment.Start);
				case StylePropertyId.FlexLayoutCrossAxisAlignment:
					 return new StyleProperty(StylePropertyId.FlexLayoutCrossAxisAlignment, (int)UIForia.Layout.CrossAxisAlignment.Start);
				case StylePropertyId.GridItemColStart:
					 return new StyleProperty(StylePropertyId.GridItemColStart, 2147483647);
				case StylePropertyId.GridItemColSpan:
					 return new StyleProperty(StylePropertyId.GridItemColSpan, 1);
				case StylePropertyId.GridItemRowStart:
					 return new StyleProperty(StylePropertyId.GridItemRowStart, 2147483647);
				case StylePropertyId.GridItemRowSpan:
					 return new StyleProperty(StylePropertyId.GridItemRowSpan, 1);
				case StylePropertyId.GridItemColSelfAlignment:
					 return new StyleProperty(StylePropertyId.GridItemColSelfAlignment, (int)UIForia.Layout.GridAxisAlignment.Unset);
				case StylePropertyId.GridItemRowSelfAlignment:
					 return new StyleProperty(StylePropertyId.GridItemRowSelfAlignment, (int)UIForia.Layout.GridAxisAlignment.Unset);
				case StylePropertyId.GridLayoutDirection:
					 return new StyleProperty(StylePropertyId.GridLayoutDirection, (int)UIForia.Layout.LayoutDirection.Horizontal);
				case StylePropertyId.GridLayoutDensity:
					 return new StyleProperty(StylePropertyId.GridLayoutDensity, (int)UIForia.Layout.GridLayoutDensity.Sparse);
				case StylePropertyId.GridLayoutColTemplate:
					 return new StyleProperty(StylePropertyId.GridLayoutColTemplate, 0, 0, ListPool<GridTrackSize>.Empty);
				case StylePropertyId.GridLayoutRowTemplate:
					 return new StyleProperty(StylePropertyId.GridLayoutRowTemplate, 0, 0, ListPool<GridTrackSize>.Empty);
				case StylePropertyId.GridLayoutMainAxisAutoSize:
					 return new StyleProperty(StylePropertyId.GridLayoutMainAxisAutoSize, new GridTrackSize(1f, GridTemplateUnit.MaxContent));
				case StylePropertyId.GridLayoutCrossAxisAutoSize:
					 return new StyleProperty(StylePropertyId.GridLayoutCrossAxisAutoSize, new GridTrackSize(1f, GridTemplateUnit.FractionalRemaining));
				case StylePropertyId.GridLayoutColGap:
					 return new StyleProperty(StylePropertyId.GridLayoutColGap, 0f);
				case StylePropertyId.GridLayoutRowGap:
					 return new StyleProperty(StylePropertyId.GridLayoutRowGap, 0f);
				case StylePropertyId.GridLayoutColAlignment:
					 return new StyleProperty(StylePropertyId.GridLayoutColAlignment, (int)UIForia.Layout.GridAxisAlignment.Grow);
				case StylePropertyId.GridLayoutRowAlignment:
					 return new StyleProperty(StylePropertyId.GridLayoutRowAlignment, (int)UIForia.Layout.GridAxisAlignment.Grow);
				case StylePropertyId.RadialLayoutStartAngle:
					 return new StyleProperty(StylePropertyId.RadialLayoutStartAngle, 0f);
				case StylePropertyId.RadialLayoutEndAngle:
					 return new StyleProperty(StylePropertyId.RadialLayoutEndAngle, 360f);
				case StylePropertyId.RadialLayoutRadius:
					 return new StyleProperty(StylePropertyId.RadialLayoutRadius, new UIFixedLength(0.5f, UIFixedUnit.Percent));
				case StylePropertyId.MinWidth:
					 return new StyleProperty(StylePropertyId.MinWidth, new UIMeasurement(0f, UIMeasurementUnit.Pixel));
				case StylePropertyId.MaxWidth:
					 return new StyleProperty(StylePropertyId.MaxWidth, new UIMeasurement(3.402823E+38f, UIMeasurementUnit.Pixel));
				case StylePropertyId.PreferredWidth:
					 return new StyleProperty(StylePropertyId.PreferredWidth, new UIMeasurement(1f, UIMeasurementUnit.Content));
				case StylePropertyId.MinHeight:
					 return new StyleProperty(StylePropertyId.MinHeight, new UIMeasurement(0f, UIMeasurementUnit.Pixel));
				case StylePropertyId.MaxHeight:
					 return new StyleProperty(StylePropertyId.MaxHeight, new UIMeasurement(3.402823E+38f, UIMeasurementUnit.Pixel));
				case StylePropertyId.PreferredHeight:
					 return new StyleProperty(StylePropertyId.PreferredHeight, new UIMeasurement(1f, UIMeasurementUnit.Content));
				case StylePropertyId.MarginTop:
					 return new StyleProperty(StylePropertyId.MarginTop, new UIMeasurement(0f, UIMeasurementUnit.Pixel));
				case StylePropertyId.MarginRight:
					 return new StyleProperty(StylePropertyId.MarginRight, new UIMeasurement(0f, UIMeasurementUnit.Pixel));
				case StylePropertyId.MarginBottom:
					 return new StyleProperty(StylePropertyId.MarginBottom, new UIMeasurement(0f, UIMeasurementUnit.Pixel));
				case StylePropertyId.MarginLeft:
					 return new StyleProperty(StylePropertyId.MarginLeft, new UIMeasurement(0f, UIMeasurementUnit.Pixel));
				case StylePropertyId.BorderColor:
					 return new StyleProperty(StylePropertyId.BorderColor, new Color(-1f, -1f, -1f, -1f));
				case StylePropertyId.BorderTop:
					 return new StyleProperty(StylePropertyId.BorderTop, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BorderRight:
					 return new StyleProperty(StylePropertyId.BorderRight, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BorderBottom:
					 return new StyleProperty(StylePropertyId.BorderBottom, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BorderLeft:
					 return new StyleProperty(StylePropertyId.BorderLeft, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BorderRadiusTopLeft:
					 return new StyleProperty(StylePropertyId.BorderRadiusTopLeft, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BorderRadiusTopRight:
					 return new StyleProperty(StylePropertyId.BorderRadiusTopRight, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BorderRadiusBottomRight:
					 return new StyleProperty(StylePropertyId.BorderRadiusBottomRight, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.BorderRadiusBottomLeft:
					 return new StyleProperty(StylePropertyId.BorderRadiusBottomLeft, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.PaddingTop:
					 return new StyleProperty(StylePropertyId.PaddingTop, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.PaddingRight:
					 return new StyleProperty(StylePropertyId.PaddingRight, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.PaddingBottom:
					 return new StyleProperty(StylePropertyId.PaddingBottom, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.PaddingLeft:
					 return new StyleProperty(StylePropertyId.PaddingLeft, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.TextColor:
					 return new StyleProperty(StylePropertyId.TextColor, new Color(0f, 0f, 0f, 1f));
				case StylePropertyId.TextFontAsset:
					 return new StyleProperty(StylePropertyId.TextFontAsset, 0, 0, TMP_FontAsset.defaultFontAsset);
				case StylePropertyId.TextFontSize:
					 return new StyleProperty(StylePropertyId.TextFontSize, new UIFixedLength(18f, UIFixedUnit.Pixel));
				case StylePropertyId.TextFontStyle:
					 return new StyleProperty(StylePropertyId.TextFontStyle, (int)UIForia.Text.FontStyle.Normal);
				case StylePropertyId.TextAlignment:
					 return new StyleProperty(StylePropertyId.TextAlignment, (int)UIForia.Text.TextAlignment.Left);
				case StylePropertyId.TextOutlineWidth:
					 return new StyleProperty(StylePropertyId.TextOutlineWidth, 0f);
				case StylePropertyId.TextOutlineColor:
					 return new StyleProperty(StylePropertyId.TextOutlineColor, new Color(0f, 0f, 0f, 1f));
				case StylePropertyId.TextGlowColor:
					 return new StyleProperty(StylePropertyId.TextGlowColor, new Color(-1f, -1f, -1f, -1f));
				case StylePropertyId.TextGlowOffset:
					 return new StyleProperty(StylePropertyId.TextGlowOffset, 0f);
				case StylePropertyId.TextGlowInner:
					 return new StyleProperty(StylePropertyId.TextGlowInner, 0f);
				case StylePropertyId.TextGlowOuter:
					 return new StyleProperty(StylePropertyId.TextGlowOuter, 0f);
				case StylePropertyId.TextGlowPower:
					 return new StyleProperty(StylePropertyId.TextGlowPower, 0f);
				case StylePropertyId.TextShadowColor:
					 return new StyleProperty(StylePropertyId.TextShadowColor, new Color(-1f, -1f, -1f, -1f));
				case StylePropertyId.TextShadowOffsetX:
					 return new StyleProperty(StylePropertyId.TextShadowOffsetX, 0f);
				case StylePropertyId.TextShadowOffsetY:
					 return new StyleProperty(StylePropertyId.TextShadowOffsetY, 0f);
				case StylePropertyId.TextShadowIntensity:
					 return new StyleProperty(StylePropertyId.TextShadowIntensity, 0.5f);
				case StylePropertyId.TextShadowSoftness:
					 return new StyleProperty(StylePropertyId.TextShadowSoftness, 0.5f);
				case StylePropertyId.TextShadowType:
					 return new StyleProperty(StylePropertyId.TextShadowType, (int)UIForia.Rendering.ShadowType.Unset);
				case StylePropertyId.TextTransform:
					 return new StyleProperty(StylePropertyId.TextTransform, (int)UIForia.Text.TextTransform.None);
				case StylePropertyId.AnchorTop:
					 return new StyleProperty(StylePropertyId.AnchorTop, new UIFixedLength(0f, UIFixedUnit.Percent));
				case StylePropertyId.AnchorRight:
					 return new StyleProperty(StylePropertyId.AnchorRight, new UIFixedLength(1f, UIFixedUnit.Percent));
				case StylePropertyId.AnchorBottom:
					 return new StyleProperty(StylePropertyId.AnchorBottom, new UIFixedLength(1f, UIFixedUnit.Percent));
				case StylePropertyId.AnchorLeft:
					 return new StyleProperty(StylePropertyId.AnchorLeft, new UIFixedLength(0f, UIFixedUnit.Percent));
				case StylePropertyId.AnchorTarget:
					 return new StyleProperty(StylePropertyId.AnchorTarget, (int)UIForia.Rendering.AnchorTarget.Parent);
				case StylePropertyId.TransformPositionX:
					 return new StyleProperty(StylePropertyId.TransformPositionX, new TransformOffset(0f, TransformUnit.Pixel));
				case StylePropertyId.TransformPositionY:
					 return new StyleProperty(StylePropertyId.TransformPositionY, new TransformOffset(0f, TransformUnit.Pixel));
				case StylePropertyId.TransformPivotX:
					 return new StyleProperty(StylePropertyId.TransformPivotX, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.TransformPivotY:
					 return new StyleProperty(StylePropertyId.TransformPivotY, new UIFixedLength(0f, UIFixedUnit.Pixel));
				case StylePropertyId.TransformScaleX:
					 return new StyleProperty(StylePropertyId.TransformScaleX, 1f);
				case StylePropertyId.TransformScaleY:
					 return new StyleProperty(StylePropertyId.TransformScaleY, 1f);
				case StylePropertyId.TransformRotation:
					 return new StyleProperty(StylePropertyId.TransformRotation, 0f);
				case StylePropertyId.TransformBehaviorX:
					 return new StyleProperty(StylePropertyId.TransformBehaviorX, (int)UIForia.Rendering.TransformBehavior.LayoutOffset);
				case StylePropertyId.TransformBehaviorY:
					 return new StyleProperty(StylePropertyId.TransformBehaviorY, (int)UIForia.Rendering.TransformBehavior.LayoutOffset);
				case StylePropertyId.LayoutType:
					 return new StyleProperty(StylePropertyId.LayoutType, (int)UIForia.Layout.LayoutType.Flex);
				case StylePropertyId.LayoutBehavior:
					 return new StyleProperty(StylePropertyId.LayoutBehavior, (int)UIForia.Layout.LayoutBehavior.Normal);
				case StylePropertyId.ZIndex:
					 return new StyleProperty(StylePropertyId.ZIndex, 0);
				case StylePropertyId.RenderLayerOffset:
					 return new StyleProperty(StylePropertyId.RenderLayerOffset, 0);
				case StylePropertyId.RenderLayer:
					 return new StyleProperty(StylePropertyId.RenderLayer, (int)UIForia.Rendering.RenderLayer.Default);
				case StylePropertyId.Layer:
					 return new StyleProperty(StylePropertyId.Layer, 0);
				case StylePropertyId.Scrollbar:
					 return new StyleProperty(StylePropertyId.Scrollbar, 0, 0, "");
				case StylePropertyId.ScrollbarSize:
					 return new StyleProperty(StylePropertyId.ScrollbarSize, new UIMeasurement(15f, UIMeasurementUnit.Pixel));
				case StylePropertyId.ScrollbarColor:
					 return new StyleProperty(StylePropertyId.ScrollbarColor, new Color(0f, 0f, 0f, 1f));
				case StylePropertyId.ShadowType:
					 return new StyleProperty(StylePropertyId.ShadowType, (int)UIForia.Rendering.ShadowType.Unset);
				case StylePropertyId.ShadowOffsetX:
					 return new StyleProperty(StylePropertyId.ShadowOffsetX, 0f);
				case StylePropertyId.ShadowOffsetY:
					 return new StyleProperty(StylePropertyId.ShadowOffsetY, 0f);
				case StylePropertyId.ShadowSoftnessX:
					 return new StyleProperty(StylePropertyId.ShadowSoftnessX, 0.1f);
				case StylePropertyId.ShadowSoftnessY:
					 return new StyleProperty(StylePropertyId.ShadowSoftnessY, 0.1f);
				case StylePropertyId.ShadowIntensity:
					 return new StyleProperty(StylePropertyId.ShadowIntensity, 0.7f);
				default: throw new System.ArgumentOutOfRangeException(nameof(propertyId), propertyId, null);
				}
} 
}
}