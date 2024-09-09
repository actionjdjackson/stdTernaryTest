# stdTernary #
## A standard library for Ternary operations in C# ##

Since the binary computer operates in bytes, even when dealing with boolean values, I decided to use the signed byte as the carrier for the Balanced Ternary values 1, -1, and 0. Any negative number is 
considered -1 and all positive numbers 1, and zero is 0. I could have used two booleans but I think the performance would be about the same. I might give it a test run in the near future and find out if a pair of 
booleans is actually faster than a `sbyte`, but the consensus seems to be that there is no performance advantage to a bool over a byte.

All bitwise and bytewise operators have been overriden for trits and trytes. I am currently using the `*` operator on trits for XNOR/MULTIPLY and have not used the XOR `^` operator in its place, since XOR is a 
specifically binary operation, according to Stack Overflow - lol. The classes are `BalTrit` and `BalTryte` - and the `BalTryte` can be modified easily to be any number of trits 
you want, up to 10 trits with the current implementation. Each `BalTryte` holds a combination of an array of `BalTrit`s, an array of `char`s ( `+ , -, or 0` ), and a `short` value for binary equivalent and doing the 
math operator overrides like addition, subtraction, multiplication, division, modulus, etc.

Includes a customizable `BalInt` class that can have any number of total trits in its implementation. It follows the same convention as the BalTryte, but is able to work with non-multiples of trytes - like 21-trit or 32-trit integers.

Also includes a customizable `BalFloat` class that can have any number of total trits, separated into a exponent and a significand, with 1/3 going to the exponent and 2/3 going to the significand. I might change this to 1/4 and 3/4 since the range of magnitude values is extremely large with 1/3 - far beyond what `double` can handle in most cases. It doesn't have to be a multiple of 3, though that is preferable (27 is a nice number). The `BalFloat` class holds a combination of an array of `BalTrits` for the exponent and the signficand and the whole float combined, an array of `char`s ( `+ , -, or 0` ) for the whole float, and a `double` for binary equivalent and math operations.

Will probably soon test actual Ternary math and see if it's any faster or makes more sense than performing the math in binary (with `double`s and `short`s and `long`s and then converting back to Ternary).

Also includes most of the `Math` functions specifically for use with these `BalFloat`s in a static class called `TernaryMath`. I also added a Log3 function and trit increment/decrement for `BalFloat`s.

The `char[]` value is for interoperability with my "Action Ternary Simulator" which runs on strings of `+, -, and 0` characters and does all the math in Ternary.

Might include unbalanced ternary versions of these classes, too.

`BalTryte` and `BalFloat` and `BalInt` have modifiable static integer values which is where you can "customize" them to certain sizes - `N_TRITS_PER_TRYTE`, and `N_TOTAL_TRITS` (`N_TRITS_SIGNIFICAND` and `N_TRITS_EXPONENT` too), and `N_TRITS_PER_INT` respectively.

I throw a lot of Exceptions when dealing with numbers outside the range of the Balanced Ternary classes' acceptable values - which is annoying so I might change it to a "zero" value whenever the values are too large  (either positive or negative) and type casting is involved.

### License ###
The MIT License (MIT)
Copyright © 2024 Jacob Jackson

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
