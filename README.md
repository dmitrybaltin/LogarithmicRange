# LogarithmicRangeAttribute for Unity

A custom Unity Property attribute that creates sliders in the Inspector like Range attribute but with logarithmic scaling.  
Useful for parameters that span multiple orders of magnitude, such as audio levels or physics properties.

## Usage

1. Add the `[LogarithmicRange(min, max)]` attribute to any `float` field.
2. The field will appear as a logarithmic slider in the Inspector, with an optional input field for manual value entry.

## Example

```csharp
using Baltin.LogarithmicRange;
using UnityEngine;

public class LogarithmicRangeExample : MonoBehaviour
{
    [LogarithmicRange(0.1f, 1000f)]
    public float logValue = 1f;
}
```
