# Async and Threading with .NET

Concept: A simple project that explored 3 ways of how a file can be read:
1. In a standard programmatic fashion
2. In an async way
3. By using different Threads to handle this operation outside of the main Thread

This repo is meant to be just a simple exploratory piece of work, without any significant useful real world applications.

## Conditions

In all cases a single .txt file is read and outputs are presented in a console log.

The only condition, is that before the file is fully read, there is a delay of 5 seconds that needs to be handled.
Different processes will handle such delay differently.

## Console Output

When you will run the Main method, you should receive the final output in a console window:

```txt
============Standard Files Reading===============
This gets the job done.

This gets the job done.

This gets the job done.

This gets the job done.

This gets the job done.

Finished reading 5 files in 00:00:25.05
===========Async Files Reading=============
This gets the job done.

This gets the job done.

This gets the job done.

This gets the job done.

This gets the job done.

Finished reading 5 files in 00:00:05.05
===========Threading Files Reading=================
Finished reading 5 files in 00:00:00.01
This gets the job done.

This gets the job done.

This gets the job done.

This gets the job done.

This gets the job done.
```