using Prototype.models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Prototype.helpers
{    
    public class MockupGenerator
    {
        public static Detail GenerateDetail()
        {
            var detail = new Detail()
            {
                _id = Guid.NewGuid(),
                user = $"username",
                title = $"title",
                subtitle = $"subtitle",
                imageUrl = "https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder-1024x512.png",
                timestamp = DateTime.Now,
                detailContent = TextGenerator.GenerateBlobOfText(),
            };

            return detail;
        }
    }
}
