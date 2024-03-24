# Programming Fundamentals

Welcome to the Programming Fundamentals repository! This resource is designed for those beginning their journey in software development, offering a comprehensive guide through essential programming concepts, data structures, algorithms, and more. Whether you're learning C# for the first time or brushing up on basics, this repository aims to provide a solid foundation in programming principles.

## Description

This repository contains a collection of explanations, code examples, and exercises aimed at teaching the fundamentals of programming using C#. Each section is dedicated to a specific concept, ensuring a structured and step-by-step approach to learning.

## Table of Contents

- [Programming Fundamentals](#programming-fundamentals)
  - [Description](#description)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Basic Syntax and Control Structures](#basic-syntax-and-control-structures)
  - [Data Structures](#data-structures)
  - [Algorithms](#algorithms)
  - [Functions](#functions)
  - [Object-Oriented Programming (OOP)](#object-oriented-programming-oop)
  - [Exception Handling](#exception-handling)
  - [File Input/Output (I/O)](#file-inputoutput-io)
  - [Concurrency Basics](#concurrency-basics)
  - [Running Tests](#running-tests)
    - [Running All Tests](#running-all-tests)
    - [Running a Single Test](#running-a-single-test)
  - [How to Contribute](#how-to-contribute)
  - [License](#license)

## Introduction

This section provides an overview of programming fundamentals, including what programming is, why it's important, and how to get started with C#.

## Basic Syntax and Control Structures

Learn about the basic building blocks of C#, including variables, data types, and control structures like if statements and loops.

- [Variables and Data Types](/basic-syntax/variables.md)
- [Control Structures](/basic-syntax/control-structures.md)

## Data Structures

Dive into basic data structures that are essential for organizing and storing data effectively.

- [Arrays](/data-structures/arrays.md)
- [Lists](/data-structures/lists.md)
- [Stacks and Queues](/data-structures/stacks-queues.md)
- [Maps/Dictionaries](/data-structures/maps-dictionaries.md)

## Algorithms

Explore basic algorithms for sorting and searching, understanding how to manipulate and process data efficiently.

- [Sorting Algorithms](/algorithms/sorting.md)
- [Searching Algorithms](/algorithms/searching.md)

## Functions

Understand how to define and use functions in C#, including concepts of parameters, return types, and scope.

## Object-Oriented Programming (OOP)

Get acquainted with OOP principles, learning how to model real-world entities using classes and objects.

## Exception Handling

Learn how to handle errors and exceptions in C#, ensuring your programs can deal with unexpected issues gracefully.

## File Input/Output (I/O)

Discover how to work with files, including reading from and writing to files, to handle data persistence in your applications.

## Concurrency Basics

An introduction to concurrency, understanding how to write programs that can do multiple things at once, enhancing performance and responsiveness.

## Running Tests

This project includes unit tests to verify the correctness of the programming concepts discussed. Running these tests ensures that the code examples and exercises behave as expected.

### Running All Tests

To run all tests within the project, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the root directory of the project where the `.csproj` file is located.
3. Execute the command:

This command will find and run all tests, providing a summary of the results, including which tests passed and which failed.

### Running a Single Test

If you want to run a specific test, you can do so by using the `--filter` option with the `dotnet test` command. This is particularly useful for isolating a single test for debugging or focused testing.

For example, to run a test method named `CheckAgeGroupTest_Child`, use the following command:

```bash
dotnet test --filter FullyQualifiedName~YourNamespace.YourTestClass.CheckAgeGroupTest_Child

dotnet test --filter CheckAgeGroupTest_Child
```

## How to Contribute

Contributions are welcome! If you have suggestions, corrections, or content to add, please submit a pull request or open an issue. See [CONTRIBUTING.md](CONTRIBUTING.md) for more details.

## License

This project is licensed under the [MIT License](LICENSE.md) - see the file for details.

