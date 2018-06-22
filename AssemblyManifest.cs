using System.Reflection;

// Assembly Version(既定使用:AssemblyFileVersion)(<メジャーVer.>.<マイナーVer.>.<ビルド番号[*]>.<リビジョン[*]>(「*」はAssemblyVersionにのみ指定可能。))
[assembly: AssemblyVersion("1.1.*")]
// ファイルバージョン(既定使用:AssemblyVersion)
//[assembly: AssemblyFileVersion("")]
// 製品バージョン(既定使用:AssemblyFileVersion)
//[assembly: AssemblyInformationalVersion("")]
// 製品名
[assembly: AssemblyProduct("きっちんたいま～")]
// 説明(Title)
[assembly: AssemblyTitle("きっちんたいま～")]
// 著作権(「Copyright (c) <西暦年> <名前>.」)
[assembly: AssemblyCopyright("Copyright (c) 2004 Yuki.")]
// コメント
[assembly: AssemblyDescription("「きっちんたいま～」です。")]
// 会社名
[assembly: AssemblyCompany("")]
// 商標
[assembly: AssemblyTrademark("きっちんたいま～")]
// 言語("ja-JP"や"en-US"など。 リソースのみを含むサテライト・アセンブリにのみ指定可能。 メイン・アセンブリには指定できない。(""を設定する))
[assembly: AssemblyCulture("")]
// アセンブリの構成("Release"や"Debug"など。 使われていないので設定しなくても良い。)
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
