# 🛡️ CyberPal – Cybersecurity Awareness Chatbot

## 📌 Project Overview
The Cybersecurity Awareness Chatbot is a C# console application designed to educate users about basic cybersecurity safety. It provides interactive responses based on user input and helps users understand how to stay safe online.

The chatbot uses keyword detection to respond to different cybersecurity topics and includes a “more info” feature for deeper explanations.

---

## ✨ Features

- 👤 User name input and personalized greeting
- 💬 Keyword-based chatbot responses
- 🔁 “More info” feature for extended explanations
- 🎨 Colored console interface for better readability
- ❌ Exit command to close the chatbot
- 🧠 Simple and interactive learning system
- 🔊 Voice greeting on startup (WAV audio support)
- 🖼️ ASCII logo display

---

## 🧠 Cybersecurity Topics Covered

| Topic | Trigger Keywords |
|------|------------------|
| 🔐 Password Safety | password safety, password |
| 🎣 Phishing | phishing |
| 🌐 Safe Browsing | safe browsing |
| 🦠 Malware | malware |
| 📶 Public WiFi Safety | wifi, public wifi |
---

## 🚀 How to Run the Project

### Requirements:
- .NET 6 SDK
- Visual Studio 2022 or VS Code

### Run Commands:

``bash
dotnet restore
dotnet build
dotnet run
---

🎯 How the Chatbot Works

	1.	User enters their name 👤
	2.	Bot greets user with message + voice 🔊
	3.	User types a question or keyword 💬
	4.	Bot detects keyword and responds
	5.	User can type “more” for extra details
	6.	User types “exit” to close the chatbot ❌
  ---

  🧾 Example Inputs
  
	•	password safety
	•	phishing
	•	safe browsing
	•	malware
	•	wifi
	•	more
	•	exit
  ---

  📈 Git Commit History 
  
	1.	Initial project setup with console application structure
	2.	Added user input and greeting system
	3.	Implemented chatbot keyword detection logic
	4.	Added password safety topic response
	5.	Added phishing awareness response
	6.	Added safe browsing explanations
	7.	Added malware awareness responses
	8.	Added public WiFi safety topic
	9.	Integrated voice greeting feature
	10.	Final cleanup and documentation updates
  ---
	## 🟢 CI workflow Build Success
<img width="1440" height="900" alt="ci-sucess" src="https://github.com/user-attachments/assets/24b8e2bb-691d-49a5-a3e3-e5a01f3636fe" />

---
# 🛡️ CyberPal – Cybersecurity Awareness Chatbot(Part 2)

📌 Project Overview

CyberPal is a GUI-based cybersecurity awareness chatbot developed using C# and WPF. The application is designed to educate users about important cybersecurity concepts through interactive conversations and personalized responses.

The chatbot helps users learn about online safety topics such as passwords, phishing, scams, malware, and privacy. It uses keyword detection, memory features, topic tracking, and conversational logic to create a more natural user experience.

This project also includes a graphical user interface, voice greeting functionality, topic-based tips, and extra learning information.

⸻

✨ Features

* 👤 Personalized user greeting and name memory
* 💬 Interactive GUI chat interface using WPF
* 🧠 Keyword-based cybersecurity topic detection
* 🔁 Extra information system for deeper explanations
* 💡 Cybersecurity tips feature
* 🗂️ Topic memory and conversation tracking
* 😊 Emotion detection for worried or confused users
* 🔊 Voice greeting using WAV audio playback
* 🖼️ Custom chatbot logo/image support
* ⌨️ Enter key support for sending messages
* 🎨 Styled dark-themed graphical interface
* 🛡️ Educational cybersecurity awareness system

⸻

🧠 Cybersecurity Topics Covered

Topic	Trigger Keywords
🔐 Password Safety	password, 2fa, login
🎣 Phishing Awareness	phishing, scam
🌐 Privacy Protection	privacy
🦠 Malware Protection	malware, virus
🚨 Online Scam Awareness	scam

⸻

🖥️ Technologies Used

