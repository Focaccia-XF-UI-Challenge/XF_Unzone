using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unzone.Content;
using Unzone.ViewModels;
using Xamarin.Forms;

namespace Unzone
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
#if DEBUG
            //Xamarin.Forms.DebugRainbows.DebugRainbow.SetIsDebug(this, true);
#else

#endif
            this.BindingContext = new MainViewModel();
        }

        uint animationSpeed = 250;

        private async void TimeCellGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //淡出PopupPage
            FadeBackground.Opacity = 0;
            FadeBackground.IsVisible = true;
            _ = FadeBackground.FadeTo(1, animationSpeed);

            #region 動態定位點到的元件且待出資料
            //取得點到的是哪一筆
            var element = (TimeCell)sender;
            //帶出選到值
            FakeCell.BindingContext = element.BindingContext;

            PositionDropDown(element, FrontSide);
            PositionDropDown(element, BackSide);
            #endregion

            //先隱藏元件
            FrontSide.IsVisible = true;

            DeleteDropdown.IsVisible = false;
            EditDropdown.IsVisible = false;
            InfoDropdown.IsVisible = false;
            BackSide.IsVisible = false;
            //再打開
            await OpenDropDown(DeleteDropdown);
            await OpenDropDown(EditDropdown);
            await OpenDropDown(InfoDropdown);


        }

        private void PositionDropDown(VisualElement parent, VisualElement dropDown)
        {
            AbsoluteLayout.SetLayoutFlags(dropDown, AbsoluteLayoutFlags.None);
            var dropDownContainerRect = new Rectangle(0, parent.Bounds.Top, this.Width, dropDown.Height);
            AbsoluteLayout.SetLayoutBounds(dropDown, dropDownContainerRect);
        }

        private async Task OpenDropDown(View view)
        {
            view.IsVisible = true;
            view.RotationX = -90;
            view.Opacity = 0;
            await view.FadeTo(1, animationSpeed);
            await view.RotateXTo(0, animationSpeed);

        }

        private async Task CloseDropDown(View view)
        {
            _ = view.FadeTo(0, animationSpeed);
            await view.RotateXTo(-90, animationSpeed);
            view.IsVisible = false;

        }

        private async void BackgroundTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //關閉動畫
            await CloseDropDown(InfoDropdown);
            await CloseDropDown(EditDropdown);
            await CloseDropDown(DeleteDropdown);

            //取消跳出
            await FadeBackground.FadeTo(0, 100);
            FadeBackground.IsVisible = false;
        }

        private async void DeleteTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await CloseDropDown(InfoDropdown);
            FakeCell.IsVisible = true;
            //選轉道詢問是否刪除
            await Flip(FrontSide, BackSide);
            //await DropDownContainer_Popup.RotateYTo(-90, animationSpeed, Easing.SpringIn);
            //DropDownContainer_Popup.RotationY = 90;
            //BackSide.IsVisible = true;
            //FrontSide.IsVisible = false;
            //await DropDownContainer_Popup.RotateYTo(0, animationSpeed, Easing.SpringIn);
        }

        /// <summary>
        /// 建立一個選轉的方法
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private async Task Flip(VisualElement from, VisualElement to)
        {
            await from.RotateYTo(-90, animationSpeed, Easing.SpringIn);
            to.RotationY = 90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateYTo(0, animationSpeed, Easing.SpringIn);
        }

        private async void NoButtonTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //把他轉回正面
            await Flip(BackSide, FrontSide);

            //await DropDownContainer_Popup.RotateYTo(-90, animationSpeed, Easing.SpringIn);
            //DropDownContainer_Popup.RotationY = 90;
            //FrontSide.IsVisible = true;
            //BackSide.IsVisible = false;
            //await DropDownContainer_Popup.RotateYTo(0, animationSpeed, Easing.SpringIn);

            await OpenDropDown(InfoDropdown);
        }
    }
}
