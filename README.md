# Parsing of Numbers
Inverse text normalization algorithm for numbers.

## Challenge Description
Application accepts as input an arbitrary text, and outputs the same text but with all numbers that were spelled in words replaced by the equivalent numbers. For example:

>input: He paid twenty million for three such cars.

>output: He paid 20000000 for 3 such cars.

<p align="right">(<a href="#top">back to top</a>)</p>

### Given
> String of words that may be numbers or not; parse the numbers from the string and replace them with their numeral forms.
<p align="right">(<a href="#top">back to top</a>)</p>

### Function Description
> It must return a string: final version of the string after replacing numbers with their numeral forms.
<p align="right">(<a href="#top">back to top</a>)</p>

## My Approach
I decided to use two queues in order to track my operations. At the end of each number in the sentence, I read the queue and convert its contents to numeral form. And in the result queue, I track final form of the string.
Finally I read the contents from the result queue and return the string.

### Algorithm
- Declare two queues (queue & result)
- Split string into words
- Traverse the words (start from index 1)
  - if the previous word is a number add it to queue
  - else add the word to result queue
  - if current word is not a number or end of the string
  - construct sequence and clear the queue
  - then convert sequence to numeral form
  - if we are at the last element and current word is not a number
    - add the word to result queue
- construct string from result queue
- return result string

<p align="right">(<a href="#top">back to top</a>)</p>

## Important Notice
Current algorithm not able to parse the last number(word) if the number is at the end of the string.
Example:
> Here is a number fifty three
'Three' is ignored in this case returned:
> Here is a number 50

Therefore, tests for this case ignored until I fix the issue.

## References
[1] “Inverse Text Normalization as a Labeling Problem.” Apple Machine Learning Research, Apple Inc., Aug. 2017, machinelearning.apple.com/research/inverse-text-normal.

[2] "numbers_in_words" markburns, 2015, github.com/markburns/numbers_in_words

[3] "words2num" revdotcom, 2017, github.com/revdotcom/words2num

## Contact

Sinan Can Soysal - [@sinancansoysal](https://sinancansoysal.com) - sinancsoysal@gmail.com

<p align="right">(<a href="#top">back to top</a>)</p>
