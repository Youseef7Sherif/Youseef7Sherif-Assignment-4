# Benchmark Results

## Benchmark Purpose

This benchmark compares two approaches for building the academy schedule report:

* String concatenation using `string`
* String concatenation using `StringBuilder`

The benchmark measures execution time for different loop sizes using BenchmarkDotNet.

## Benchmark Environment

* BenchmarkDotNet: 0.15.8
* .NET: 10.0.12
* OS: Windows 10
* CPU: 11th Gen Intel Core i7-1165G7 2.80GHz
* Configuration: Release

## Results

| Iterations | Method                     |          Mean |
| ---------: | -------------------------- | ------------: |
|        100 | StringConcatenation        |     97.202 µs |
|        100 | StringBuilderConcatenation |     10.204 µs |
|      1,000 | StringConcatenation        |     12.443 ms |
|      1,000 | StringBuilderConcatenation |    127.172 µs |
|     10,000 | StringConcatenation        |       2.644 s |
|     10,000 | StringBuilderConcatenation |      1.352 ms |
|    100,000 | StringConcatenation        | Not completed |
|    100,000 | StringBuilderConcatenation | Not completed |

## Benchmark Analysis

### Which approach was faster with 100 iterations?

`StringBuilderConcatenation` was faster.

* String concatenation: **97.202 µs**
* StringBuilder: **10.204 µs**

Therefore, StringBuilder performed better for 100 iterations in this benchmark.

### Which approach was faster with 100,000 iterations?

The 100,000-iteration benchmark did not complete on my machine.

The `StringConcatenation` benchmark reached the 100,000-iteration test, but the execution time became excessively long. Therefore, no final measured result was recorded for 100,000 iterations.

No estimated or fabricated value was used.

### Which approach allocated more memory?

The final `Allocated` values for the parameterized benchmark were not available in the recorded output, so specific allocation values are not reported here.

However, repeated string concatenation can create many intermediate string objects because strings are immutable. This can result in more memory allocations when repeatedly building large strings.

`StringBuilder` is designed to reduce these repeated allocations by maintaining an internal buffer.

### What happened to string concatenation performance as the loop size increased?

The execution time increased significantly as the number of iterations increased:

* 100 iterations: **97.202 µs**
* 1,000 iterations: **12.443 ms**
* 10,000 iterations: **2.644 s**
* 100,000 iterations: **Did not complete in a practical amount of time**

This shows that repeated string concatenation became increasingly expensive as the generated string became larger.

### Why does repeated string concatenation create additional allocations?

Strings in C# are immutable. When the following operation is performed:

```csharp
report += text;
```

the existing string cannot be modified directly. A new string must be created containing the previous content and the new content.

Repeating this operation many times can create many temporary string objects and require repeated copying of existing characters.

### Why does StringBuilder usually perform better when text is repeatedly appended?

`StringBuilder` is designed for repeatedly building and modifying strings.

It maintains an internal buffer and can append new content without creating a completely new string for every append operation. This can reduce repeated copying and improve performance for large numbers of append operations.

### Is StringBuilder always better than normal string operations?

No.

For a small number of simple string operations, normal string concatenation is often simpler and may be perfectly suitable.

`StringBuilder` becomes particularly useful when a string is built through many repeated modifications, especially inside loops.

In this benchmark, the difference became especially significant as the number of iterations increased.

## Conclusion

The benchmark demonstrates that `StringBuilder` performed significantly better than repeated string concatenation for the completed test cases.

At 10,000 iterations:

* String concatenation: **2.644 seconds**
* StringBuilder: **1.352 milliseconds**

The 100,000-iteration test did not complete because the execution time became excessively long on the test machine. No estimated result was used.

The results demonstrate why `StringBuilder` is generally a better choice when repeatedly constructing large strings inside loops.
