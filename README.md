# BookToggles

Makes the bug and fish books toggleable so that you can switch to other tools
without loosing the benefits of having the book. Currently, the book will stay
active all day unless you close it manually or sleep at night.

## Building and Running Locally

You should be able to build this project by:

1. Running `dotnet restore`
2. Copying your `Assembly-CSharp.dll`, `Mirror.dll`, and `UnityEngine.dll` from
   the game's install in `libs/` at the root of this project.

Standard `dotnet build` options should work, or you could use
`./build_and_run.ps1`, which builds the project, copies the dll to the plugins
folder and runs the game. You'll need to set the `DINKUM_DIR` env variable and
see the documentation for more details.
