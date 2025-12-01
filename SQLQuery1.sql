-- Tabel til LimitProfiles
CREATE TABLE LimitProfiles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    MaxTiltDegrees FLOAT NOT NULL,
    IsFragile BIT NOT NULL
);

-- Tabel til Packages
CREATE TABLE Packages (
    Id NVARCHAR(50) PRIMARY KEY,
    Description NVARCHAR(255) NOT NULL,
    LimitProfileId INT NOT NULL,
    FOREIGN KEY (LimitProfileId) REFERENCES LimitProfiles(Id)
);

-- Tabel til SensorEvents
CREATE TABLE SensorEvents (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Timestamp DATETIME DEFAULT GETDATE(),
    Tilt FLOAT NOT NULL,
    PackageId NVARCHAR(50) NOT NULL,
    FOREIGN KEY (PackageId) REFERENCES Packages(Id)
);
