# stdTernary #
## A standard library for Ternary operations in C# ##

Since the binary computer operates in bytes, even when dealing with boolean values, I decided to use the signed byte as the carrier for the Balanced Ternary values 1, -1, and 0. Any negative number is 
considered -1 and all positive numbers 1, and zero is 0. I could have used two booleans but I think the performance would be about the same. I might give it a test run in the near future and find out if a pair of 
booleans is actually faster than a `sbyte`.

All bitwise and bytewise operators have been overriden for trits and trytes. I am currently using the `*` operator on trits for XNOR/MULTIPLY and have not used the XOR `^` operator in its place, since XOR is a 
specifically binary operation, according to Stack Overflow - lol. The classes are `BalTrit` and `BalTryte` - and the `BalTryte` can be modified easily to be any number of trits 
you want, up to 10 trits with the current implementation. Each `BalTryte` holds a combination of an array of `BalTrit`s, an array of `char`s ( `+ , -, or 0` ), and a `short` value for binary equivalent and doing the 
math operator overrides like addition, subtraction, multiplication, division, modulus, etc.

Also includes a customizable `BalFloat` class that can have any number of total trits, separated into a exponent and a significand, with 1/3 going to the exponent and 2/3 going to the significand.
It doesn't have to be a multiple of 3, though that is preferable (27 is a nice number). The `BalFloat` class holds a combination of an array of `BalTrits` for the exponent and the signficand and the 
whole float combined, an array of `char`s ( `+ , -, or 0` ) for the whole float, and a `double` for binary equivalent and math operations.

Will probably soon test actual Ternary math and see if it's any faster or makes more sense than performing the math in binary (with `double`s and `short`s and then converting back to Ternary).

Also includes most of the `Math` functions specifically for use with these `BalFloat`s in a static class called `TernaryMath`. I also added a Log3 function.

The `char[]` value is for interoperability with my "Action Ternary Simulator" which runs on strings of `+, -, and 0` characters and does all the math in Ternary.

Planning on a customizable `BalInt` in the near future as well. Might include unbalanced ternary versions of these classes, too.

`BalTryte` and `BalFloat` have modifiable static integer values which is where you can "customize" them to certain sizes - `N_TRITS_PER_TRYTE`, and `N_TOTAL_TRITS` (`N_TRITS_SIGNIFICAND` and `N_TRITS_EXPONENT` too), 
respectively.

