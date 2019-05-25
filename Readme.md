# Experimenting with async/await and variable lifetimes

This is a scratch project for investigating how the async / await state machine transformation affects the lifetime of local variables.

There's a [Stack Overflow question](https://stackoverflow.com/questions/23934352/async-await-issue-with-local-variable-cleanup) with an explanation of what's going on.

Run this both in `Debug` and `Release` mode, and both answering 'y' and 'n' when it asks if it should sleep.

Record which objects get destroyed in which cases in a spreadsheet.

Move things around, or add new objects in different places, and write those down as well.