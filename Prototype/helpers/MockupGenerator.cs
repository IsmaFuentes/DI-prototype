using System;
using Prototype.models;

namespace Prototype.helpers
{    
    public class MockupGenerator
    {
        /// <summary>
        /// Source: https://www.pexels.com/
        /// </summary>
        public static string[] imageUrls = new string[]
        {
            "https://images.pexels.com/photos/531880/pexels-photo-531880.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/259915/pexels-photo-259915.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/1591447/pexels-photo-1591447.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/712319/pexels-photo-712319.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/1114690/pexels-photo-1114690.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/268533/pexels-photo-268533.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/289586/pexels-photo-289586.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/3293148/pexels-photo-3293148.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/4534200/pexels-photo-4534200.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
            "https://images.pexels.com/photos/1486974/pexels-photo-1486974.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
        };

        public static string[] usernames = new string[]
        {
            "ifuentes", "afuentes", "dambros", "abarrera", "egallardo", "jgoñalons", "plopez", "jpons", "asintes", "htorres", "dvictory", 
        };

        public static string[] titles = new string[]
        {
            "Título?", "Título aburrido", "Título llamativo", "Sin ideas para títulos", "Otro título", "Titulín", "Título original", "Nuevo título"
        };

        public static string GetRandomImageUrl()
        {
            int rand = new Random().Next(0, imageUrls.Length - 1);

            return imageUrls[rand];
        }

        public static string GetRandomUsername()
        {
            int rand = new Random().Next(0, usernames.Length - 1);

            return usernames[rand];
        }

        public static string GetRandomTitle()
        {
            int rand = new Random().Next(0, titles.Length - 1);

            return titles[rand];
        }

        public static Detail GenerateDetail()
        {
            var detail = new Detail()
            {
                _id = Guid.NewGuid(),
                user = GetRandomUsername(),
                title = GetRandomTitle(),
                imageUrl = GetRandomImageUrl(),
                timestamp = DateTime.Now,
                detailContent = TextGenerator.GenerateBlobOfText(),
            };

            return detail;
        }
    }
}
