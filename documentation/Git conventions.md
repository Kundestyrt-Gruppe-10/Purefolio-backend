# Git conventions

# Git-flow

1. Branch out from the master branch with the following format: 

     CUS-XX/Description-of-task

     XX is the task number in Linear and the description is concatenated by dashes.

2. Write code and commit. 
3. Open a pull request beginning with "WIP: " from the branch to master. This will move the task in Linear to "In Progress". There has to be a commit on a branch to open a pull request. 
4. Write more code and commit. Commit often until you are satisfied with the result. 
5. Rebase your branch on top of master. If there have been many unnecessary commits on your branch, you may squash commits for less complexity. 
6. Request a review from someone to review your code. This will move the task to "Pending Approval" in Linear. Commit new changes to the same branch when needed to. Keep asking for reviews until your pull request is approved. 
7. Click squash and merge. This will move the task in Linear to "Done". 

# Branches

We have a master branch and this is the one we are branching out from and merging into.

- Why we choose to do it like this...

    Since we don't need a working version in production at all times it is easier to have one that we are all working towards. This drastically reduces the complexity of the project architecture and reduces the amount of problems we will face.  

## Creating branches

Branches should always be branched out from master

Naming branches:

- We will define this when we integrate the tasks in our Kanban board to git. In the mean time, only use a short description of what your goal is to add/remove/change.
- We always write in English
- We use all lower caps with dashes in between. For instance: *add-esg-data*

## Merging branches

We use rebase before we merge branches. This way the extra commit (there is only one since we are squashing commits before merging) is added on top of the tree. Then, our history is straight and easy to understand. Additionally we do not get extra, auto-generated merge commits that clutter our history. 

- Learn more here:

    [https://www.youtube.com/watch?v=dO9BtPDIHJ8](https://www.youtube.com/watch?v=dO9BtPDIHJ8)

# Commits

- We will follow the 7 rules of commits:
    1. Separate subject from body with a blank line
    2. Limit the subject line to 50 characters
    3. Capitalize the subject line
    4. Do not end the subject line with a period
    5. Use the imperative mood in the subject line
        - Example: Fix bug concerning this and that
        - *Not: F*ixed the bug concerning this and that
    6. Wrap the body at 72 characters
    7. Use the body to explain what and why vs. how

- What we wrote originally in the group contract

    - Workflow
        - We use a semi trunk based development with Git.
            1. We name new branches like this: <User story number>/Short-description. Example: LCL-101/User-repository
            2. If bugfix without a connected issue: Bug/<short-description>
        - Master (production, common) <= Feature branches (individual)
        - Commits in English
        - Commits describe what changes or is added. Think "This commit will.."
        - Commit beskriver hva som endres/legges til
        - We will follow the 7 rules of commits:
            1. Separate subject from body with a blank line
            2. Limit the subject line to 50 characters
            3. Capitalize the subject line
            4. Do not end the subject line with a period
            5. Use the imperative mood in the subject line
                - Example: Fix bug concerning this and that
                - *Not: F*ixed the bug concerning this and that
            6. Wrap the body at 72 characters(will this be necessary if we use Gitlab though?)
            7. Use the body to explain what and why vs. how
        - We will try to rebase and squash as much as possible, in order to keep the Git log clean.