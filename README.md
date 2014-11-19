bootstrap
=========

Simple bootstrapped two-sample t-test in C# (The project file is VS2013, set to compile for .NET 4.5)  
The code is simple enough to port to pretty much any imperative language.

Can be used for hypothesis testing on data with fewer assumptions than normal t-test (in particular, no normality assumption).

Based on an example from http://www.biostat.umn.edu/~will/6470stuff/Class21-12/Handout21.pdf
Uses mean/variance code based on http://www.johndcook.com/blog/standard_deviation/ to help speed things up
