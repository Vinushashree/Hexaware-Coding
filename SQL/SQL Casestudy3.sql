-- STEP 1: CREATE TABLES (skip if already created)

CREATE DATABASE EventDb;
GO

USE EventDb;
GO

CREATE TABLE Events (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(100),
    EventDate DATE,
    Location VARCHAR(100)
);

CREATE TABLE Speakers (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(100),
    Expertise VARCHAR(100)
);

CREATE TABLE Sessions (
    SessionId INT PRIMARY KEY,
    SessionName VARCHAR(100),
    EventId INT FOREIGN KEY REFERENCES Events(EventId),
    SpeakerId INT FOREIGN KEY REFERENCES Speakers(SpeakerId),
    StartTime TIME,
    EndTime TIME
);

CREATE TABLE Participants (
    ParticipantId INT PRIMARY KEY,
    ParticipantName VARCHAR(100),
    Email VARCHAR(100),
    EventId INT FOREIGN KEY REFERENCES Events(EventId)
);
GO

-- STEP 2: INSERT PROCEDURES

CREATE PROCEDURE InsertEvent
    @EventId INT, @EventName VARCHAR(100), @EventDate DATE, @Location VARCHAR(100)
AS
BEGIN
    INSERT INTO Events VALUES (@EventId, @EventName, @EventDate, @Location);
END
GO

CREATE PROCEDURE InsertSpeaker
    @SpeakerId INT, @SpeakerName VARCHAR(100), @Expertise VARCHAR(100)
AS
BEGIN
    INSERT INTO Speakers VALUES (@SpeakerId, @SpeakerName, @Expertise);
END
GO

CREATE PROCEDURE InsertSession
    @SessionId INT, @SessionName VARCHAR(100), @EventId INT, @SpeakerId INT, @StartTime TIME, @EndTime TIME
AS
BEGIN
    INSERT INTO Sessions VALUES (@SessionId, @SessionName, @EventId, @SpeakerId, @StartTime, @EndTime);
END
GO

CREATE PROCEDURE InsertParticipant
    @ParticipantId INT, @ParticipantName VARCHAR(100), @Email VARCHAR(100), @EventId INT
AS
BEGIN
    INSERT INTO Participants VALUES (@ParticipantId, @ParticipantName, @Email, @EventId);
END
GO

-- STEP 3: DELETE PROCEDURES

CREATE PROCEDURE DeleteEvent @EventId INT AS
BEGIN DELETE FROM Events WHERE EventId = @EventId; END
GO

CREATE PROCEDURE DeleteSpeaker @SpeakerId INT AS
BEGIN DELETE FROM Speakers WHERE SpeakerId = @SpeakerId; END
GO

CREATE PROCEDURE DeleteSession @SessionId INT AS
BEGIN DELETE FROM Sessions WHERE SessionId = @SessionId; END
GO

CREATE PROCEDURE DeleteParticipant @ParticipantId INT AS
BEGIN DELETE FROM Participants WHERE ParticipantId = @ParticipantId; END
GO

-- STEP 4: UPDATE PROCEDURES

CREATE PROCEDURE UpdateEvent
    @EventId INT, @EventName VARCHAR(100), @EventDate DATE, @Location VARCHAR(100)
AS
BEGIN
    UPDATE Events SET EventName=@EventName, EventDate=@EventDate, Location=@Location WHERE EventId=@EventId;
END
GO

CREATE PROCEDURE UpdateSpeaker
    @SpeakerId INT, @SpeakerName VARCHAR(100), @Expertise VARCHAR(100)
AS
BEGIN
    UPDATE Speakers SET SpeakerName=@SpeakerName, Expertise=@Expertise WHERE SpeakerId=@SpeakerId;
END
GO

CREATE PROCEDURE UpdateSession
    @SessionId INT, @SessionName VARCHAR(100), @EventId INT, @SpeakerId INT, @StartTime TIME, @EndTime TIME
AS
BEGIN
    UPDATE Sessions SET SessionName=@SessionName, EventId=@EventId, SpeakerId=@SpeakerId,
           StartTime=@StartTime, EndTime=@EndTime WHERE SessionId=@SessionId;
END
GO

CREATE PROCEDURE UpdateParticipant
    @ParticipantId INT, @ParticipantName VARCHAR(100), @Email VARCHAR(100), @EventId INT
AS
BEGIN
    UPDATE Participants SET ParticipantName=@ParticipantName, Email=@Email, EventId=@EventId
    WHERE ParticipantId=@ParticipantId;
END
GO

-- STEP 5: CREATE VIEWS

CREATE VIEW View_SessionDetailsPerEvent AS
SELECT e.EventName, s.SessionName, s.StartTime, s.EndTime
FROM Events e JOIN Sessions s ON e.EventId = s.EventId;
GO

CREATE VIEW View_SpeakerDetailsPerSession AS
SELECT s.SessionName, sp.SpeakerName, sp.Expertise
FROM Sessions s JOIN Speakers sp ON s.SpeakerId = sp.SpeakerId;
GO

CREATE VIEW View_EventFullDetails AS
SELECT 
    e.EventName, e.EventDate, e.Location,
    s.SessionName, s.StartTime, s.EndTime,
    sp.SpeakerName, sp.Expertise,
    p.ParticipantName, p.Email
FROM Events e
LEFT JOIN Sessions s ON e.EventId = s.EventId
LEFT JOIN Speakers sp ON s.SpeakerId = sp.SpeakerId
LEFT JOIN Participants p ON e.EventId = p.EventId;
GO

-- STEP 6: CREATE NON-CLUSTERED INDEXES

CREATE NONCLUSTERED INDEX idx_EventName ON Events(EventName);
CREATE NONCLUSTERED INDEX idx_SessionName ON Sessions(SessionName);
CREATE NONCLUSTERED INDEX idx_SpeakerName ON Speakers(SpeakerName);
CREATE NONCLUSTERED INDEX idx_ParticipantEmail ON Participants(Email);
GO

-- STEP 7: SAMPLE DATA INSERTION

EXEC InsertEvent 101, 'Tech Summit 2025', '2025-08-20', 'Chennai';
EXEC InsertEvent 102, 'Health Expo 2025', '2025-09-15', 'Bangalore';

EXEC InsertSpeaker 201, 'Dr. Aisha Rao', 'Artificial Intelligence';
EXEC InsertSpeaker 202, 'Mr. Vikram Iyer', 'Healthcare Technology';

EXEC InsertSession 301, 'AI in Everyday Life', 101, 201, '10:00', '11:30';
EXEC InsertSession 302, 'Future of MedTech', 102, 202, '14:00', '15:30';

EXEC InsertParticipant 401, 'Vinusha S', 'vinusha@example.com', 101;
EXEC InsertParticipant 402, 'Arjun Nair', 'arjun.nair@example.com', 101;
EXEC InsertParticipant 403, 'Priya Mohan', 'priya.m@example.com', 102;
GO
