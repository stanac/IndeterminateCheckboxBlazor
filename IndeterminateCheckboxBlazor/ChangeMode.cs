namespace IndeterminateCheckboxBlazor;

public enum ChangeMode
{
    CheckedUncheckedIndeterminate,
    CheckedIndeterminateUnchecked,
    CheckedUnchecked
}

public static class ChangeModeExtensions
{
    public static bool? GetNextValue(this ChangeMode changeMode, bool? currentValue)
    {
        switch (changeMode)
        {
            case ChangeMode.CheckedUncheckedIndeterminate:
                if (currentValue.HasValue)
                {
                    if (currentValue.Value) return false;
                    return null;
                }

                return true;

            case ChangeMode.CheckedIndeterminateUnchecked:
                if (currentValue.HasValue)
                {
                    if (currentValue.Value) return null;
                    return true;
                }

                return false;
                
            case ChangeMode.CheckedUnchecked:
            default:
                return !(currentValue ?? false);
        }
    }
}