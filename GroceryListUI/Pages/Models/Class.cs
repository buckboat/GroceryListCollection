﻿namespace GroceryListUI.Pages.Models
{
    public class DBHelper
    {
        public static IConfiguration config;


        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetttings.json", optional: false, reloadOnChange: true); 
            config = builder.Build();
            return config.GetConnectionString("GroceryConnectionString");
        }

    }

}
