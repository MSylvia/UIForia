using UIForia.Elements;
using UIForia.Util;
using UnityEngine;

namespace UIForia.Systems {

    public class AwesomeScrollViewLayoutBox : AwesomeLayoutBox {

        private ScrollView scrollView;

        protected override void OnInitialize() {
            scrollView = element as ScrollView;
            flags |= LayoutBoxFlags.AlwaysUpdate;
        }

        protected override float ComputeContentWidth() {
            return firstChild?.GetContentWidth(1f) ?? 0;
        }

        protected override float ComputeContentHeight() {
            return firstChild?.GetContentHeight(1f) ?? 0;
        }

        public override void RunLayoutHorizontal(int frameId) {
            
            float contentAreaWidth = finalWidth - (paddingBorderHorizontalStart + paddingBorderHorizontalEnd);
            
            float inset = paddingBorderHorizontalStart;

            LayoutSize size = default;

            firstChild.GetWidths(ref size);

            float contentWidth = size.Clamped;
            float scrollOffsetPercentage = Mathf.Clamp(scrollView.scrollPercentageX, 0, 1);

            float x = inset + size.marginStart;
            float originBase = x;
            float originOffset = contentAreaWidth * scrollOffsetPercentage;
            float alignedPosition = originBase + originOffset + (contentWidth * -scrollOffsetPercentage);
            firstChild.ApplyLayoutHorizontalExplicit(alignedPosition, contentWidth, frameId);
            firstChild.flags |= LayoutBoxFlags.RequiresMatrixUpdate;

            AwesomeLayoutBox verticalTrack = element.children.array[1].layoutBox;
            AwesomeLayoutBox verticalHandle = element.children.array[2].layoutBox;
            AwesomeLayoutBox horizontalTrack = element.children.array[3].layoutBox;
            AwesomeLayoutBox horizontalHandle = element.children.array[4].layoutBox;

            float trackSize = Mathf.Max(5f, scrollView.trackSize);
            
            float horizontalWidth = scrollView.verticalScrollingEnabled ? contentAreaWidth - trackSize : contentAreaWidth;

            if (verticalTrack != null && verticalTrack.element.isEnabled) {
                verticalTrack.ApplyLayoutHorizontalExplicit(contentAreaWidth - trackSize, trackSize, frameId);
            }

            if (verticalHandle != null && verticalHandle.element.isEnabled) {
                verticalHandle.ApplyLayoutHorizontalExplicit(contentAreaWidth - trackSize, trackSize, frameId);
                verticalHandle.flags |= LayoutBoxFlags.RequiresMatrixUpdate;
            }

            if (horizontalTrack != null && horizontalTrack.element.isEnabled) {
                horizontalTrack.ApplyLayoutHorizontalExplicit(0, horizontalWidth, frameId);
            }

            if (horizontalHandle != null && horizontalHandle.element.isEnabled) {
                float handleWidth = (horizontalWidth / contentWidth) * horizontalWidth;
                float handlePosition = (horizontalWidth - handleWidth) * scrollOffsetPercentage;
                horizontalHandle.ApplyLayoutHorizontalExplicit(handlePosition, handleWidth, frameId);
                horizontalHandle.flags |= LayoutBoxFlags.RequiresMatrixUpdate;
            }
        }

        public override void RunLayoutVertical(int frameId) {
            
            float contentAreaHeight = finalHeight - (paddingBorderVerticalStart + paddingBorderVerticalEnd);
            
            LayoutSize size = default;
            firstChild.GetHeights(ref size);
            float contentHeight = size.Clamped;
            
            float inset = paddingBorderVerticalStart;
            float scrollOffsetPercentage = Mathf.Clamp01(scrollView.scrollPercentageY);

            float y = inset + size.marginStart;
            float originBase = y;
            float originOffset = contentAreaHeight * scrollOffsetPercentage;
            float alignedPosition = originBase + originOffset + (contentHeight * -scrollOffsetPercentage);
            firstChild.ApplyLayoutVerticalExplicit(alignedPosition, contentHeight, frameId);
            firstChild.flags |= LayoutBoxFlags.RequiresMatrixUpdate;


            AwesomeLayoutBox verticalTrack = element.children.array[1].layoutBox;
            AwesomeLayoutBox verticalHandle = element.children.array[2].layoutBox;
            AwesomeLayoutBox horizontalTrack = element.children.array[3].layoutBox;
            AwesomeLayoutBox horizontalHandle = element.children.array[4].layoutBox;

            float trackSize = Mathf.Max(5f, scrollView.trackSize);
            float verticalHeight = scrollView.verticalScrollingEnabled ? contentAreaHeight - trackSize : contentAreaHeight;

            if (verticalTrack != null && verticalTrack.element.isEnabled) {
                verticalTrack.ApplyLayoutVerticalExplicit(0, verticalHeight, frameId);
            }

            if (verticalHandle != null && verticalHandle.element.isEnabled) {
                float handleHeight = (verticalHeight / contentHeight) * verticalHeight;
                float handlePosition = (verticalHeight - handleHeight) * scrollOffsetPercentage;
                verticalHandle.ApplyLayoutVerticalExplicit(handlePosition, handleHeight, frameId);
                verticalHandle.flags |= LayoutBoxFlags.RequiresMatrixUpdate;
            }

            if (horizontalTrack != null && horizontalTrack.element.isEnabled) {
                horizontalTrack.ApplyLayoutVerticalExplicit(contentAreaHeight - trackSize, trackSize, frameId);
            }

            if (horizontalHandle != null && horizontalHandle.element.isEnabled) {
                horizontalHandle.ApplyLayoutVerticalExplicit(contentAreaHeight - trackSize, trackSize, frameId);
            }
        }

        public override void OnChildrenChanged(LightList<AwesomeLayoutBox> childList) { }

    }

}