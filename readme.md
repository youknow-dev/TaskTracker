# Project Title

Task Tracker

## Description

.NET console application for tracking and managing tasks

## Getting Started

### Dependencies

* Requires the .NET runtime

## Help

```
Usage
  .\TaskTracker.exe <command>

Commands
  add <description>             adds a new task to the database.
  update <task-ID>              updates an existing task in the database.
  delete <task-ID>              deletes an exsiting task int the database.
  mark-in-progress <task-ID>    marks an existing task as InProgress.
  marg-done <task-ID>           marks an existing task as Done.
  list [options]                list the tasks save on the current machine. Specify [options]
                                to restrict which tasks are display, otherwise display all og them. Options include "done", "todo", and "in-progress"
```

## Authors

Contributors names and contact info

ex. Jevaun Whyte  
ex. [@YouKnow](https://github.com/youknow-dev)

## Acknowledgments

Inspiration, code snippets, etc.
* [roadmap-sh](https://roadmap.sh/projects/task-tracker)