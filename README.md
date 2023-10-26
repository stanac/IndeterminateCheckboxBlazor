# Indeterminate (tri-state) Checkbox for Blazor

Add [nuget](http://nuget.org/packages/IndeterminateCheckboxBlazor):

```
dotnet add package IndeterminateCheckboxBlazor
```

You don't need to register any service or do anything else in Program or Startup class.
Value used for checkbox must be of type `bool?`.

```
@using IndeterminateCheckboxBlazor

<label> <IndeterminateCheckbox @bind-Value="_value" /> Checkbox </label>

@code {
    private bool? _value = false;
}
```

It's possible to set style and class with `Style` and `Class` properties:

```
<IndeterminateCheckbox @bind-Value="_value" Style="" Class="" />
```

To change behavior set `ChangeMode` property:

```
<IndeterminateCheckbox @bind-Value="_value" ChangeModel="ChangeMode.CheckedIndeterminateUnchecked" />
```

This property affects how checkbox value is changed when user clicks on it:

```csharp
public enum ChangeMode
{
    CheckedUncheckedIndeterminate,
    CheckedIndeterminateUnchecked,
    CheckedUnchecked
}
```

See `IndeterminateCheckboxBlazor.TestApp` project for more usage examples.
