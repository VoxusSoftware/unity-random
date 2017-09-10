# Random Distributions for Unity

* [Overview](#overview)
* [Usage](#usage)
* [Seeding](#seeding)
* [Helpers](#helpers)

![sample-distributions](https://user-images.githubusercontent.com/702158/30249771-e2517dda-963a-11e7-9723-60d7a0bdfc8b.png)

## Overview
This asset is designed to make it easy to produce random numbers with a given distribution.
It allows you to create independent, seedable generators.

## Usage

The available classes are:

1. `RandomLinear(min, max)` - Use a linear distribution, i.e. all values are equally likely  
    `min`: The minimum value  
    `max`: The maximum value

2. `RandomExponential(min, lambda)` - Use an [exponential distribution](https://en.wikipedia.org/wiki/Exponential_distribution) - higher values are exponentially less likely  
    `min`: The minimum value  
    `lambda`: The rate parameter (1 / expectation)

3. `RandomGaussian(sigma, mu)` - Use a [Gaussian or Normal distribution](https://en.wikipedia.org/wiki/Normal_distribution) - values' probabability drops off with distance from the centre  
    `sigma`: The standard deviation; a measure of the width of the peak  
    `mu`: The mean (expectation) value; the centre of the peak
    
```c#
using Voxus.Random;

var myGenerator = new RandomLinear(0, 100);

// Get a random float between 1 and 100
var randomNumber = myGenerator.Get();
```

## Seeding
All the supplied generators have a `SetSeed()` method that can be used to seed each generator independently.
This is especially useful for something like procedural generation.

## Helpers
There's also a `RandomHelpers` class which provides `Range()` to convert a `float` between 0 - 1 to an `int` in a range (for example, to get a random element from an array) and `OnUnitSphere()` to get a point on a unit sphere using `RandomLinear` (which allows seeding, unlike Unity's built-in method).

```c#
using Voxus.Random;

var myGenerator = new RandomLinear(0, 1);

// Set a seed (optional)
myGenerator.SetSeed(0.12345f);

// Get a random element from an array
var randomEntry = myArray[RandomHelpers.Range(myGenerator.Get(), 0, myArray.Length)];

// Get a random point on a unit sphere
var randomPoint = Helpers.OnUnitSphere(myGenerator);
```
