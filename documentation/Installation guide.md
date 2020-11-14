# Installation guide

Small guide for getting the whole application up and running. This guide will cover the overhead, and reference a lot to external documentation.

---

# Purefolio Backend

## Prerequisite

- Docker: [https://www.docker.com/](https://www.docker.com/)
- NET.Core : [https://docs.microsoft.com/en-us/dotnet/core/install/](https://docs.microsoft.com/en-us/dotnet/core/install/)
- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
1. Clone repo
`git clone https://github.com/Kundestyrt-Gruppe-10/Purefolio-backend.git`
2. Go into repo
`cd Purefolio-backend/`
3. Build application
`dotnet build`
4. Run application
`dotnet run`

### Installation of Dotnet.Core on linux

Use your respective Linux package manager for the command to
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

# Purefolio frontend

# Prerequisites

- NodeJs: [https://nodejs.org/en/](https://nodejs.org/en/)

## Installation

1. Install:
- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
- [Node.js](https://nodejs.org/en/)
1. Clone the repo:

    git clone https://github.com/Kundestyrt-Gruppe-10/Purefolio-webapp.git

2. Go into the repo

    cd Purefolio-webapp/

3. Install dependencies

    npm i

## Run the project locally

- Developing locally is done with `webpack-dev-server` and is run on port 3000.
- Hot reload and history API fallback are enabled by default.

Command:

```
$ npm start

```

To use production backend instead of running a backend locally use:

```
$ npm run start:prod

```

## 

## Build the project

Command:

```
$ npm run build

```

## Analyzing/Measuring

### Measure build performance

If the build process seems to be slower than it should you can run
the following command to analyze where bottlenecks might occur.

```
$ npm run build:measure

```

### Analyzing bundle size

Performance budget has been enabled for the application. If you get
warnings about bundle size when building you have exceeded the build
size set by the budget. Consider use of code splitting or analyze your
bundle with the following command

```
$ make analyze

```