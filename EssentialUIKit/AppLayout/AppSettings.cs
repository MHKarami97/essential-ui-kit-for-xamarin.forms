using EssentialUIKit.AppLayout;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit
{
    /// <summary>
    /// Application settings
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AppSettings
    {
        private bool enableRTL;

        private bool isDarkTheme;

        private int selectedPrimaryColor;

        static AppSettings()
        {
            Instance = new AppSettings();
        }

        public static AppSettings Instance { get; }

        public bool IsSafeAreaEnabled { get; set; } = false;

        public double SafeAreaHeight { get; set; }

        public bool EnableRTL
        {
            get => this.enableRTL;
            set
            {
                if (value == this.enableRTL)
                {
                    return;
                }

                this.enableRTL = value;
                Application.Current.MainPage.FlowDirection =
                    this.enableRTL ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            }
        }

        /// <summary>
        /// Gets the AndroidSecretCode.
        /// </summary>
        public string AndroidSecretCode => "1d01bce1-14b4-4afc-ad7d-d79a3023b0d1";

        /// <summary>
        /// Gets the iOSSecretCode.
        /// </summary>
        public string IOSSecretCode => "8ddc6fec-278a-4772-813c-e3835d108156";

        /// <summary>
        /// Gets the UWPSecretCode.
        /// </summary>
        public string UWPSecretCode => "d8029dc4-10de-4f5c-81ca-0affeff188a7";

        public bool IsDarkTheme
        {
            get => this.isDarkTheme;
            set
            {
                if (this.isDarkTheme == value)
                {
                    return;
                }

                this.isDarkTheme = value;
                if (this.isDarkTheme)
                {
                    // Dark Theme
                    Application.Current.Resources.ApplyDarkTheme();
                }
                else
                {
                    // Light Theme
                    Application.Current.Resources.ApplyLightTheme();
                }
            }
        }

        public int SelectedPrimaryColor
        {
            get => this.selectedPrimaryColor;
            set
            {
                if (this.selectedPrimaryColor == value)
                {
                    return;
                }

                this.selectedPrimaryColor = value;
                Extensions.ApplyColorSet(this.selectedPrimaryColor);
            }
        }
    }
}