* C#
* WPF (Windows Presentation Foundation)
* .NET
* XAML
* Visual Studio 2022

⸻

🚀 How to Run the Project

Requirements

* Visual Studio 2022
* .NET Desktop Development workload
* .NET SDK

⸻

Steps to Run

dotnet restore
dotnet build
dotnet run

Or:

1. Open the solution in Visual Studio 2022
2. Build the project
3. Run the application using:
    * Start button
    * F5 key

⸻

🎯 How the Chatbot Works

1. User opens the application 🖥️
2. Voice greeting plays automatically 🔊
3. User enters their name 👤
4. Chatbot greets the user personally
5. User asks about a cybersecurity topic 💬
6. Bot detects keywords and provides responses
7. User can ask for:
    * tips
    * more information
    * explanations
8. Chatbot remembers the previous topic discussed 🧠
9. Conversation continues interactively

⸻

🧾 Example Inputs

* password
* phishing
* privacy
* malware
* scam
* give me a tip
* explain
* tell me more
* i am worried about phishing
* thank you
* bye

⸻

🧩 System Components

MainWindow.xaml

Handles the graphical user interface layout including:

* Chat display area
* User input textbox
* Send button
* Chatbot image/logo

⸻

MainWindow.xaml.cs

Controls:

* User interaction
* Message sending
* Chat display updates
* Enter key functionality
* Voice greeting startup

⸻

Chatbot.cs

Contains the chatbot logic:

* Topic detection
* Response generation
* Memory handling
* Tip system
* Extra information system
* Emotion detection
* Topic tracking

⸻

VoiceGreeting.cs

Handles:

* WAV audio loading
* Voice greeting playback
* Error handling for missing audio files

⸻

User.cs

Stores user information:

* User name
* User interests

⸻

🧠 Object-Oriented Programming Concepts Used

Concept	Implementation
Classes	Chatbot, User, VoiceGreeting, MainWindow
Encapsulation	Private dictionaries and variables
Delegates	ResponseDelegate used for response handling
Dictionaries	Used for responses, tips, memory, and definitions
Methods	Organized chatbot functionality
Error Handling	Try-catch blocks for voice greeting

⸻

📈 Git Commit History

1. Created WPF project structure
2. Added chatbot GUI layout
3. Implemented chatbot response system
4. Added cybersecurity topics
5. Added keyword detection
6. Added personalized greeting system
7. Implemented chatbot memory
8. Added tips and extra information features
9. Added voice greeting functionality
10. Added emotion detection logic
11. Added topic tracking system
12. Final UI styling and documentation updates

⸻

🟢 Application Features Demonstrated

✅ GUI Development using WPF

✅ Event-driven programming

✅ File and media handling

✅ Data structures using dictionaries

✅ Object-oriented programming principles

✅ User interaction handling

✅ Conversational chatbot logic

⸻

📷 User Interface

The application includes:

* Dark-themed cybersecurity interface
* RichTextBox chat display
* Interactive Send button
* Chatbot image/logo
* Audio greeting support

⸻

👨‍💻 

This chatbot is created as an educational cybersecurity awareness system to help users understand online safety practices in a simple and interactive way.

The chatbot focuses on beginner-friendly explanations and encourages safe online behavior through conversational learning 

-------


# 🛡️ Cybersecurity Awareness Chatbot – Part 3

## 📖 Overview

The **Cybersecurity Awareness Chatbot** is a C# WPF desktop application designed to educate users about cybersecurity while providing useful productivity features. The application allows users to interact with a chatbot, manage cybersecurity-related tasks, take quizzes, and view an activity log.

Part 3 extends the chatbot by introducing task management with database storage, natural language processing (NLP), a cybersecurity quiz, reminders, and an activity log.

---

# ✨ Features

## 💬 Chatbot
- 🤖 Responds to cybersecurity-related questions.
- 🔍 Uses keyword recognition to understand user requests.
- 💻 Displays responses in a user-friendly chat interface.

## 🧠 Natural Language Processing (NLP)

