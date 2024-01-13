# Hangfire

This project is a demo application that includes the use of Hangfire. It is purely for educational purposes.

## Installation

You do not need to take any extra action for installation.
After downloading or cloning the project, create a database where Hangfire can store its operations and place it in the connection string.

<hr>

### What is Hangfire?

Hangfire is a library used to easily create and manage background tasks in .NET applications.

### How Does It Work?

Hangfire is a type of server and it needs a storage area where it can access the information of the data it will process and then store the processed data. 
On the other hand, our transactions with this database are carried out by our application.

<br>

![GetImage](https://github.com/zubeyrdamar/Hangfire/assets/141228392/96f5821b-e53a-4865-8a7a-c8eb4c3a0117)

<br>

### Job Types

* Fire and Forget : it is a type of job that works once and instantly and is then eliminated.
* Delayed         : it is the type of job used for operations that need to be run at once after a certain period of time.
* Recurring       : it is the job type used for operations that we want to run at regular intervals.
* Continuations   : it is the job type that runs after the jobs we specify

You can review the codes for more information.
