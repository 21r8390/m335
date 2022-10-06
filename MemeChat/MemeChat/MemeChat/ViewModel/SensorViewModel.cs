﻿namespace MemeChat.ViewModel
{
    public static class SensorViewModel
    {
        public static async Task<string> TakePhoto()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    var photo = await MediaPicker.Default.CapturePhotoAsync();
                    return await CreateBase64String(photo);
                }
            }
            catch { /* Handle permision denied */ }

            return string.Empty;
        }

        public static async Task<string> PickPhoto()
        {
            try
            {
                var photo = await MediaPicker.Default.PickPhotoAsync();
                return await CreateBase64String(photo);
            }
            catch { /* Handle permision denied */ }

            return string.Empty;
        }

        private static async Task<string> CreateBase64String(FileResult photo)
        {
            if (photo != null)
            {
                using var stream = await photo.OpenReadAsync();
                using var ms = new MemoryStream();

                stream.CopyTo(ms);
                var bytes = ms.ToArray();

                return Convert.ToBase64String(bytes);
            }

            return string.Empty;
        }
    }
}