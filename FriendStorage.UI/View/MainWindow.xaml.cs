// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.View
{
    using System.ComponentModel;
    using System.Windows;

    using ViewModel;

    public partial class MainWindow : Window
    {
        #region Fields

        private MainViewModel _viewModel;

        #endregion

        #region Constructors

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = viewModel;
        }

        #endregion

        #region Methods

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _viewModel.OnClosing(e);
        }

        #endregion
    }
}
