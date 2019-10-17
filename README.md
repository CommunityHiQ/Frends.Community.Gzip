# Frends.Community.Zip
FRENDS community task for creating gzip archive

- [Installing](#installing)
- [Tasks](#tasks)
  - [Create Archive](#createarchive)
  - [Extract Archive](#extractarchive)
- [License](#license)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing
You can install the task via FRENDS UI Task View or you can find the nuget package from the following nuget feed
'Insert nuget feed here'

# Tasks

## CreateArchive
The GZip.CreateArchive task meant for creating gzip file from selected file. 

### Task Properties

#### Input

| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| SourceFullPath | string | Source file with full path | c:\source_folder\example.txt |
| OutputFullPath | string | Output gzipped file name with full path | c:\source_folder\example.txt.gz |


### Result

| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| OutputFullPath | string | Full path to gzip file created. | c:\source_folder\example.txt.gz |


## ExtractArchive
The GZip.ExtractArchive task meant for extract gzip file to decompressed file. 

### Task Properties

#### Input

| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| SourceFullPath | string | Source gzipped file with full path | c:\source_folder\example.txt.gz |
| OutputFullPath | string | Output file name with full path | c:\source_folder\example.txt |


### Result

| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| OutputFullPath | string | Full path to file extracted. | c:\source_folder\example.txt |



# License

This project is licensed under the MIT License - see the LICENSE file for details

# Building

## Building

Requirements

`.NET Standard 2.0 or later`

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.Gzip.git`

Restore dependencies

`dotnet restore`

Build the solution

`dotnet build`

Run Tests

`dotnet test Frends.Community.Gzip.Tests`

Create a nuget package

`dotnet pack Frends.Community.Gzip`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version             | Changes                 |
| ---------------------| ---------------------|
| 1.0.0 | Initial Frends.Community version |

