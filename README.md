# Indeterminate (tri-state) Checkbox for Blazor

Add [nuget](http://nuget.org/packages/IndeterminateCheckboxBlazor):

```
dotnet add package IndeterminateCheckboxBlazor
```

Use it:

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

To change behavior (order of tri-state values) by setting `ChangeMode` property:

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
