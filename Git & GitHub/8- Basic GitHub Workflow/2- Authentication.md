# Lesson 10: Remote Authentication: HTTPS vs. SSH

When you interact with a public repository to view or read files, no identity verification is required. However, the moment you attempt to **write changes**—such as executing `git push`—the remote server (e.g., GitHub, GitLab) must confirm who you are and whether you have write access to that repository container.

Git communicates with remotes primarily through two secure protocols:
1. **HTTPS (Hypertext Transfer Protocol Secure)**
2. **SSH (Secure Shell)**

---

## 1. HTTPS Authentication

HTTPS is the default protocol when copying a repository link (`https://github.com/user/repo.git`).

```
+-----------------------------------------------------------------------------+
|                          HTTPS AUTHENTICATION FLOW                          |
+-----------------------------------------------------------------------------+

  [ Local Machine ]                                    [ GitHub Remote ]
         |                                                     |
         | --- 1. git push origin main ----------------------> |
         |                                                     |
         | <--- 2. Request Credentials (401 Unauthorized) ---- |
         |                                                     |
         |  [ Credential Helper Prompt / IDE Sign-in ]         |
         |  - Username: your-username                          |
         |  - Token/Password: ghp_xxxxxxxxxxxx                 |
         |                                                     |
         | --- 3. Send Credentials --------------------------> |
         |                                                     |
         | <--- 4. Authorized (200 OK) + Store in Helper ----- |
         |                                                     |
         | ===> 5. Uploads commits and objects                 |
```

### How HTTPS Works in Practice:
- **Triggered on Write:** When you run `git push` for the first time, Git detects that credentials are required.
- **The Modern Password Rule:** As of August 2021, GitHub **does not accept your account password** via the command line. Instead, it requires a **Personal Access Token (PAT)** or browser-based OAuth authentication.
- **IDE and Browser Automation:**
  - If you use an IDE (JetBrains Rider, Visual Studio, VS Code) or Git for Windows, a login dialog or web browser window pops up asking you to authorize your GitHub account.
  - Once signed in, Git hands the token to the OS credential manager (such as **Git Credential Manager** on Windows).
- **Secure Caching:** You do **not** type your credentials every time you push. Git caches the secure token inside Windows Credential Manager; all subsequent pushes authenticate automatically in the background.

---

## 2. SSH Authentication (Secure Shell)

While HTTPS is simple to set up, **SSH** is the industry standard and the most popular option among professional software engineers.

### Why SSH is the Preferred Choice:
With HTTPS, tokens can expire, and browser re-authentication prompts can disrupt automated tools. SSH eliminates this friction entirely by relying on **cryptographic key pairs**.
* **Real-World Analogy:** Think of HTTPS like a hotel key card: it is programmed temporarily, can expire, and sometimes requires a trip to the front desk to revalidate. SSH is like a physical key to your house: keep it safely in your pocket, and as long as the lock on the door (GitHub) matches, you open it instantly with zero prompts.

---

### Step 1: Switching from HTTPS to SSH

To switch an existing local repository from HTTPS to SSH, update the remote URL directly.

> **Command Quick-Reference:**
> * `git remote add origin <URL>`: Registers `origin` for the **first time**.
> * `git remote set-url origin <URL>`: Updates the address of an **already existing** `origin`.

Update your repository to use its SSH URL:

```bash
asz14@Abdullah MINGW64 /d/Development/github-repo (main)
$ git remote set-url origin git@github.com:AbdullahSaeedZ/rrepo.git

asz14@Abdullah MINGW64 /d/Development/github-repo (main)
$ git remote -v
origin  git@github.com:AbdullahSaeedZ/rrepo.git (fetch)
origin  git@github.com:AbdullahSaeedZ/rrepo.git (push)
```

Notice the URL format difference:
- **HTTPS:** `https://github.com/AbdullahSaeedZ/rrepo.git`
- **SSH:** `git@github.com:AbdullahSaeedZ/rrepo.git`

---

### Step 2: What Happens When You Push Without an SSH Key?

Let's test pushing immediately:

```bash
asz14@Abdullah MINGW64 /d/Development/github-repo (main)
$ git push origin main
The authenticity of host 'github.com (20.233.83.145)' can't be established.
ED25519 key fingerprint is: SHA256:+DiY3wvvV6TuJJhbpZisF/zLDA0zPMSvHdkr4UvCOqU
This key is not known by any other names.
Are you sure you want to continue connecting (yes/no/[fingerprint])? yes
```

#### 1. Host Verification (MITM Protection)
Before SSH ever checks your account or permissions, it checks whether the remote server itself can be trusted. Because this machine has never talked to GitHub over SSH, GitHub is not yet recorded in your local known hosts file (`~/.ssh/known_hosts`).
- Type **`yes`** and press Enter.
- SSH saves GitHub's signature permanently into your local machine so it will not ask again.

#### 2. The Permission Rejection
Right after confirming the host, GitHub checks if you have access:

