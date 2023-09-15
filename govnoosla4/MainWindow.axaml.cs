using System;
using Avalonia.Controls;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace govnoosla4;

public partial class MainWindow : Window
{
    private MySqlConnection connection;
    private MySqlCommand command;
    private List<Users> users = new List<Users>();
    public MainWindow()
    {
        InitializeComponent();
        string connectionString = "Server=10.10.1.24;User=user_01;Password=user01pro;Database=pro1_6";
        connection = new MySqlConnection(connectionString);
        connection.Open();
        
        string query = "SELECT user_id, first_name, last_name, Genders.Name FROM Users JOIN Genders on Users.gender = Genders.id";
        command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            users.Add(new Users(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
        }

        foreach (var item in users)
        {
            this.FindControl<TextBlock>("chertila").Text += item.GetUserData() + "\r\n";
            
            Console.WriteLine(item.GetUserData());
        }
    }
}