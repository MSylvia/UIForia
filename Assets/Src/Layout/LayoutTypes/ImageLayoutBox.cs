using System;
using Rendering;
using Src.Systems;
using UnityEngine;

namespace Src.Layout.LayoutTypes {

    public class ImageLayoutBox : LayoutBox {

        private readonly UIImageElement image;

        public ImageLayoutBox(LayoutSystem2 layoutSystem, UIElement element) : base(layoutSystem, element) {
            image = (UIImageElement) element;
            image.onMaterialDirty += (e) => { parent.OnChildSizeChanged(); };
        }

        public override float PreferredWidth {
            get {
                if (image.Asset == null) return PaddingHorizontal + BorderHorizontal;
                if (image.useNativeSize) return PaddingHorizontal + BorderHorizontal + image.Asset.width;
                return PaddingHorizontal + BorderHorizontal + ResolveWidth(style.PreferredWidth);
            }
        }

        public override float MinWidth {
            get {
                if (image.useNativeSize && image.Asset != null) return PaddingHorizontal + BorderHorizontal + image.Asset.width;
                return base.MinWidth;
            }
        }

        public override float MaxWidth {
            get {
                if (image.useNativeSize && image.Asset != null) return PaddingHorizontal + BorderHorizontal + image.Asset.width;
                return base.MaxWidth;
            }
        }

        public override float PreferredHeight {
            get {
                if (image.Asset == null) return base.PreferredHeight;
                if (image.useNativeSize) return PaddingVertical + BorderVertical + image.Asset.height;
                return base.PreferredHeight;
            }
        }

        public override void RunWidthLayout() {
            throw new NotImplementedException();
        }

        public override void RunHeightLayout() {
            throw new NotImplementedException();
        }

        public override float MinHeight {
            get {
                if (image.useNativeSize && image.Asset != null) return PaddingVertical + BorderVertical + image.Asset.height;
                return base.MinHeight;
            }
        }

        public override float MaxHeight {
            get {
                if (image.useNativeSize && image.Asset != null) return PaddingVertical + BorderVertical + image.Asset.height;
                return base.MaxHeight;
            }
        }

        protected override Size RunContentSizeLayout() {
            Texture2D asset = image.Asset;
            if (asset == null) {
                return new Size();
            }

            return new Size(asset.width, asset.height);
        }

    }

}