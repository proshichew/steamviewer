namespace Steamviewer.Entities.ComponentModels
{
    public class GameScreenshot
    {
        public GameScreenshot(string thumbnailPath, string fullImagePath)
        {
            ThumbnailPath = thumbnailPath;
            FullImagePath = fullImagePath;
        }

        public string ThumbnailPath { get; }  // Путь к уменьшенному скриншоту (превью)
        public string FullImagePath { get; }   // Путь к полноразмерному скриншоту
    }
}
