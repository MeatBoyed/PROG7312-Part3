# Municipal Services Application README

# !!ATTENTION!! Please Note (PART 1):

There are two versions of this application, the WPF MunicipalSercvice, and the WinForms MunicipalSercviceApp.

As seen by my submission history, the first submission was only of the WPF application.
It was later brought to my attention that you had replied to a class memeber saying "The instructions clearly states Windows Form for POE Part 1".
So I kindly re-wrote the application in Windows Form.

My video was recoreded for the WPF application, but still remains relevant as all features are present in the Windows Form app.

Regards.

## Overview

The Municipal Services Application is a C# .NET Framework software application designed to facilitate citizen engagement with municipal services. Users can report issues, request services, track their submissions, and view local events and announcements. The application incorporates gamification features, such as a badge points/rewards given to users for issuing reports, and a recommendation system that tracks user's interactions to recommend their most interested events & enouncements.

To provide manage the data and search functionality, advanced data structures like Binary Search Trees, Hash tables, and Queues to ensure the application uses scalable data structures.

## Features

- **Report Issues**: Users can report various municipal issues, including location, category, and detailed descriptions.
- **Local Events and Announcements**: Users can view upcoming local events and announcements.
- **Search Functionality**: Users can filter events based on categories and date ranges.
- **Gamification**: Users earn points for each reported issue, which can lead to badges and recognition.
- **Real-Time Events**: Badge points/amount are show in Real Time using Event handlers and Controllers.
- **Recommendation System**: The application suggests events based on user interactions and search patterns.
- **Media Attachment**: Users can attach images or documents related to their reports.
- **User-Friendly Interface**: A clean and intuitive interface for ease of use.
- **Search by ID**: Efficiently locate service requests using a Binary Search Tree (BST) to enhance user experience.
- **Filter by Category**: Organize and display service requests based on selected categories through a Binary Tree structure.
- **Filter by Status**: Quickly retrieve service requests filtered by their status (e.g., In-Progress, Completed, Cancelled) using a Min-Heap.
- **Order by Status and Date**: Sort service requests based on status and reported date for better management and visibility.
- **Retrieve Available Categories**: Access a comprehensive list of all available categories for intuitive filtering options.
- **Retrieve Available Statuses**: Get all possible statuses to facilitate user selection in filtering functionalities.

## Prerequisites

- .NET Framework 4.7.2 or higher
- Visual Studio 2019 or later
- Windows operating system

## Installation Instructions

1. **Open the Project**:

   - Launch Visual Studio.
   - Open the solution file `ST10041239.PROG7312.POE.sln`.

2. **Restore NuGet Packages** (if applicable):

   - Right-click on the solution in Solution Explorer and select "Restore NuGet Packages".

3. **Build the Project**:
   - Go to the "Build" menu and select "Build Solution" or press `Ctrl + Shift + B`.

## Running the Application

1. **Start the Application**:

   - Press `F5` or click on the "Start" button in Visual Studio to run the application.

2. **Main Menu**:

   - Upon startup, you will be presented with a main menu with several options:
     - **Report Issues**: Navigate to report municipal issues.
     - **Local Events and Announcements**: View upcoming local events.
     - **Service Request Status**: Track the status of submitted service requests.

3. **Reporting Issues**:

   - Click on "Report Issues" to navigate to the reporting page.
   - Fill in the required fields:
     - **Location**: Enter the location of the issue.
     - **Category**: Select a category from the dropdown.
     - **Description**: Provide a detailed description of the issue.
     - **Media Attachment**: Click to attach any relevant files.
   - Click the "Submit" button to report the issue.
   - Click "View Reports" button to see saved reports.

4. **Viewing Local Events and Announcements**:

   - Click on "Local Events and Announcements" to view upcoming events.
   - Use filters (category selector, date pickers) to narrow down your search results.

5. **Tracking Service Request Status**:

   - Click on "Service Request Status" to view all submitted requests.
   - Use the search feature to find requests by ID or filter by status and category.

6. **Gamification Features**:
   - After submitting an issue, users will earn Report Points displayed in the navigation bar.

## Usage Instructions

- **Reporting an Issue**: Follow the prompts on the Report Issues page to submit an issue. Ensure all fields are filled out correctly to avoid validation errors.
- **Viewing Points**: The total Report Points will be displayed in the navigation bar, updating dynamically as issues are reported.

## Troubleshooting

- If the application does not run:
  - Ensure that you have the correct version of the .NET Framework installed.
  - Check for any missing dependencies in the project references.
