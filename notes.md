# NOTES 

## Git installs

### CMD

	λ where git
	C:\DEV\Git\bin\git.exe
	C:\DEV\Git\cmd\git.exe
	
	λ C:\DEV\Git\cmd\git.exe --version
	git version 2.7.2.windows.1

I have other installations of Git provided by various Bash environments:

	λ where bash
	C:\Users\odalet\bash
	C:\DEV\Git\bin\bash.exe
	C:\DEV\Git\usr\bin\bash.exe
	C:\Windows\System32\bash.exe

And:

	C:\DEV\msys64\usr\bin\bash.exe

I also have an older Git installed with [cmder](http://cmder.net/) (`2.6.1.windows.1`).

### TortoiseGit

Uses the one in `C:\DEV\Git\bin`

## Installing git-subrepo

See:

* [https://github.com/ingydotnet/git-subrepo#windows](https://github.com/ingydotnet/git-subrepo#windows)
* [https://github.com/ingydotnet/git-subrepo#windows](https://github.com/ingydotnet/git-subrepo#windows)

### Using Git Bash Here

1. Cloned the repository somewhere
2. Explorer > Right-click the root folder > Git Bash Here

This gives:

	odalet@PC-OLIVIER MINGW64 /d/WORK/FMASHOME/TESTS/git-subrepo-tests/git-subrepo (master)
	$ git --version
	git version 2.7.2.windows.1

Then:

	$ source ./.rc

Installed:

	$ git subrepo
	usage: git subrepo <command> <arguments> <options>
	
	    Commands:
	      clone     Clone a remote repository into a local subdirectory
	      init      Turn a current subdirectory into a subrepo
	      pull      Pull upstream changes to the subrepo
	      push      Push local subrepo changes upstream
	
	      fetch     Fetch a subrepo's remote branch (and create a ref for it)
	      branch    Create a branch containing the local subrepo commits
	      commit    Commit a merged subrepo branch into the mainline
	      merge-base  Find the common ancestor of 2 commits (plumbing command)
	
	      status    Get status of a subrepo (or all of them)
	      clean     Remove branches, remotes and refs for a subrepo
	
	      help      Documentation for git-subrepo (or specific command)
	      version   Display git-subrepo version info
	
	    See 'git help subrepo' for complete documentation and usage of each command.
	
	    Options:
	
	    -h                    Show the command summary
	    --help                Help overview
	    --version             Print the git-subrepo version number
	
	    -a, --all             Perform command on all current subrepos
	    -A, --ALL             Perform command on all subrepos and subsubrepos
	    -b, --branch ...      Specify an upstream branch
	    -f, --force           Force certain operations
	    -F, --fetch           Fetch the upstream content first
	    -r, --remote ...      Specify an upstream remote
	    -u, --update          Add the --branch and/or --remote overrides to .gitrepo
	
	    -q, --quiet           Show minimal output
	    -v, --verbose         Show verbose output
	    -d, --debug           Show the actual commands used
	    -x, --DEBUG           Turn on -x Bash debugging

This has installed git-subrepo for the current session only!

### Automation?

It is possible to amend one of bash's startup scripts, but would that work with the Windows installs? 

* Adding the command to `C:\users\odalet\.bash_profile` (used by Git for Windows ???)
* It works now when opening a Git Bash.
* It DOES NOT work from a CMD prompt.
* NEITHER from my MSys Mingw64 (not the same .bash_profile)
	* Added the command to `C:\DEV\msys64\home\odalet\.bash_profile` -> DOES NOT WORK
	* Added the command to `C:\DEV\msys64\home\odalet\.profile` -> WORKS!!! (Yet still not when launching bash from cmder, I suppose this is because it does not load the profiles)

### Hand-made install

*I tested the concept with a simpler extension: `git activity` available [here](https://bitbucket.org/ssaasen/git-pastiche/src/master/bin/git-activity)*

* Created `C:\DEV\Git\extensions`
* Added this folder to the global system path
* Copied `git-activity` into a new text file
	* Beware: there is a dash and no extension (this is a bash script)
	* Make sure it is saved with unix-style line endings
* Saved the file to `C:\DEV\Git\extensions`
* Restart cmder so that it knows the new PATH
* `git activity` now works (no dash here)  

Adapting to `git subrepo` should just have been a matter of adding by hand the `lib` sub-directory of subrepo's source code to the system PATH. Unfortunately, **THIS DOES NOT WORK**:

	λ git subrepo
	C:\DEV\git-subrepo\lib/git-subrepo.d/bash+.bash: line 1: ../../ext/bashplus/lib/bash+.bash: No such file or directory

I suppose this has something to do wit Windows vs Unix path separators...

The solution was to create a script in `C:\DEV\Git\extensions` that delegates the job to the real subrepo code.

Therefore, I created `C:\DEV\Git\extensions\git-subrepo` that contains:

	#!/bin/bash
	
	source /c/DEV/git-subrepo/.rc
	git subrepo $*

* Removed `C:\DEV\git-subrepo\lib` from the path
* And now it works from a command prompt, although there must be a more efficient way than always reinstall everything... 

## Testing git subrepo

Up to this point, we could install the new command and make sure it was able to display its help page, but nothing more...

### git subrepo version

	λ git subrepo version
	git-subrepo Version: 0.3.0
	Copyright 2013-2016 Ingy döt Net
	https://github.com/git-commands/git-subrepo
	C:\DEV\git-subrepo\lib\git-subrepo
	Git Version: git version 2.7.2.windows.1

### git subrepo --version

	λ git subrepo --version
	0.3.0

### git subrepo -h
Same thing as `git subrepo` with no argument.

### git subrepo --help

	λ git subrepo --help
	Launching default browser to display HTML ...
	fatal: failed to launch browser for C:\DEV\Git\mingw64/share/doc/git-doc/git-subrepo.html

I suppose that for documentation, we'll have to stick to [github](https://github.com/ingydotnet/git-subrepo/wiki). Or try compiling the man pages and display them in Windows...

### git subrepo + TAB

Tab completion works in MINGW (because it is a Linux-like shell) but not in CMD.

## Exercising git subrepo

	> cd ...\priv
	> md pub
	> git subrepo clone 


## Branching

* Have a look at the way git flow extensions get installed on Windows (by SourceTree or by hand). Maybe this would solve the problems with using git subrepo from a CMD prompt.
* Working with branches: See these question: 
	* [https://github.com/ingydotnet/git-subrepo/issues/197](https://github.com/ingydotnet/git-subrepo/issues/197)
	* [https://github.com/ingydotnet/git-subrepo/issues/184](https://github.com/ingydotnet/git-subrepo/issues/184)
	* [https://github.com/ingydotnet/git-subrepo/issues/179](https://github.com/ingydotnet/git-subrepo/issues/179)
	* [https://github.com/ingydotnet/git-subrepo/issues/177](https://github.com/ingydotnet/git-subrepo/issues/177)
* Branches discussion:	
	* The bottom line seems to be that the `priv` repo should always track a special branch of `pub` dedicated to publishing its state to other repos (let's say `pub` has a `publish` branch that would be pulled in all branches of `priv`). That's for pulling
	* As for pushing back to `pub`, pushing from `priv`'s subrepoto a specific `pub` branch created at the time of the push seems also desirable (let's say this -temporary - branch would be called `integration` on `pub`).   
	* Switching branches of a subrepo does not really exist. Instead, the subrepo should be cloned again (from the desired branch). A way to re-clone without being told the sub-directory is not empty is to force it: `git subrepo clone -f ...`; though that would probably not clean the directory. We'd better prepend a `git subrepo clean` before it (See issue #184)
	* Issue #179 explains how to use `-b new_branch` when pushing a subrepo so that it pushes the changes to a `new_branch` in the subrepo's upstream repository.
	* And issue #177 explains how `-b remote_branch` allows to pull changes from the a specific branch of the subrepo's upstream repository. Adding `-u` makes this remote branch the new default (ie. the remote tracking branch for this subrepo). This switch prevents from directly modifying `.subrepo`.