The chatbot recognizes keywords such as:
- ➕ Add task
- 🗑️ Delete task
- ⏰ Reminder
- ❓ Quiz

This allows users to interact naturally instead of relying only on buttons.

---

## 📋 Task Management

Users can:
- ➕ Add new tasks
- 👀 View saved tasks
- 🗑️ Delete existing tasks
- 💾 Store task information in a SQL Server database

Each task contains:
- 🆔 Task ID
- 📝 Title
- 📄 Description
- 📅 Reminder Date

---

## 🎯 Cybersecurity Quiz

- ❓ Multiple cybersecurity questions
- 📊 Calculates the user's score
- 🏆 Displays results at the end

---

## ⏰ Reminders

Users can:
- 📅 Set reminder dates for tasks
- 🔔 Receive reminders when tasks become due

---

## 📜 Activity Log

Records important user actions, including:
- ✅ Tasks added
- ❌ Tasks deleted
- ▶️ Quiz started
- 🎉 Quiz completed
- 🔔 Reminder actions

---

# 🛠️ Technologies Used

- 💻 C#
- 🖼️ WPF (Windows Presentation Foundation)
- 🎨 XAML
- ⚙️ .NET Framework
- 🗄️ SQL Server
- 🧰 SQL Server Management Studio (SSMS)
- 🔗 ADO.NET

---

# 🗃️ Database

### 📂 Database Name
```
CyberSecurityDB
```

### 📑 Table
```
Tasks
```

### 📌 Columns

| Column | Data Type |
|---------|-----------|
| 🆔 TaskID | INT (Primary Key, Identity) |
| 📝 Title | NVARCHAR |
| 📄 Description | NVARCHAR |
| 📅 ReminderDate | DATE |

---

# 📁 Project Structure

```
CyberSecurityChatbotGUI
│
├── 📄 MainWindow.xaml
├── 💻 MainWindow.xaml.cs
├── 🗄️ DatabaseHelper.cs
├── ❓ Quiz.cs
├── 📜 ActivityLogger.cs
├── 📋 Task.cs
└── 🚀 App.xaml
```

---

# ▶️ How to Run

1. 📂 Open the solution in Visual Studio.
2. 🗄️ Ensure SQL Server is running.
3. 🏗️ Create the **CyberSecurityDB** database.
4. 📋 Create the **Tasks** table.
5. 🔗 Update the connection string if necessary.
6. 🔨 Build the solution.
7. ▶️ Run the application.

---

# 📚 How to Use

## 💬 Chatbot
Type a cybersecurity question into the chat box and press **Enter** or click **Send**.

## 📋 Tasks
Click the **Tasks** button to:
- ➕ Add tasks
- 👀 View tasks
- 🗑️ Delete tasks

## 🎯 Quiz
Click the **Quiz** button to begin the cybersecurity quiz.

## 📜 Activity Log
Click the **Activity Log** button to view recorded user activities.

---

# 🧠 Sample NLP Commands

Examples include:

```
Add task
```

```
Delete task
```

```
Open quiz
```

```
Show reminder
```

The chatbot automatically detects these keywords and performs the corresponding action.

---

# 🚀 Future Improvements

- 👤 User authentication
- 🔒 Password encryption
- 📧 Email reminders
- 🤖 AI-powered chatbot responses
- ❓ More cybersecurity quiz questions
- ✏️ Task editing functionality

---

# 👩‍💻 Author

**Nanka Mbatha**

---

# 🎓 Purpose

This project was developed as **Part 3 of the Cybersecurity Awareness Chatbot assignment**.

It demonstrates:
- 💻 GUI development using WPF
- 🗄️ SQL Server database integration
- 🔄 CRUD operations
- 🧠 Natural Language Processing (keyword detection)
- ⚙️ Event-driven programming
- 🧩 Object-Oriented Programming (OOP)
- 🛡️ Cybersecurity awareness education

---

⭐ **Thank you for exploring the Cybersecurity Awareness Chatbot! Stay safe online and practice good cybersecurity habits.** 🛡️🔐




  
