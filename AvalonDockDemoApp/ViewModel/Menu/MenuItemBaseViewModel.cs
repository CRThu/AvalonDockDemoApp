﻿using AvalonDockDemoApp.ViewModel.Message;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DryIoc.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public abstract partial class MenuItemBaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string header;

        [ObservableProperty]
        private bool isCheckable;

        [ObservableProperty]
        //[NotifyPropertyChangedRecipients]
        private bool isChecked;

        [ObservableProperty]
        private List<object> items;

        public MenuItemBaseViewModel()
        {
            Header = "<NULL>";
            IsCheckable = false;
            IsChecked = false;
            Items = new List<object>();
        }


        [RelayCommand]
        public void Click()
        {
            OnItemClicked();
        }

        public virtual void OnItemClicked()
        {
            Debug.WriteLine($"[MenuItemBaseViewModel]: Click MenuItem. Header: {Header}.");
        }
    }
}