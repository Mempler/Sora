using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using ImageMagick;
using Shared.Interfaces;
using Shared.Services;

namespace Shared.Models
{
    public class Achievements : IOsuStringable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public ulong BitId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string IconURI { get; set; }


        public byte[] GetIconImage(bool x2 = false)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(IconURI);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (MagickImage image = new MagickImage(stream))
            {
                if (x2)
                    image.Resize(385, 420);
                else
                    image.Resize(193, 210);
                
                return image.ToByteArray(MagickFormat.Png);
            }
        }

        public string ToOsuString(Database db) => $"{Name}+{DisplayName}+{Description}".Replace('\n', '\t');

        public static Achievements GetAchievement(Database db, string name) => db.Achievements.FirstOrDefault(x => x.Name == name);

        public static Achievements NewAchievement(
            Database db,
            string name,
            string displayName,
            string desc,
            string iconUri,
            bool insert = true)
        {
            Achievements a = new Achievements
            {
                Name = name,
                DisplayName = displayName,
                Description = desc,
                IconURI = iconUri,
                BitId = 1ul << db.Achievements.Count()
            };

            if (!insert) return a;
            
            db.Achievements.Add(a);
            db.SaveChanges();

            return a;
        }
    }
}