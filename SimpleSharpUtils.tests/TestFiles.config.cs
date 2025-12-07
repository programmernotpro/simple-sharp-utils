public static class TestFilesConfig
{
    public static readonly string BaseDir = @"C:\Users\anton\Desktop\simpleSharpUtils\SimpleSharpUtils.tests\testFiles";

    public static string HelloFile => Path.Combine(BaseDir, "hello.txt");
}