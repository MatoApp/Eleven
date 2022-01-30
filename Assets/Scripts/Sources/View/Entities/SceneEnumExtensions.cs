namespace MatoApp.Eleven.View
{
    /// <summary>
    /// SceneEnumの機能拡張クラス
    /// </summary>
    public static class SceneEnumExtensions 
    {
        public static string GetName(this Scene scene)
        {
            return $"{scene}Scene";
        }
    }
}
