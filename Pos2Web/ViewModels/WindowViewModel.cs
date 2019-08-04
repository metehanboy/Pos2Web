using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Pos2Web
{
    /// <summary>
    /// flat pencere için viewModel
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {

        #region PrivateMember
        private Window mWindow;
        private int mOuterMarginSize = 10;
        #endregion

        #region Public Properties

        public double WindowMinimumWidth { get; set; } = 800;
        public double WindowMinimumHeight { get; set; } = 450;

        public int mWindowsRadius { get; set; } = 10;

        public int ResizeBorder { get; set; } = 6;
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }

        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowsRadius;
            }
            set
            {
                mWindowsRadius = value;
            }

        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }
        /// <summary>
        ///  Uygulama Başlık yüksekliği
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight); } }
        /// <summary>
        /// Gösterilecek Sayfa
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Status;

        #endregion

        #region Commands
        /// <summary>
        /// Pencereyi Butonları
        /// </summary>
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(ResizeBorderThickness));

                mWindowsRadius = (mWindow.WindowState == WindowState.Maximized) ? 0 : 10;

            };

            //Create Commands

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow,GetMousePosition()));

            var resizer = new WindowResizer(mWindow);

        }


        #endregion

        #region Helpers

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        private static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        #endregion

    }
}