```text
git@github.com: Permission denied (publickey).
fatal: Could not read from remote repository.

Please make sure you have the correct access rights
and the repository exists.
```

The server rejects the push with `Permission denied (publickey)`. GitHub does not have your public key on file yet, so it refuses to let you write.

---

### Step 3: How SSH Keys Authenticate (Core Concept)

SSH uses **Asymmetric Cryptography** consisting of two matching files called a **Key Pair**:

```
+-----------------------------------------------------------------------------------+
|                            SSH KEY-PAIR ARCHITECTURE                              |
+-----------------------------------------------------------------------------------+

     [ YOUR LOCAL COMPUTER ]                                [ GITHUB SERVERS ]
     =======================                                ==================
     Private Key (~/.ssh/id_ed25519)                        Public Key (~/.ssh/id_ed25519.pub)
     - Stays strictly on your local disk.                   - Added to your GitHub account.
     - NEVER shared, copied, or uploaded!                   - Safe for anyone to see.
               |                                                      |
               |                                                      |
               +-------------------- Handshake Challenge -------------+
                                                |
                              GitHub challenges your machine:
                           "Can you decrypt/sign this challenge
                                using your private key?"
                                                |
                                                v
                                         ACCESS GRANTED!
```

* **The Public Key (`.pub`):** This is the **lock**. You place this lock onto your GitHub profile.
* **The Private Key:** This is the **physical key**. It lives strictly inside your computer (`~/.ssh/`).
* When you push, GitHub sends a challenge. Your machine proves ownership using the private key without ever sending the private key across the network.

---

### Step 4: Generating Your SSH Key Pair

GitHub documents setup instructions inside account settings under **Settings** $\rightarrow$ **SSH and GPG keys**. The recommended modern standard is **`ed25519`**.

> **Note:** The email used in the `-C` flag should match the email configured in your Git repository (`git config user.email`).

Generate your key pair using Git Bash:

```bash
asz14@Abdullah MINGW64 /d/Development/github-repo (main)
$ ssh-keygen -t ed25519 -C "asz1095136568@gmail.com"
Generating public/private ed25519 key pair.
Enter file in which to save the key (/c/Users/asz14/.ssh/id_ed25519): 
Enter passphrase for "/c/Users/asz14/.ssh/id_ed25519" (empty for no passphrase): 
Enter same passphrase again: 
Your identification has been saved in /c/Users/asz14/.ssh/id_ed25519
Your public key has been saved in /c/Users/asz14/.ssh/id_ed25519.pub
The key fingerprint is:
SHA256:IPvi4b+4pYMuGewnWLa4tG5cHoo+bnNar2DPUmLS2hg asz1095136568@gmail.com
The key's randomart image is:
+--[ED25519 256]--+
|                 |
|                 |
|    . .          |
|     o .         |
|..  .   S        |
|E+++ .           |
|B#*++ o          |
|@@X*o*           |
|BXX+B=o.         |
+----[SHA256]-----+
```

*(Press Enter on all prompts to accept default file paths and proceed without a passphrase).*

Two key files now reside in `/c/Users/asz14/.ssh/`:
1. `id_ed25519`: Your **Private Key** (keep this secret on your machine).
2. `id_ed25519.pub`: Your **Public Key** (the lock to give to GitHub).

---

### Step 5: Adding the Public Key to GitHub

Print out your **Public Key** using `cat`:

```bash
asz14@Abdullah MINGW64 /d/Development/github-repo (main)
$ cat ~/.ssh/id_ed25519.pub
ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIN/L9Nk4rVPxIzs1fQCzxQrmB65H1e5Q76FIDIDCVO7S asz1095136568@gmail.com
```

#### How to Add It on GitHub:
1. Copy the full line printed above.
2. Go to **github.com** $\rightarrow$ Click your profile avatar $\rightarrow$ **Settings**.
3. In the left sidebar under the **Access** group, select **SSH and GPG keys**.
4. Click the green button: **New SSH key**.
5. Set a **Title** identifying this device (e.g., `Personal PC`).
6. Paste the copied string into the **Key** textarea and click **Add SSH key**.

Once added, GitHub lists the key with its fingerprint, creation date, and assigned permissions (**Read / Write**). Its status begins as **`Never used`**.

---

### Step 6: Pushing and Verifying Success

Now push your branch to GitHub:

```bash
asz14@Abdullah MINGW64 /d/Development/github-repo (main)
$ git push -u origin main
Enumerating objects: 3, done.
Counting objects: 100% (3/3), done.
Writing objects: 100% (3/3), 220 bytes | 220.00 KiB/s, done.
Total 3 (delta 0), reused 0 (delta 0), pack-reused 0 (from 0)
To github.com:AbdullahSaeedZ/rrepo.git
 * [new branch]      main -> main
branch 'main' set up to track 'origin/main'.
```

The upload finishes cleanly without prompting for passwords or tokens.

