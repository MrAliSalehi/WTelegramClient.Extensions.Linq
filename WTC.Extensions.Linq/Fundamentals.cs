using Optional;
using Optional.Unsafe;
using TL;
using WTC.Extensions.Linq.Wrappers;

namespace WTC.Extensions.Linq;

public static class Fundamentals
{
    public static UpdatesBaseWrapper Updates(this IObject obj) => UpdatesBaseWrapper.From((obj as UpdatesBase)!);

    public static void ForEach(this UpdatesBaseWrapper updatesBase, Action<Update> func)
    {
        foreach (var update in updatesBase.UpdatesBase.UpdateList)
        {
            if (update is null)
                continue;
            func(update);
        }
    }

    public static bool IsNone<T>(this Option<T> op, out T? val)
    {
        if (op.HasValue)
        {
            val = op.ValueOrFailure();
            return false;
        }

        val = default;
        return false;
    }
    public static bool IsSome<T>(this Option<T> op, out T? val)
    {
        // this code is absolute garbage and its only here for the sake of readability in the high level abstracted codes
        var a = !IsNone(op, out var x);
        val = x;
        return a;
    }
}