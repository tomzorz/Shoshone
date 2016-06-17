# Shoshone

**Some C# tidbits for a better Unity developer experience**

## Here's what you can find here at the moment

### Resharper settings presets

**UnityResharper.DotSettings**

* Disables most of the LINQ suggestions (allocates a lot, usually a bad idea to do in game development)
* Forces braces for multi-line if statements (better readability)
* Disables the convert for to foreach suggestion (for has better performance)
* Disables the missing modifiers suggestion for type members (Unity code style)
* Disables the type or member is never used suggestion (Unity calls the default methods with reflection)
* Disables the namespace foes not correspond to type location suggestion (Unity folder setup and namespaces don't match)
* Disables suggestions for the currently unsupported C# features (You don't want to have suggestions for compilation errors now, do you?)
