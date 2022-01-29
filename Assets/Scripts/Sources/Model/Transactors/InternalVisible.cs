using System.Runtime.CompilerServices;

/// <summary>
/// テストコードからinternalクラスを見えるようにする
/// </summary>
[assembly: InternalsVisibleTo("MatoApp.Eleven.Model.Transactors.Tests")]
[assembly: InternalsVisibleTo("MatoApp.Eleven.Tests")]