create database EventDb;
use EventDb;
CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL CHECK (LEN(UserName) BETWEEN 1 AND 50),
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);
CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL CHECK (LEN(EventName) BETWEEN 1 AND 50),
    EventCategory VARCHAR(50) NOT NULL CHECK (LEN(EventCategory) BETWEEN 1 AND 50),
    EventDate DATETIME NOT NULL,
    Description VARCHAR(MAX) NULL,
    Status VARCHAR(20) CHECK (Status IN ('Active', 'In-Active'))
);
CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),
    SpeakerId INT NOT NULL,
    Description VARCHAR(MAX) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255),

    -- Foreign keys
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT CHECK (IsAttended IN (0, 1)),

    -- Foreign keys
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);
INSERT INTO UserInfo (EmailId, UserName, Role, Password) VALUES
('alice@example.com', 'Alice Johnson', 'Admin', 'admin123'),
('bob@example.com', 'Bob Smith', 'Participant', 'pass4567'),
('carol@example.com', 'Carol Davis', 'Participant', 'secret89');



INSERT INTO EventDetails (EventId, EventName, EventCategory, EventDate, Description, Status) VALUES
(101, 'Tech Summit 2025', 'Technology', '2025-07-15 09:00:00', 'Annual Technology Conference', 'Active'),
(102, 'Health & Wellness Expo', 'Health', '2025-08-10 10:00:00', 'Expo on healthy living and fitness', 'Active'),
(103, 'AI and ML Workshop', 'Education', '2025-09-20 11:00:00', NULL, 'In-Active');

INSERT INTO SpeakersDetails (SpeakerId, SpeakerName) VALUES
(1, 'Dr. Emily Roberts'),
(2, 'Mr. John Lee'),
(3, 'Prof. Sarah Connor');


INSERT INTO SessionInfo (SessionId, EventId, SessionTitle, SpeakerId, Description, SessionStart, SessionEnd, SessionUrl) VALUES
(1001, 101, 'Future of AI', 1, 'A deep dive into emerging AI trends', '2025-07-15 10:00:00', '2025-07-15 11:30:00', 'https://event.com/session1001'),
(1002, 101, 'Cybersecurity Today', 2, NULL, '2025-07-15 12:00:00', '2025-07-15 13:00:00', 'https://event.com/session1002'),
(1003, 102, 'Yoga for All', 3, 'Interactive yoga session', '2025-08-10 10:00:00', '2025-08-10 11:00:00', 'https://event.com/session1003');

INSERT INTO ParticipantEventDetails (Id, ParticipantEmailId, EventId, SessionId, IsAttended) VALUES
(1, 'bob@example.com', 101, 1001, 1),
(2, 'carol@example.com', 101, 1002, 0),
(3, 'carol@example.com', 102, 1003, 1);

select * from  UserInfo
select * from  EventDetails
select * from  SpeakersDetails
select * from  SessionInfo
select * from  ParticipantEventDetails
