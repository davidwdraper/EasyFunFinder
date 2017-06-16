using EasyFunFinder.DAL.Helpers;
using System;
using System.Linq;
using System.IO;
using System.Security.Principal;
using EasyFunFinder.Data;
using Draper.Logger;

namespace EasyFunFinder.DAL
{
    public class BaseDAL
    {
        private Log _logger;

        public BaseDAL(EasyFunFinderContext dc)
        {
            _logger = new Log("EasyFunFinder.WebAPI", WindowsIdentity.GetCurrent().Name);
            DC = dc;
        }

        public EasyFunFinderContext DC { get; private set; }

        protected Log Logger { get { return _logger; } }

        /// <summary>
        /// Many of the models have associated images, so help is added to the base for convienience
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        protected EasyFunFinder.Data.Image NewImage(string fileName, string title, string description, byte[] imageBytes)
        {
            try
            {
                Verify.HasContent("fileName", fileName);
                Verify.IsTrue("fileName contains a '.'", fileName.Contains('.'));
                Verify.NotNull("imageBytes", imageBytes);
                var image = new Image();
                image.Id = Guid.NewGuid();
                image.FileName = fileName;
                image.MimeType = "image/" + Path.GetExtension(fileName).Replace(".", "").ToLower();
                image.Title = title;
                image.Description = description;
                image.Bytes = imageBytes;
                image.DateTimeAdded = DateTime.UtcNow;
                return image;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed creating image for filename: {0}, title: {1}", fileName, title), ex);
            }
        }

        public void AttachImage(Guid entityId, string fileName, string title, string description, byte[] imageBytes)
        {
            try
            {
                var image = NewImage(fileName, title, description, imageBytes);

                using (DC.Database.BeginTransaction())
                {
                    DC.Image.Add(image);
                    DC.SaveChanges();

                    var x = new XEntityToImage
                    {
                        EntityId = entityId,
                        ImageId = image.Id
                    };
                    DC.XEntityToImage.Add(x);
                    DC.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed adding Image for entityID:{0}, FileName:{1}", entityId, fileName), ex);
            }
        }
    }
}
