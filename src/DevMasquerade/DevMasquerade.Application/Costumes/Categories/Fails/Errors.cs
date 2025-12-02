namespace DevMasquerade.Application.Costumes.Categories.Fails;

public partial class Errors
{
    public static class Category
    {
        // здесь можно прописывать бизнес ограничения
        // public static Error ToManyQuestions() =>
        //     Error.Failure(
        //         "question.too.many",
        //         "Пользователь не может открыть более 3 вопросов.");
    }
}