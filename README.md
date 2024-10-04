Website
https://www.bayut.eg/en/
SRS
https://docs.google.com/document/d/1DKlTIlfPjWkAeCW60PJVhrwVvFJ86wBmpunvlbzU6G8/edit?usp=sharing
GPF
https://docs.google.com/document/d/1QyulIBephOLSuTTVzSR2cZwzDqahyCaTCnQf98yDYXc/edit?usp=sharing
Template
https://htmlcodex.com/demo/?item=2259
Type of users document
https://docs.google.com/document/d/1oWSAgOweFWjyzB3mW0UALcpLmP4yAMyv5Yrx4BXTmzw/edit
Github project
https://github.com/Alaaseif10/KeyHouse.git

inserted test data for location
-- Insert Governments
INSERT INTO Governments (Government_Name) VALUES ('Cairo');
INSERT INTO Governments (Government_Name) VALUES ('Alexandria');
INSERT INTO Governments (Government_Name) VALUES ('Giza');

-- Insert Cities
INSERT INTO Cities (City_Name, GovernmentsId) VALUES ('Nasr City', 1);
INSERT INTO Cities (City_Name, GovernmentsId) VALUES ('Heliopolis', 1);
INSERT INTO Cities (City_Name, GovernmentsId) VALUES ('Zamalek', 1);
INSERT INTO Cities (City_Name, GovernmentsId) VALUES ('Mansheya', 2);
INSERT INTO Cities (City_Name, GovernmentsId) VALUES ('Smouha', 2);
INSERT INTO Cities (City_Name, GovernmentsId) VALUES ('Dokki', 3);
INSERT INTO Cities (City_Name, GovernmentsId) VALUES ('Mohandessin', 3);

-- Insert Blocks
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block A', 1);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block B', 1);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block C', 2);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block D', 2);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block E', 3);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block F', 4);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block G', 5);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block H', 6);
INSERT INTO Blocks (Block_Name, CitiesId) VALUES ('Block I', 7);


inserted data for services
INSERT INTO BenefitsServices (BenefitsName) VALUES ('Electricity Meter');
INSERT INTO BenefitsServices (BenefitsName) VALUES ('Water Meter');
INSERT INTO BenefitsServices (BenefitsName) VALUES ('Natural Gas');
INSERT INTO BenefitsServices (BenefitsName) VALUES ('Gym or Health Club');
INSERT INTO BenefitsServices (BenefitsName) VALUES ('Lawn or Garden');
INSERT INTO BenefitsServices (BenefitsName) VALUES ('Laundry Facility');
INSERT INTO BenefitsServices (BenefitsName) VALUES ('Maintenance Staff');

