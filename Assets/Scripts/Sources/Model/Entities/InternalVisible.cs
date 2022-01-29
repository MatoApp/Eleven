using System.Runtime.CompilerServices;

/// <summary>
/// テストコードからinternalクラスを見えるようにする
/// </summary>
[assembly: InternalsVisibleTo("MatoApp.Eleven.Model.Entities.Tests")]
[assembly: InternalsVisibleTo("MatoApp.Eleven.Tests")]