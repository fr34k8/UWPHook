﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UWPHook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameModel games;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            games = new GameModel();
            listView.ItemsSource = games.games;

            var argument = Environment.GetCommandLineArgs();
            string argumentGame = "";
            for (int i = 1; i < argument.Length; i++)
            {
                argumentGame += argument[i] + " ";
            }

            if (argument != null)
            {
                foreach (Game game in games.games)
                {
                    if (game.game_alias.ToLower() == argumentGame.ToLower().Trim())
                    {
                        Process.Start(@"shell:AppsFolder\" + game.game_path);
                    }
                }
            }

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            games.Store();
            games.Add(new Game { game_alias = alias_textBox.Text, game_path = path_textBox.Text });
        }
    }
}