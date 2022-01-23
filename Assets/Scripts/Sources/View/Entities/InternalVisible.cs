using System.Runtime.CompilerServices;

/// <summary>
/// テストコードからinternalクラスを見えるようにする
/// </summary>
[assembly: InternalsVisibleTo("MatoApp.Eleven.View.Tests")]
[assembly: InternalsVisibleTo("MatoApp.Eleven.Tests")]