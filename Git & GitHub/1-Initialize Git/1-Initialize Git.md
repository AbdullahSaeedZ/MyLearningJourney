# 1. Initialize Git & Basic Setup

### 1. Git Configuration
Before creating commits, Git must know your identity. These values attach author metadata to every commit you make.

# Set your global identity
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"

# Configuration scopes:
# git config --system  -> Applies to all users on the OS (/etc/gitconfig)
# git config --global  -> Applies to your user account (~/.gitconfig)
# git config --local   -> Applies only to the current repo (.git/config)

# View all active configuration key-value pairs
git config --list


### 2. Repository Initialization
To turn an ordinary folder (working directory) into a Git repository:

cd /path/to/project
git init

What happens internally:
- Creates a hidden `.git` directory inside the folder.
- The `.git` directory acts as the local repository database containing configs, hooks, refs, and the object store.
- At this stage, working directory files remain completely untracked. No objects (blobs or trees) exist yet, and the index (staging area) is empty.


### 3. Checking Working Tree Status
Inspect the state of your working directory against the repository index:

git status

What it reports:
- Current active branch.
- Untracked files (files present on disk that have not been added to staging).
- Changes staged for commit vs. changes not staged.