# Project Q

This is a Unity 2022.3.8f1 LTS project.

Release version 0.0.0

## Documentation

This README describes the purpose of this repository and how to set up a development environment. Other sources of documentation are as follows:

- Repository changes and rules instructions are in Repository.md
- Other platform integration instructions are in Integration.md
- Project changes and rules instructions are in Changelog.md

## Prerequisites

This project is created for research, investigation, and creating workaround for Meta SDK and platform servcies. It requires the following:

- Unity Engine 2022.3.8f1
- Meta account
- Meta VR headset(s)

If you need help with Unity Engine setup, you can refer [here](https://unity.com/download).

To learn more about Meta SDK and its development, please check out the official Oculus developer [documentation](https://developer.oculus.com/resources/).


## Getting Started

To get started with the project, clone the repo and then install the needed unity engine version:

$ git clone https://github.com/ninjadanray/ProjectQ.git

Open the project, then go to Package Manager to download and import the [Oculus Integration SDK](https://developer.oculus.com/downloads/package/unity-integration/). 

Please note that the Oculus Integration SDK is included in the gitignore to keep the repository small and avoid breaking change in the master repository. Its also possible that each one
of us might be using different version of the SDK, and push the SDK in the repository that might break others workaround.

### Happy Coding!