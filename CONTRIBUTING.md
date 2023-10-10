# Contributing guidelines

If you would like to contribute code to this project, please follow these pull request guidelines:

1. Fork the project
2. Create a branch specifically for the feature you are contributing
3. (Optional but encouraged) Rebase your branch as needed.
4. After you are happy with your work, please make sure to submit a Pull Request from the feature branch.

# Git/Github Quick Reference Guide

For those who are new to git/github

`git checkout -b newbranchname` creates a new branch from your current branch
If you have committed code, but upon finishing your feature, the main branch has progressed, you are encouraged to rebase it to ensure it still works.

To rebase your branch you will need to run the command

```

git rebase --onto <newparent> <oldparent>
git push -f

```