#### Verification
Return to GitHub **Settings** $\rightarrow$ **SSH and GPG keys** and refresh the page. The key's badge changes from **`Never used`** to **`Added on [Date] — Last used within the last week`**, confirming that your SSH key authenticated the session.

---

---

---

## 7. Real-World Team Workflow: Contributing to a Company Project

In a professional software team, you will rarely be working on repositories owned by yourself. Instead, projects belong to a company organization or a client account.

To understand how keys work in a team setting, you must separate the process into two distinct stages:
1. **Authentication (Identity):** *"Who is the person typing at this terminal?"*
2. **Authorization (Permissions):** *"Is that specific person allowed to edit this company project?"*

When the company adds your GitHub username (`AbdullahSaeedZ`) as a collaborator, they solve **Authorization**. But when your terminal talks to GitHub over SSH, GitHub needs your **SSH Key** to solve **Authentication** (acting as your digital passport).

```
+-----------------------------------------------------------------------------------------+
|                              THE TWO-STAGE ACCESS MODEL                                 |
+-----------------------------------------------------------------------------------------+

   [ YOUR LAPTOP ]
   - Holds your Secret Private Key: ~/.ssh/id_ed25519
              |
              | 1. Initiates "git clone" or "git push"
              v
   [ GITHUB SSH GATEWAY: AUTHENTICATION ]
   - GitHub checks all registered Public Keys in its database.
   - Finds matching key on profile: "AbdullahSaeedZ".
   - VERDICT: "The person at this machine IS THE REAL AbdullahSaeedZ."
              |
              | 2. Identity confirmed, moves to access control
              v
   [ COMPANY REPO (TechCorp/payment-gateway): AUTHORIZATION ]
   - GitHub checks the collaborator list for this repository:
       * JaneDoe        -> Admin
       * AbdullahSaeedZ -> Write Access (Collaborator)
       * BobSmith       -> Read Only
   - VERDICT: "Abdullah is authorized to push here. Grant access!"
```

Because your SSH key represents **your physical workstation** (not the company), it lives inside **your personal account**. That single key allows you to push to your own side projects, university work, and any company repositories you are invited to join.

---

### Step-by-Step Team Contribution Workflow

Here is the exact sequence of how you join and contribute to a company codebase from scratch.

#### Step 1: Generate Your Key Pair (Machine-Level)
`ssh-keygen` is a general operating system command, not a Git command. You run it once per computer from **any folder** in your terminal:

```bash
ssh-keygen -t ed25519 -C "asz1095136568@gmail.com"
```
Press Enter through all prompts to accept default locations. This writes two files into your user profile folder (`~/.ssh/`):
* `id_ed25519`: Your **Private Key** (stays on your disk, never shared).
* `id_ed25519.pub`: Your **Public Key** (the lock we upload to GitHub).

#### Step 2: Register Your Public Key to Your Own GitHub Account
Print and copy your public key:

```bash
cat ~/.ssh/id_ed25519.pub
```

1. Go to **github.com** $\rightarrow$ Click your profile avatar $\rightarrow$ **Settings**.
2. On the left sidebar under **Access**, click **SSH and GPG keys**.
3. Click **New SSH key**, paste the string, and click **Add SSH key**.

******* Your physical machine is now officially linked to your GitHub account identity *******

Authentication is complete. GitHub can now verify that any SSH connection from this machine is indeed you.

now the next step is to get authorization from the company to access their private repository.

#### Step 3: Company Grants Repository Permission
The company administrator goes into the settings of the company repository (`TechCorp/payment-gateway`), navigates to **Collaborators**, and invites your GitHub handle: `AbdullahSaeedZ`.

You accept the invitation via email or GitHub notifications.

#### Step 4: Clone the Company Project Directly Over SSH
Because your SSH key already proves who you are and your account has been granted access, you can clone the private project immediately:

```bash
asz14@Abdullah MINGW64 /d/Work
$ git clone git@github.com:TechCorp/payment-gateway.git
Cloning into 'payment-gateway'...
remote: Enumerating objects: 450, done.
Receiving objects: 100% (450/450), 1.20 MiB | 2.50 MiB/s, done.
```

#### Step 5: Work, Branch, and Push
Navigate into the company repo, create a dedicated feature branch, make your commits, and push to GitHub:

```bash
asz14@Abdullah MINGW64 /d/Work/payment-gateway (main)
$ git switch -c feature/invoice-pdf

# ... make changes to codebase and commit locally ...

asz14@Abdullah MINGW64 /d/Work/payment-gateway (feature/invoice-pdf)
$ git push -u origin feature/invoice-pdf
Enumerating objects: 7, done.
To github.com:TechCorp/payment-gateway.git
 * [new branch]      feature/invoice-pdf -> feature/invoice-pdf
branch 'feature/invoice-pdf' set up to track 'origin/feature/invoice-pdf'.
```

GitHub verifies your signature, confirms that `AbdullahSaeedZ` has write permissions on `TechCorp/payment-gateway`, and accepts the push cleanly with zero password prompts.