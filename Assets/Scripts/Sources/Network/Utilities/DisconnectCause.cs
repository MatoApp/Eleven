namespace MatoApp.Eleven.Network
{
    /// <summary>
    /// Network切断原因のEnumクラス
    /// </summary>
    public enum DisconnectCause
    {
        None,
        ExceptionOccurred,
        Timeout,
        MaxUserReached,
    }
}
