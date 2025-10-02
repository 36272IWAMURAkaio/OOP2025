﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWorld
{
    class VIewModel : INotifyPropertyChanged 
        {

        public VIewModel() {
            ChangeMessageCommand = new DelegateCommand(
                () => GreetingMessage = "Bye-bye world");
        }


        private string _greetingMessage = "Hello World!";
        public string GreetingMessage {
            get => _greetingMessage;
            set {
                if(_greetingMessage != value) {
                    _greetingMessage = value;
                    PropertyChanged?.Invoke(
                        this, new PropertyChangedEventArgs(nameof(GreetingMessage)));
                }
            }
        }


        public DelegateCommand ChangeMessageCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
