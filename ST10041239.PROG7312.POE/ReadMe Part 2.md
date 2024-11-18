# Municipal Services Application README

# !!ATTENTION!! Please Note (PART 1):

There are two versions of this application, the WPF MunicipalSercvice, and the WinForms MunicipalSercviceApp.

As seen by my submission history, the first submission was only of the WPF application.
It was later brought to my attention that you had replied to a class memeber saying "The instructions clearly states Windows Form for POE Part 1".
So I kindly re-wrote the application in Windows Form.

My video was recoreded for the WPF application, but still remains relevant as all features are present in the Windows Form app.

Regards.

## Overview

The Municipal Services Application is a C# .NET Framework software application designed to facilitate citizen engagement with municipal services. Users can report issues, request services, and track their submissions. The application incorporates gamification features to encourage active participation by allowing users to earn "Report Points" for each issue reported.

In Part 2, the application has been extended to include local events and announcements, enhancing user engagement and providing a comprehensive platform for accessing municipal information.

## Features

- **Report Issues**: Users can report various municipal issues, including location, category, and detailed descriptions.
- **Local Events and Announcements**: Users can view upcoming local events and announcements.
- **Search Functionality**: Users can filter events based on categories and date ranges.
- **Gamification**: Users earn points for each reported issue, which can lead to badges and recognition.
- **Recommendation System**: The application suggests events based on user interactions and search patterns.
- **Gamification**: Users earn points for each reported issue, which can lead to badges and recognition.
- **Media Attachment**: Users can attach images or documents related to their reports.
- **User-Friendly Interface**: A clean and intuitive interface for ease of use.

## Prerequisites

- .NET Framework 4.7.2 or higher
- Visual Studio 2019 or later
- Windows operating system

## Installation Instructions

1. **Open the Project**:

   - Launch Visual Studio.
   - Open the solution file `MunicipalService.sln`.

2. **Restore NuGet Packages** (if applicable):

   - Right-click on the solution in Solution Explorer and select "Restore NuGet Packages".

3. **Build the Project**:
   - Go to the "Build" menu and select "Build Solution" or press `Ctrl + Shift + B`.

## Running the Application

1. **Start the Application**:

   - Press `F5` or click on the "Start" button in Visual Studio to run the application.

2. **Main Menu**:

   - Upon startup, the main menu will present three options:
     - **Report Issues** (currently implemented).
     - Local Events and Announcements (to be implemented later).
     - Service Request Status (to be implemented later).

3. **Report Issues**:

   - Click on "Report Issues" to navigate to the reporting page.
   - Fill in the required fields:
     - **Location**: Enter the location of the issue.
     - **Category**: Select the category from the dropdown.
     - **Description**: Provide a detailed description of the issue.
     - **Media Attachment**: Click the button to attach any relevant files.
   - Click the "Submit" button to report the issue.

4. **Gamification**:
   - After submitting an issue, users will earn Report Points, which will be displayed in the navigation bar.

## Usage Instructions

- **Reporting an Issue**: Follow the prompts on the Report Issues page to submit an issue. Ensure all fields are filled out correctly to avoid validation errors.
- **Viewing Points**: The total Report Points will be displayed in the navigation bar, updating dynamically as issues are reported.

## Troubleshooting

- If the application does not run:
  - Ensure that you have the correct version of the .NET Framework installed.
  - Check for any missing dependencies in the project references.

## Contact

For any questions or issues, please contact:

- **Your Name**
- **Your Email Address**
