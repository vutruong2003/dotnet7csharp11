namespace CSharpEleven.FileLocalTypes;

internal class BlogUtil
{
    public static long Costs => new BlogService().GetCosts();
}

internal class AuthorService
{
    public static long SystemCost => BlogUtil.Costs;
}