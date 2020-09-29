# Purefolio backend
Backend for the Portfolio project

## Installation
0. Install Docker: https://www.docker.com/

1. Install:
- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
- [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/install/)

2. Clone repo
`git clone https://github.com/Kundestyrt-Gruppe-10/Purefolio-backend.git`

3. Go into repo
`cd Purefolio-backend/`

4. Build application
`dotnet build`

5. Run application
`dotnet run`

## Installation Linux
Install docker: https://www.docker.com/

Use your respective Linux package manager for all steps below:
Install runtime
`dotnet-runtime`

Install SDK
`dotnet-sdk`

Install ASP.Net runtime
`aspnet-runtime`

Install dotnet-ef tool for migrations
`dotnet tool install --global dotnet ef`

Add tool to PATH
`ln -s ~/.dotnet/tools/dotnet-ef /usr/bin/`
