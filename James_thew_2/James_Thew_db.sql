
create database james_thew_recipes
Go

use james_thew_recipes
GO

CREATE TABLE Users (
  UserID INT IDENTITY PRIMARY KEY,
  Username VARCHAR(255),
  Email VARCHAR(255),
  Password VARCHAR(255),
  Profile_pic VARCHAR(255),
  MembershipType VARCHAR(20),
  PaymentStatus bit,
  RegistrationDate DATETIME
);

--Recipes Categories
CREATE TABLE Categories (
  CategoryID INT IDENTITY(3001,1) PRIMARY KEY,
  CategoryName VARCHAR(255)
);


-- Recipes table
CREATE TABLE Recipes (
  RecipeID INT IDENTITY PRIMARY KEY,
  UserID INT,
  RecipeTitle VARCHAR(255),
  RecipeImage VARCHAR(max),
  CategoryID INT,
  IsFree bit,
  CreatedDate DATE,
  FOREIGN KEY (UserID) REFERENCES Users(UserID),
  FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) on delete cascade on update cascade
);

CREATE TABLE Ingredients (
  IngredientID INT IDENTITY PRIMARY KEY,
  RecipeID INT,
  IngredientName VARCHAR(255),
  FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID) on delete cascade on update cascade
);

-- Steps table
CREATE TABLE Steps (
  StepID INT IDENTITY PRIMARY KEY,
  RecipeID INT,
  StepNumber INT,
  Description TEXT,
  FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID) on delete cascade on update cascade
);


-- Tips table
CREATE TABLE Tips (
  TipID INT IDENTITY PRIMARY KEY,
  UserID INT,
  TipText TEXT,
  IsFree BIT,
  CreatedDate DATE,
  FOREIGN KEY (UserID) REFERENCES Users(UserID) on delete cascade on update cascade
);

-- Contests table
CREATE TABLE Contests (
  ContestID INT IDENTITY PRIMARY KEY,
  UserID INT,
  ContestTitle VARCHAR(255),
  ContestDescription TEXT,
  CreatedDate DATE,
  FOREIGN KEY (UserID) REFERENCES Users(UserID) on delete cascade on update cascade
);

-- ContestEntries table
CREATE TABLE ContestEntries (
  EntryID INT IDENTITY PRIMARY KEY,
  ContestID INT,
  UserID INT,
  RecipeID INT,
  TipID INT,
  EntryDate DATE,
  FOREIGN KEY (ContestID) REFERENCES Contests(ContestID) on delete cascade on update cascade,
  FOREIGN KEY (UserID) REFERENCES Users(UserID),
  FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID) on delete cascade on update cascade,
  FOREIGN KEY (TipID) REFERENCES Tips(TipID) 
);

-- Announcements table
CREATE TABLE Announcements (
  AnnouncementID INT IDENTITY PRIMARY KEY,
  UserID INT,
  AnnouncementText TEXT,
  AnnouncementDate DATE,
  FOREIGN KEY (UserID) REFERENCES Users(UserID) on delete cascade on update cascade
);

-- Feedback table
CREATE TABLE Feedback (
  FeedbackID INT IDENTITY PRIMARY KEY,
  UserID INT,
  RecipeID INT,
  FeedbackText TEXT,
  FeedbackDate DATE,
  FOREIGN KEY (UserID) REFERENCES Users(UserID) on delete cascade on update cascade,
  FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID) on delete cascade on update cascade
);


CREATE TABLE Comments (
  CommentID INT IDENTITY PRIMARY KEY,
  UserID INT,
  RecipeID INT,
  CommentText TEXT,
  CommentDate DATE,
  FOREIGN KEY (UserID) REFERENCES Users(UserID) on delete cascade on update cascade,
  FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID) on delete cascade on update cascade
);

create table tbl_admin(
a_id int identity primary key,
a_name varchar(255),
a_email varchar(255),
a_password varchar(255)

)



insert into tbl_admin values('zain','zain@gmail.com','zain123')

insert into Users values('fahad','fahad@gmail.com','fahad123','profile_pic','1','1',CURRENT_TIMESTAMP)